using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserAppHttpServer
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 標準入力から読み込む
            byte[] in_bytes = read_stdin();

            Application.Run(new Form1(in_bytes));
        }

        // 標準入力から読み込む
        private static byte[] read_stdin()
        {
            int readlen = 0;
            byte[] buf = new byte[10 * 1024]; // 適当に最大

            System.IO.Stream stdin = Console.OpenStandardInput();
            while(true)
            {
                byte[] buffer = new byte[8]; // 1回分
                int len = stdin.Read(buffer, 0, buffer.Length);
                if (len == 0)
                {
                    break;
                }
                Array.Copy(buffer, 0, buf,readlen, len);
                readlen += len;
            }

            byte[] ret = new byte[readlen];
            Array.Copy(buf, ret, readlen);
            return ret;
        }
    }
}
