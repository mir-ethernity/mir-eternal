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

        int TotalAccounts { get; set; }
        int TotalNewAccounts { get; set; }
        int TotalTickets { get; set; }

        long TotalBytesReceived { get; set; }
        long TotalBytesSended { get; set; }
    }
}
