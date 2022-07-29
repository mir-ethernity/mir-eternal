using System;

namespace GameServer
{
    public static class Config
    {
        static Config()
        {

            武斗场时间一 = 13;
            武斗场时间二 = 21;
        }

        public static string 软件注册代码;
        public static string GameDataPath;
        public static string BackupFolder;
        public static ushort GSPort;
        public static ushort TSPort;
        public static ushort MaxPacketCount;
        public static ushort 异常屏蔽时间;
        public static ushort 掉线判定时间;
        public static byte 游戏OpenLevelCommand;
        public static byte NoobSupportCommand等级;
        public static decimal 装备特修折扣;
        public static decimal 怪物额外爆率;
        public static decimal 怪物经验倍率;
        public static ushort 减收益等级差;
        public static decimal 收益减少比率;
        public static ushort 怪物诱惑时长;
        public static ushort 物品归属时间;
        public static ushort 物品清理时间;
        public static byte 武斗场时间一;
        public static byte 武斗场时间二;


        public static byte[] ProtocolKey1 = Convert.FromBase64String("MzU2MjI2MjcwNAAwMQAxZmYyNjA6NjU6ZGY6MDMAVUxTMjEtZDZhMDc1MzIwMDcxNDhmMGJiNzlkZDJmZDg4ODcBgW4GAAAGAAAA");
        public static byte[] ProtocolKey2 = Convert.FromBase64String("MjAyMC0wMS0wMQA=");
        public static byte[] ProtocolKey3 = Convert.FromBase64String("eJztVjtuFEEQ7Z3vMrM7sywfg4zAwtYaYbBAICNBgECWAzKcgwjIOAUEiHOQOOAOEHATEg7AAUzVznvM25ZthEAywZZUqu7q+ndXzYQQwjCcDI3hIeCTrGtbX5c9oUhD2B+EUODM7RdHyDnkx5w576xhYrhiWCHOFvIj4Bhyfj7BfgzZEvgAObj8efgqQd9C76HhC/Bc33PbEBuO2/Bdwl4Bv2OR2YJv5780tFKEM4YZ5HOcXZacr8BGDhsF9BrJW2tUiVwRrS9Ax+lF6FSgV41O4Yd6rHUW3UEiuhni8/rtiqzW2G18TXs/lyBzDnSEmpagnt+mxFCDXwjSfyNr1pwyOeIpJaYUMuTN80m6HFIg46bsWlRfpy3qxXtw3l25e9bJz3ZEp0RMtcRNfcZP5LvQnFZkPZUYG5Fr5Jx5ljhPgM6j/kzeFbEQWd9fk7uswJuAusxQck4i3QS5ZNi3ss8kTuYyt5N395dGtWeecc1ImTvzn2I9vNHr6RtaFztag1beAv2/tvWq4f2w2B+MjfHzbjX2RupOP3pXTwxvSX6U9f1B0sUzkvj3kNtNeQfsVd7dEpbwt/A0LM44f1u3sbeWmvfCvdD1w+esk90KfU9sYr2PtevPgNp3leiwd7T3OMOK3+DoGH5yAr+M9u7rY9L3ZhPp3AndHGBM38PiLKDcDuhjw3Wxrd9FzgydTbQxC/1czKNasM/9e/BG9BxWQ/+dcb7PjlqQc1pn03xGSs1/zaFBRz8k/UytUZM2snEYgc5G8r5Int9C94/IPefb+0jP6W5k3++H3649i3Hb9o/WbG0P8pnxfgwWazKBjyUsYQn/D5xWT/pce3dKvv8lcO56HZ/bQHwVjv7u+ZxM/8DuT3fr1FE=");
    }
}
