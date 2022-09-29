using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Services
{
    public interface IStatsService
    {
        event EventHandler StatsChanged;

        uint TotalAccounts { get; set; }
        uint TotalNewAccounts { get; set; }
        uint TotalTickets { get; set; }
        long TotalBytesReceived { get; set; }
        long TotalBytesSended { get; set; }
    }
}
