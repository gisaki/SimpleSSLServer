using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }

        // 送信ボタン
        private void button_Send_Click(object sender, EventArgs e)
        {
            String http_header_and_body = textBox_stdout.Text;
            byte[] buf = Encoding.UTF8.GetBytes(http_header_and_body);

            System.IO.Stream stdout = Console.OpenStandardOutput();
            stdout.Write(buf, 0, buf.Length);
        }
    }
}
