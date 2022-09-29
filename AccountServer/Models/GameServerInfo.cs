using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Models
{
    public class GameServerInfo
    {
        public string Name { get; set; }
        public IPEndPoint InternalAddress { get; set; }
        public IPEndPoint PublicAddress { get; set; }
    }
}
