using ClientPacketSnifferApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientPacketSnifferApp
{
    public partial class FConfig : Form
    {
        public FConfig()
        {
            InitializeComponent();
        }

        private void FConfig_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings.Default.ListenPort.ToString();
            textBox2.Text = Settings.Default.ReadTimeout.ToString();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (!ushort.TryParse(textBox1.Text, out var port))
            {
                MessageBox.Show("Invalid port number");
                return;
            }

            if (!int.TryParse(textBox2.Text, out var readTimeout))
            {
                MessageBox.Show("Invalid port number");
                return;
            }

            Settings.Default.ListenPort = port;
            Settings.Default.ReadTimeout = readTimeout;

            Settings.Default.Save();

            Close();
        }
    }
}
