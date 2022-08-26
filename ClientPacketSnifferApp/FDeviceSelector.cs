using SharpPcap.LibPcap;
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
    public partial class FDeviceSelector : Form
    {
        private readonly List<LibPcapLiveDevice> _devices;

        public LibPcapLiveDevice? SelectedDevice = null;

        public FDeviceSelector(List<LibPcapLiveDevice> devices)
        {
            InitializeComponent();
            _devices = devices;
            ButtonSelectDevice.Enabled = false;
            DevicesList.CheckOnClick = true;
            DevicesList.ItemCheck += DevicesList_ItemCheck;
        }

        private void DevicesList_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            var index = e.Index;

            for (var i = 0; i < DevicesList.Items.Count; i++)
                if (i != index && DevicesList.GetItemChecked(i))
                    DevicesList.SetItemChecked(i, i == index);

            ButtonSelectDevice.Enabled = e.NewValue == CheckState.Checked;
        }

        private void DevicesList_MouseClick(object? sender, MouseEventArgs e)
        {

        }

        private void FDeviceSelector_Load(object sender, EventArgs e)
        {
            DevicesList.Items.Clear();
            foreach (var device in _devices)
            {
                var desc = $"{device.Description} {string.Join(", ", device.Addresses.Select(x => x.Addr.ipAddress))}";
                var itemIndex = DevicesList.Items.Add(desc, false);
            }
        }

        private void ButtonSelectDevice_Click(object sender, EventArgs e)
        {
            if (DevicesList.CheckedIndices.Count == 0) return;

            SelectedDevice = _devices[DevicesList.CheckedIndices[0]];

            DialogResult = DialogResult.OK;

            Close();
        }
    }
}
