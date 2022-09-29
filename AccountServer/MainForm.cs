using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using AccountServer.Properties;
using AccountServer.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AccountServer
{
    public partial class MainForm : Form
    {
        private readonly IAppConfiguration _config;
        private readonly SEnvir _envir;
        private readonly IStatsService _stats;
        private readonly ILogger<MainForm> _logger;

        public MainForm(
            SEnvir envir,
            IStatsService stats,
            IAppConfiguration config,
            ILogger<MainForm> logger
        )
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
            _envir = envir ?? throw new ArgumentNullException(nameof(config));
            _stats = stats ?? throw new ArgumentNullException(nameof(stats));
            _logger = logger;

            InitializeComponent();

            _stats.StatsChanged += Envir_StatsChanged;

            txtTSPort.Value = _config.LoginGatePort;
            txtASPort.Value = _config.AccountServerPort;

            UpdateUIStats();
        }

        private void Envir_StatsChanged(object sender, EventArgs e)
        {
            UpdateUIStats();
        }

        private void UpdateUIStats()
        {
            lblRegisteredAccounts.Text = string.Format("Total Accounts: {0}", _stats.TotalAccounts);
            lblNewAccounts.Text = string.Format("New Accounts: {0}", _stats.TotalNewAccounts);
            lblTicketsCount.Text = string.Format("Tickets Generated {0}", _stats.TotalTickets);
            lblBytesReceived.Text = string.Format("Bytes Received: {0}", _stats.TotalBytesReceived);
            lblBytesSend.Text = string.Format("Bytes Sent: {0}", _stats.TotalBytesSended);
        }

        private async void Start_Click(object sender, EventArgs e)
        {
            DisableUI();

            try
            {
                _config.AccountServerPort = (ushort)txtASPort.Value;
                _config.LoginGatePort = (ushort)txtTSPort.Value;

                await _envir.Start();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error ocurred starting server");
                EnableUI();
            }
        }

        private void DisableUI()
        {
            btnStop.Enabled = true;
            btnStart.Enabled = false;
            txtASPort.Enabled = false;
            txtTSPort.Enabled = false;
        }

        private void EnableUI()
        {
            btnStop.Enabled = false;
            btnStart.Enabled = true;
            txtASPort.Enabled = true;
            txtTSPort.Enabled = true;
        }

        private async void Stop_Click(object sender, EventArgs e)
        {
            try
            {
                await _envir.Stop();
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "An error ocurred stopping server");
            }
            EnableUI();
        }

        private void CloseWindow_Click(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Click Yes to ShutDown the AccountServer\r\n\nClick No to Minimise to Tool Bar", "Exit Options", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                MinimizeTray.Visible = false;
                Environment.Exit(0);
                return;
            }
            else if (result == DialogResult.No)
            {
                MinimizeTray.Visible = true;
                Hide();
                if (e != null)
                {
                    e.Cancel = true;
                }
                MinimizeTray.ShowBalloonTip(1000, "", "AccountServer Moved to Tool Bar.", ToolTipIcon.Info);
            }
            else if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }
        private void RestoreWindow_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Visible = true;
                MinimizeTray.Visible = false;
            }
        }
        private void RestoreWindow2_Click(object sender, EventArgs e)
        {
            Visible = true;
            MinimizeTray.Visible = false;
        }
        private async void EndProcess_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to ShutDown the AccountServer?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                await _envir.Stop();
                MinimizeTray.Visible = false;
                Environment.Exit(0);
            }
        }
    }
}
