using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSSLServer
{
    public class UserAppHttpServer : IUserApp
    {
        // 
        // コンストラクタ
        // 
        public UserAppHttpServer() { }

        // 受信したパケットに応じて、応答パケット（送信パケット）を構築する
        public void Proc(byte[] rcvbytes, out byte[] sndbytes)
        {
            MethodType rcvType = JudgeMethod(rcvbytes);
            sndbytes = BuildResponse(rcvType, rcvbytes);
        }

        private enum MethodType { HTTP_GET, HTTP_POST, OTHER };
        private MethodType JudgeMethod(byte[] rcvbytes)
        {
            // ラフに
            string text = System.Text.Encoding.ASCII.GetString(rcvbytes);
            string[] del = {"\r\n"};
            string[] lines = text.Split(del,  StringSplitOptions.None);

            string request_line = lines[0];
            if (request_line.IndexOf("GET") == 0)
            {
                return MethodType.HTTP_GET;
            }
            if (request_line.IndexOf("POST") == 0)
            {
                return MethodType.HTTP_POST;
            }
            return MethodType.OTHER;
        }

        private byte[] BuildResponse(MethodType rcvType, byte[] rcvbytes)
        {
            if (rcvType == MethodType.HTTP_GET)
            {
                int content_len = 5;
                String http_header = String.Format(
                    "HTTP/1.1 200 OK\n" +
                    "Server: xxx\n" +
                    "Content-length: {0}\n" +
                    "\n" + 
                    "abcde", 
                    content_len);
                return Encoding.UTF8.GetBytes(http_header);
            }
            if (rcvType == MethodType.HTTP_POST)
            {
                int content_len = 0;
                String http_header = String.Format(
                    "HTTP/1.1 200 OK\n" +
                    "Server: yyy\n" +
                    "Content-length: {0}\n" +
                    "\n",
                    content_len);
                return Encoding.UTF8.GetBytes(http_header);
            }
            return new byte[] { };
        }

    }
}
