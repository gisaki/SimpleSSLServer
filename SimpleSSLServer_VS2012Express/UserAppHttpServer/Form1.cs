using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAppHttpServer
{
    public partial class Form1 : Form
    {
        private byte[] inbyte_;

        public Form1(byte[] inbyte)
        {
            InitializeComponent();

            inbyte_ = inbyte;

            // textBox1.Text = BitConverter.ToString(inbyte_);
            textBox_stdin.Text = System.Text.Encoding.ASCII.GetString(inbyte_);
            // textBox1.Text = String.Format("{0}", inbyte_.Length);

            // 表示項目の初期化
            ViewInit();
        }

        // 表示項目の初期化
        private void ViewInit()
        {
            comboBox_Send_StatusCode.Items.Add("200 OK");
            comboBox_Send_StatusCode.Items.Add("400 aaa");
            comboBox_Send_StatusCode.Items.Add("404 bbb");
            comboBox_Send_StatusCode.Items.Add("500 ccc");
            comboBox_Send_StatusCode.SelectedIndex = 0;
        }

        // 送信ボタン
        private void button_Send_Click(object sender, EventArgs e)
        {
            // 送信データ（バッファ）構築
            byte[] buf;
            if ((Button)sender == button_Send_HeadrBody_Raw)
            {
                buf = BuildBufRaw();
            }
            else
            {
                byte[] buf_header = BuildHeader(); // 末尾に改行を含む
                byte[] buf_separator = new byte[] { 0x0d, 0x0a };
                byte[] buf_body = BuildBody();
                buf = new byte[buf_header.Length + buf_separator.Length + buf_body.Length];

                // 合体
                int to_index = 0;
                {
                    buf_header.CopyTo(buf, to_index);
                    to_index += buf_header.Length;
                }
                {
                    buf_separator.CopyTo(buf, to_index);
                    to_index += buf_separator.Length;
                }
                {
                    buf_body.CopyTo(buf, to_index);
                    to_index += buf_body.Length;
                }
            }

            // 標準出力へ出力
            System.IO.Stream stdout = Console.OpenStandardOutput();
            stdout.Write(buf, 0, buf.Length);
        }

        // データ組み立て
        private byte[] BuildBufRaw()
        {
            String http_header_and_body = textBox_stdout.Text;
            byte[] buf = Encoding.UTF8.GetBytes(http_header_and_body);
            return buf;
        }
        private byte[] BuildHeader()
        {
            String content_length = "";
            String status_line = "";

            // 自動
            if (radioButton_Send_Header_Auto.Checked)
            {
                content_length = String.Format("{0}", BuildBody().Length);
                status_line = comboBox_Send_StatusCode.Text;
            }
            // 手動
            if (radioButton_Send_Header_Manual.Checked)
            {
                content_length = textBox_Send_Manual_ContentLen.Text;
                status_line = textBox_Send_Manual_StatusLine.Text;
            }

            String http_header = "";
            http_header += "HTTP/1.1 " + status_line + "\r\n";
            http_header += "Content-length: " + content_length + "\r\n";

            byte[] buf = Encoding.UTF8.GetBytes(http_header);
            return buf;
        }
        private byte[] BuildBody()
        {
            // テキスト
            if (radioButton_Send_Body_Text.Checked)
            {
                String http_header_and_body = textBox_Send_Body.Text;
                byte[] buf = Encoding.UTF8.GetBytes(http_header_and_body);
                return buf;
            }

            // hex
            if (radioButton_Send_Body_Hex.Checked)
            {
                return HexStringToByteArray(textBox_Send_Body.Text);
            }

            // それ以外
            return new byte[] { };
        }

        // --------
        // その他
        // --------
        // １６進数文字列バイト配列変換
        private static byte[] HexStringToByteArray(string data)
        {
            if (data == null)
                throw new ArgumentNullException();
            Regex re = new Regex("[^0-9a-fA-F]", RegexOptions.Singleline);
            //Console.WriteLine(data); // デバッグ
            data = re.Replace(data, "");
            //Console.WriteLine(data); // デバッグ
            if (data.Length % 2 == 1)
                data = "0" + data;  // 補正

            var list = new List<byte>();
            for (int i = 0; i < data.Length - 1; i++, i++)
                list.Add(Convert.ToByte(data.Substring(i, 2), 16));
            return list.ToArray();
        }

    }
}
