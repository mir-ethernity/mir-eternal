using ClientPacketSnifferApp.Properties;
using PacketDotNet;
using SharpPcap;
using SharpPcap.LibPcap;
using System.ComponentModel;

namespace ClientPacketSnifferApp
{
    public partial class FMain : Form
    {
        private List<LibPcapLiveDevice> _devices;
        private LibPcapLiveDevice? _selectedDevice = null;
        private BackgroundWorker _backgroundWorker;
        private MemoryStream? _captureBuffer = null;
        private bool _backgroundWorkerRunning = false;

        public bool Capturing { get; set; }
        public int TotalClientPackets { get; private set; }
        public int TotalServerPackets { get; private set; }

        public FMain()
        {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            FormClosing += FMain_FormClosing;
            _devices = CaptureDeviceList.Instance
                .OfType<LibPcapLiveDevice>()
                .ToList();

            OpenSelectDevice();
            UpdateUI();
        }

        private void FMain_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (!Capturing) return;

            if (Capturing && _captureBuffer?.Length == 0)
            {
                ClearData();
                return;
            }

            if (MessageBox.Show("You are in the middle of a packet capture, are you sure you want to close the application and discard the captured data?", "Discard Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearData();
                return;
            }

            e.Cancel = true;
        }

        private void OpenSelectDevice()
        {
            var form = new FDeviceSelector(_devices);

            if (form.ShowDialog() != DialogResult.OK)
                return;

            _selectedDevice = form.SelectedDevice;

            UpdateUI();
        }

        private void UpdateUI()
        {
            ButtonCaptureToggle.Enabled = _selectedDevice != null;
            ButtonCaptureToggle.ForeColor = Capturing ? Color.Red : Color.Green;
            ButtonCaptureToggle.Text = Capturing ? "Stop capture" : "Start capture";
            LabelSelectedDevice.Text = _selectedDevice != null ? _selectedDevice.Description : "Select device";
            LabelCaptureSize.Text = "Capture Size: " + (_captureBuffer != null ? _captureBuffer.Length.ToString() : "0");
            LabelClientPackets.Text = "Client Packets: " + TotalClientPackets;
            LabelServerPackets.Text = "Server Packets: " + TotalServerPackets;
            ButtonChangeDevice.Enabled = !Capturing;
        }

        private void ButtonCaptureToggle_Click(object sender, EventArgs e)
        {
            Capturing = !Capturing;

            if (Capturing)
            {
                _backgroundWorker = new BackgroundWorker();
                _backgroundWorker.DoWork += BackgroundWorker_DoWork;
                _backgroundWorker.RunWorkerAsync();
            }
            else
            {
                Capturing = false;
                _selectedDevice?.Close();
                SaveCapture();
            }

            UpdateUI();
        }

        private void SaveCapture()
        {
            try
            {
                ButtonCaptureToggle.Enabled = false;

                if (_captureBuffer == null) return;
                if (_captureBuffer.Length == 0) return;

                var timeout = DateTime.Now.AddSeconds(10);

                while (_backgroundWorkerRunning && timeout >= DateTime.Now)
                    Thread.Sleep(100);

                var saveDialog = new SaveFileDialog();
                saveDialog.FileName = $"CapturePackets_{DateTime.UtcNow.ToString("yyyyMMddHHmmss")}.raw";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllBytes(saveDialog.FileName, _captureBuffer.ToArray());
                    ClearData();
                }
                else
                {
                    if (MessageBox.Show("Are you sure you want to delete the capture you made?", "Save Capture", MessageBoxButtons.YesNo) != DialogResult.Yes)
                        SaveCapture();
                    else
                        ClearData();
                }
            }
            finally
            {
                UpdateUI();
            }

        }

        private void ClearData()
        {
            Capturing = false;
            _selectedDevice?.Close();
            _captureBuffer?.Dispose();
            _captureBuffer = null;
            PacketsList.Items.Clear();
            TotalClientPackets = 0;
            TotalServerPackets = 0;
            UpdateUI();
        }

        private void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
        {
            var device = _selectedDevice;
            if (device == null) return;

            _captureBuffer?.Dispose();
            _captureBuffer = new MemoryStream();

            device.Open(new DeviceConfiguration
            {
                Mode = DeviceModes.Promiscuous,
                ReadTimeout = Settings.Default.ReadTimeout,
            });

            _backgroundWorkerRunning = true;

            try
            {
                while (Capturing)
                {
                    var status = device.GetNextPacket(out PacketCapture packet);
                    if (!Capturing) break;
                    if (status != GetPacketStatus.PacketRead) continue;

                    var rawCapture = packet.GetPacket();
                    var p = Packet.ParsePacket(rawCapture.LinkLayerType, rawCapture.Data);
                    if (p.PayloadPacket is not IPv4Packet ipv4packet) continue;

                    if (
                        ipv4packet.PayloadPacket is not TransportPacket transportPacket
                        || transportPacket.PayloadData == null
                        || transportPacket.PayloadData.Length == 0
                    ) continue;

                    if (transportPacket is not TcpPacket)
                        continue;

                    var isGame = transportPacket.SourcePort == Settings.Default.ListenPort || transportPacket.DestinationPort == Settings.Default.ListenPort;
                    if (!isGame) continue;

                    var packetFromClient = transportPacket.DestinationPort == Settings.Default.ListenPort;

                    WriteData(DateTime.Now, packetFromClient, transportPacket.PayloadData);
                }
            }
            finally
            {
                _backgroundWorkerRunning = false;
            }
        }

        private void WriteData(DateTime now, bool packetFromClient, byte[] payloadData)
        {
            if (_captureBuffer == null) return;

            var bw = new BinaryWriter(_captureBuffer);

            bw.Write(now.ToFileTimeUtc());
            bw.Write(packetFromClient);
            bw.Write(payloadData.Length);
            bw.Write(payloadData);

            if (packetFromClient)
                TotalClientPackets++;
            else
                TotalServerPackets++;

            Invoke(() =>
            {
                PacketsList.Items.Add($"[{now.ToShortTimeString()}] ({(packetFromClient ? "C-S" : "S-C")}) {BitConverter.ToString(payloadData)}");
                PacketsList.SelectedIndex = PacketsList.Items.Count - 1;
                UpdateUI();
            });
        }

        private void ButtonChangeDevice_Click(object sender, EventArgs e)
        {
            OpenSelectDevice();
        }

        private void ButtonConfig_Click(object sender, EventArgs e)
        {
            if (Capturing)
            {
                MessageBox.Show("Stop capture packets before change config");
                return;
            }

            using var form = new FConfig();
            form.ShowDialog();
        }
    }
}