using GameServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameServer
{
    public class MainLogger : IServerLogger
    {
        public void AddChatLog(string message)
        {
            MainForm.AddChatLog(message);
        }

        public void AddCommandLog(string message)
        {
            MainForm.AddCommandLog(message);
        }

        public void AddPacketLog(GamePacket packet, bool incoming)
        {
            MainForm.AddPacketLog(packet, incoming);
        }

        public void AddSystemError(string message)
        {
            MessageBox.Show(message);
        }

        public void AddSystemLog(string message)
        {
            MainForm.AddSystemLog(message);
        }
    }
}
