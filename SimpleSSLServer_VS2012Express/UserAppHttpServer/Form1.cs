using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            // 表示関連
            ViewInit(); // 初期化
            ViewUpdate(); // 更新
        }

        // ----------------
        // 表示関連
        // ----------------

        // 表示項目の初期化
        private void ViewInit()
        {
            // 定義されているHTTPステータスコードをcomboBoxに登録
            {
                foreach (System.Net.HttpStatusCode statuscode in Enum.GetValues(typeof(System.Net.HttpStatusCode)))
                {
                    int code = (int)statuscode;
                    string description = System.Web.HttpWorkerRequest.GetStatusDescription(code);
                    comboBox_Send_StatusCode.Items.Add(code + " " + description);
                }
                // 200 OKをデフォルトで選択
                comboBox_Send_StatusCode.SelectedIndex = comboBox_Send_StatusCode.FindString("200 OK"); // なければ無選択で良い
            }

            // BodyデータのDragDrop
            {
                TextBox[] ddTarget = { textBox_Send_Body, textBox_stdout };
                foreach (TextBox textbox in ddTarget)
                {
                    textbox.AllowDrop = true;
                    textbox.DragEnter += TextBox_DragEnter;
                    textbox.DragDrop += TextBox_DragDrop;
                }
            }
        }

        // 表示項目の更新
        private void ViewUpdate()
        {
            // header
            {
                bool isAuto = radioButton_Send_Header_Auto.Checked;
                comboBox_Send_StatusCode.Enabled = isAuto;
                textBox_Send_Manual_StatusLine.Enabled = !isAuto;
                textBox_Send_Manual_ContentLen.Enabled = !isAuto;
                textBox_Send_Manual_ContentType.Enabled = !isAuto;
            }
        }
        private void radioButton_Send_Header_Auto_CheckedChanged(object sender, EventArgs e)
        {
            ViewUpdate();
        }
        private string textBoxSendBody_HexRaw_ = string.Empty;
        private void radioButton_Send_Body_TextHex_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radiobutton = (RadioButton)sender;

            // Hex -> Text
            if ((radiobutton == radioButton_Send_Body_Text) && (radiobutton.Checked))
            {
                // 控え
                textBoxSendBody_HexRaw_ = textBox_Send_Body.Text;

                // Hex -> Text
                byte[] bytedata = HexStringToByteArray(textBoxSendBody_HexRaw_);
                textBox_Send_Body.Text = System.Text.Encoding.UTF8.GetString(bytedata);
            }

            // Text -> Hex
            if ((radiobutton == radioButton_Send_Body_Hex) && (radiobutton.Checked))
            {
                // Text -> Hex
                byte[] bytedata = Encoding.UTF8.GetBytes(textBox_Send_Body.Text);

                byte[] bytedata_old = HexStringToByteArray(textBoxSendBody_HexRaw_);
                if (ByteArrayToHexString(bytedata) == ByteArrayToHexString(bytedata_old))
                {
                    // 控えと一致していれば以前の控えに戻す
                    textBox_Send_Body.Text = textBoxSendBody_HexRaw_;
                }
                else
                {
                    // 異なれば変換結果を新しいものとして表示する
                    textBox_Send_Body.Text = ByteArrayToHexString(bytedata);
                }
            }
        }
        private void TextBox_DragEnter(object sender, DragEventArgs e)
        {
            // カーソル
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }
        private void TextBox_DragDrop(object sender, DragEventArgs e)
        {
            // ファイルの一覧を取得
            string[] filename = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (filename.Length <= 0) { return; }

            TextBox texttarget = sender as TextBox;
            if (texttarget == null) { return; }

            // TODO
            byte[] bytedata = ReadFileAll(filename[0]);

            if ((texttarget == textBox_Send_Body) && (radioButton_Send_Body_Hex.Checked))
            {
                // hex
                texttarget.Text = ByteArrayToHexString(bytedata);
                // 控え
                textBoxSendBody_HexRaw_ = texttarget.Text;
            }
            else
            {
                // text
                texttarget.Text = System.Text.Encoding.UTF8.GetString(bytedata);
            }
        }

        // ----------------
        // アクション
        // ----------------

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

        // ----------------
        // その他
        // ----------------

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

        // バイト配列１６進数文字列変換
        private static string ByteArrayToHexString(byte[] bytedata)
        {
            return BitConverter.ToString(bytedata);
        }

        // ファイルを開いてバイナリで読み込む
        private byte[] ReadFileAll(string pathSource)
        {
            byte[] bytes = new byte[0];
            try
            {
                using (FileStream fsSource = new FileStream(pathSource,
                    FileMode.Open, FileAccess.Read))
                {

                    // Read the source file into a byte array.
                    bytes = null;
                    bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);

                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;

                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;
                }
            }
            catch (FileNotFoundException ioEx)
            {
                Console.WriteLine(ioEx.Message);
            }

            return bytes;
        }
    }
}
