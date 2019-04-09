using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSSLServer
{
    public class UserAppMqttBroker : IUserApp
    {
        // 
        // コンストラクタ
        // 
        public UserAppMqttBroker() { }

        // 受信したパケットに応じて、応答パケット（送信パケット）を構築する
        public void Proc(byte[] rcvbytes, out byte[] sndbytes)
        {
            RcvType rcvType = JudgeType(rcvbytes);
            sndbytes = BuildPacket(rcvType, rcvbytes);
        }

        private enum RcvType { MQTT_CON, MQTT_SUB, OTHER };
        private RcvType JudgeType(byte[] rcvbytes)
        {
            // ラフに
            int header = rcvbytes[0];
            int len = rcvbytes[1];
            if ((header == 0x10) && (len + 2 == rcvbytes.Length))
            {
                return RcvType.MQTT_CON;
            }
            if ((header == 0x82) && (len + 2 == rcvbytes.Length))
            {
                return RcvType.MQTT_SUB;
            }
            return RcvType.OTHER;
        }

        private byte[] BuildPacket(RcvType rcvType, byte[] rcvbytes)
        {
            if (rcvType == RcvType.MQTT_CON)
            {
                byte[] con_ack = new byte[] { 0x20, 0x02, 0x00, 0x00 };
                return con_ack;
            }
            if (rcvType == RcvType.MQTT_SUB)
            {
                byte[] sub_ack = new byte[] { 0x90, 0x03, 0x00, 0x03, 0x00 };
                sub_ack[2] = rcvbytes[2];
                sub_ack[3] = rcvbytes[3];
                return sub_ack;
            }
            return new byte[] { };
        }

    }
}
