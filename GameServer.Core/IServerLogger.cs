using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer
{
    public interface IServerLogger
    {
        void AddCommandLog(string message);
        void AddSystemError(string message);
        void AddSystemLog(string message);
        void AddChatLog(string message);
        void AddPacketLog(GamePacket packet, bool incoming);
    }
}
