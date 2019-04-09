using System;

namespace SimpleSSLServer
{
    public interface IUserApp
    {
        // 受信したパケットに応じて、応答パケット（送信パケット）を構築する
        void Proc(byte[] rcvbytes, out byte[] sndbytes);
    }
}
