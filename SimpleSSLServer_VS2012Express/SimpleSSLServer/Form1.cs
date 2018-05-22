using System;
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

        private static Boolean UserCertificateValidationCallback(Object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // always pass
            return true;
        }

        private void button_Listen_Click(object sender, EventArgs e)
        {
            TcpListener listener = TcpListener.Create(8883);
            listener.Start();
            TcpClient client = listener.AcceptTcpClient();
            SslStream sslStream = new SslStream(client.GetStream(), false, UserCertificateValidationCallback, null);
            try
            {
                {
                    System.Security.Cryptography.X509Certificates.X509Certificate2 serverCert =
                        new System.Security.Cryptography.X509Certificates.X509Certificate2("example_com.pfx", "password");
                    sslStream.AuthenticateAsServer(serverCert, false, SslProtocols.Tls12, false);
                    sslStream.ReadTimeout = 2000;

                    byte[] rcvbytes = new byte[128];
                    int n;
                    while ((n = sslStream.Read(rcvbytes, 0, rcvbytes.Length)) > 0)
                    {
                        String s = BitConverter.ToString(rcvbytes);
                        Console.WriteLine("Receive: {0}", s);
                    }
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
                listener.Stop();
            } 
        }
    }
}
