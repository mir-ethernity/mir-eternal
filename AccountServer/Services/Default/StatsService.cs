using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountServer.Services.Default
{
    public class StatsService : IStatsService
    {
        private int _totalAccounts = 0;
        private int _totalNewAccounts = 0;
        private int _totalTickets = 0;
        private long _totalBytesReceived = 0;
        private long _totalBytesSeneded = 0;

        public event EventHandler StatsChanged;

        public int TotalAccounts { get => _totalAccounts; set { _totalAccounts = value; OnStatsChanged(); } }
        public int TotalNewAccounts { get => _totalNewAccounts; set { _totalNewAccounts = value; OnStatsChanged(); } }
        public int TotalTickets { get => _totalTickets; set { _totalTickets = value; OnStatsChanged(); } }
        public long TotalBytesReceived { get => _totalBytesReceived; set { _totalBytesReceived = value; OnStatsChanged(); } }
        public long TotalBytesSended { get => _totalBytesSeneded; set { _totalBytesSeneded = value; OnStatsChanged(); } }


        private void OnStatsChanged()
        {
            StatsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
