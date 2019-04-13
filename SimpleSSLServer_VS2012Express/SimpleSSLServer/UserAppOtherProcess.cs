using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSSLServer
{
    public class UserAppOtherProcess : IUserApp
    {
        // 
        // コンストラクタ
        // 
        public UserAppOtherProcess() { }

        // 受信したパケットに応じて、応答パケット（送信パケット）を構築する
        public void Proc(byte[] rcvbytes, out byte[] sndbytes)
        {
            byte[] buf = new byte[10 * 1024]; // TODO 後で調整する
            int readlen = 0;

            // 子プロセス
            ProcessStartInfo psi = new ProcessStartInfo(@"..\..\..\UserAppHttpServer\bin\debug\UserAppHttpServer.exe");

            // 通常のアプリとして起動するためwindowsのシェル機能を無効に、標準入出力を使用する
            psi.UseShellExecute = false;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;

            // 子プロセスを起動
            using (Process process_child = Process.Start(psi))
            {
                // 子プロセスの標準入出力との連携　書き込み(BinaryWriter)／読み込み(BinaryReader)
                System.IO.BinaryWriter writer = new System.IO.BinaryWriter(process_child.StandardInput.BaseStream);
                System.IO.BinaryReader reader = new System.IO.BinaryReader(process_child.StandardOutput.BaseStream);

                var baseStream = reader.BaseStream;

                // バイナリデータを子プロセスの標準入力へ書き込む
                writer.Write(rcvbytes);
                // 標準入力を閉じる（書き込み終了）
                process_child.StandardInput.Close();

                // 子プロセスの終了待ち
                process_child.WaitForExit();

                // バイナリデータを子プロセスの標準入力から読み込む
                readlen = reader.Read(buf, 0, buf.Length);
            }

            sndbytes = new byte[readlen];
            Array.Copy(buf, sndbytes, readlen);
        }
    }

}
