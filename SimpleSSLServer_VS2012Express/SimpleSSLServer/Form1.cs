﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleSSLServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpServer server_ = null;
        private void button_Listen_Click(object sender, EventArgs e)
        {
            if (this.server_ == null)
            {
                button_Listen.Text = "Listening ...";

                int portno = Int32.Parse(textBoxPort.Text);
                string sslCertFileName = textBoxPfxFilePath.Text;
                string sslCertPassword = textBoxPfxPassword.Text;
                this.server_ = new TcpServer(portno, sslCertFileName, sslCertPassword);
                this.server_.proc_ssl_server();
            }
            else
            {
                button_Listen.Text = "Listen";
                this.server_.Abort();
                while (this.server_.run_) { }
                this.server_ = null;
            }
        }

        // PFXファイルを開く
        private void button_OpenPfx_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open .pfx file";
            ofd.InitialDirectory = textBoxPfxFilePath.Text;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBoxPfxFilePath.Text = ofd.FileName;
            }
        }
    }

    public class TcpServer
    {
        private int portno_ = 0;
        private TcpListener listener_ = null;
        private bool abort_ = false;
        public bool run_ = true;

        // for SSL
        private System.Security.Cryptography.X509Certificates.X509Certificate serverCert_;
        
        // 
        // コンストラクタ
        // 
        public TcpServer(int portno, string sslCertFileName, string sslCertPassword)
        {
            this.portno_ = portno;
            this.serverCert_ = new System.Security.Cryptography.X509Certificates.X509Certificate2(sslCertFileName, sslCertPassword);
            this.listener_ = TcpListener.Create(this.portno_);
        }

        // 
        // 停止
        // 
        public void Abort()
        {
            this.abort_ = true;
            this.listener_.Stop();
        }

        public void proc_ssl_server()
        {
            Task task = new Task(() =>
            {
                Console.WriteLine("Listening ...");
                this.listener_.Start();

                while (true)
                {
                    TcpClient client = null;
                    try
                    {
                        client = this.listener_.AcceptTcpClient(); // 被接続まで待機
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception: {0}", ex.Message);
                        Console.WriteLine("Closed.");
                        this.run_ = false; // 終了
                        return;
                    }

                    if (abort_) { break; }
                    task_ssl_server(client, this.serverCert_);
                    Console.WriteLine("TCP Accepted");
                }
                Console.WriteLine("Closed.");

                this.run_ = false; // 終了
            });
            task.Start();
        }

        private static Boolean UserCertificateValidationCallback(Object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // always pass
            return true;
        }

        private void task_ssl_server(TcpClient client, System.Security.Cryptography.X509Certificates.X509Certificate serverCert)
        {
            Task task = new Task(() =>
            {
                SslStream sslStream = new SslStream(client.GetStream(), false, UserCertificateValidationCallback, null);
                try
                {
                    {
                        // 
                        // 制限事項：
                        // SslStream を使用する限り、サーバが返却する証明書は1つのみに限られる。
                        // そのためサーバ証明書＋中間CA証明書をクライアントに返却することはできない。
                        // 背景：
                        // AuthenticateAsServer() に指定できる証明書が X509Certificate 1つのみのため。
                        // 仮に X509CertificateCollection が指定できれば可能だと思うけれども。
                        // （おそらく）OpenSSLを使用すれば可能なはず。
                        // 
                        sslStream.AuthenticateAsServer(serverCert, false, SslProtocols.Tls12, false);
                        sslStream.ReadTimeout = 2000;

                        // 読み込み
                        while (proc_sslstream_read(sslStream)) { }
                    }
                }
                catch (AuthenticationException ex)
                {
                    Console.WriteLine("AuthenticationException: {0}", ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: {0}", ex.Message);
                }
                finally
                {
                    sslStream.Close();
                    client.Close();
                }
            });
            task.Start();
        }

        private IUserApp userapp_process_ = new UserAppOtherProcess();
        private IUserApp userapp_mqtt_ = new UserAppMqttBroker();
        private IUserApp userapp_http_ = new UserAppHttpServer();
        private bool proc_sslstream_read(SslStream sslStream)
        {
            try
            {
                byte[] rcvBuf = new byte[128];
                int n;
                while ((n = sslStream.Read(rcvBuf, 0, rcvBuf.Length)) > 0)
                {
                    byte[] rcvbytes = new byte[n];
                    Array.Copy(rcvBuf, 0, rcvbytes, 0, n);
                    String s = BitConverter.ToString(rcvbytes);
                    Console.WriteLine("Receive: {0}", s);

                    // アプリケーション処理
                    // 受信したパケットに応じて、応答パケット（送信パケット）を構築する
                    byte[] sndbytes = { };
                    if (sndbytes.Length <= 0)
                    {
                        userapp_process_.Proc(rcvbytes, out sndbytes);
                    }
                    if (sndbytes.Length <= 0)
                    {
                        userapp_mqtt_.Proc(rcvbytes, out sndbytes);
                    }
                    if (sndbytes.Length <= 0)
                    {
                        userapp_http_.Proc(rcvbytes, out sndbytes);
                    }

                    proc_sslstream_write(sslStream, sndbytes);
                    String s2 = BitConverter.ToString(sndbytes);
                    Console.WriteLine("Send: {0}", s2);
                }
            }
            catch (System.IO.IOException ex)
            {
                // a timeout occurred
                {
                    byte[] rcvBuf = new byte[128];
                    int originalTimeout = sslStream.ReadTimeout;
                    sslStream.ReadTimeout = 1;
                    sslStream.Read(rcvBuf, 0, rcvBuf.Length);
                    sslStream.ReadTimeout = originalTimeout;
                }
                Console.WriteLine("Exception: {0}", ex.Message);
                return true; // 継続
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
                return false; // 中断
            }

            return false; // 中断
        }

        private void proc_sslstream_write(SslStream sslStream, byte[] sndbytes)
        {
            if (sndbytes.Length <= 0)
            {
                return;
            }
            sslStream.Write(sndbytes, 0, sndbytes.Length);
        }

    }
}
