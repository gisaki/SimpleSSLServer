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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String http_header_and_body = textBox_stdout.Text;
            byte[] buf = Encoding.UTF8.GetBytes(http_header_and_body);

            System.IO.Stream stdout = Console.OpenStandardOutput();
            stdout.Write(buf, 0, buf.Length);
        }
    }
}
