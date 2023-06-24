using Microsoft.VisualBasic.Devices;
using System.Threading;

namespace ContentEditor
{
    public partial class FMain : Form
    {
        public Point SelectPosition { get; private set; }
        public float ZoomFactor { get; private set; } = 1;
        public MapInfo Map { get; private set; }
        public Bitmap MapOriginalBitmap { get; private set; }

        public FMain()
        {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            KeyUp += FMain_KeyUp;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseClick += PictureBox1_MouseClick;

            this.set20ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set40ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set60ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set80ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set100ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set120ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set140ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set160ToolStripMenuItem.Click += SetZoomMenuItem_Click;
            this.set180ToolStripMenuItem.Click += SetZoomMenuItem_Click;

            LoadData();
            PaintOnPictureBox();

            Width = pictureBox1.Image.Width;
            Height = pictureBox1.Image.Height;
        }

        private void SetZoomMenuItem_Click(object? sender, EventArgs e)
        {

            if (sender == set20ToolStripMenuItem)
                ZoomFactor = 0.20f;
            else if (sender == set40ToolStripMenuItem)
                ZoomFactor = 0.40f;
            else if (sender == set60ToolStripMenuItem)
                ZoomFactor = 0.60f;
            else if (sender == set80ToolStripMenuItem)
                ZoomFactor = 0.80f;
            else if (sender == set100ToolStripMenuItem)
                ZoomFactor = 1f;
            else if (sender == set120ToolStripMenuItem)
                ZoomFactor = 1.20f;
            else if (sender == set140ToolStripMenuItem)
                ZoomFactor = 1.40f;
            else if (sender == set160ToolStripMenuItem)
                ZoomFactor = 1.60f;
            else if (sender == set180ToolStripMenuItem)
                ZoomFactor = 1.80f;

            PaintOnPictureBox();
        }

        private CancellationTokenSource? keyUpPainCanceler = null;
        private void FMain_KeyUp(object? sender, KeyEventArgs e)
        {
            keyUpPainCanceler?.Cancel();

            keyUpPainCanceler = new CancellationTokenSource();

            var isControlPressed = (e.KeyData & Keys.Control) == Keys.Control;

            if (isControlPressed && (e.KeyData & Keys.Add) == Keys.Add)
            {
                ZoomFactor += 0.1f;
                PaintOnPictureBox(keyUpPainCanceler.Token);
            }
            if (isControlPressed && (e.KeyData & Keys.Subtract) == Keys.Subtract)
            {
                ZoomFactor -= 0.1f;
                PaintOnPictureBox(keyUpPainCanceler.Token);
            }
        }

        private void PictureBox1_MouseClick(object? sender, MouseEventArgs e)
        {
            SelectPosition = new Point((int)(e.Location.X / ZoomFactor), (int)(e.Location.Y / ZoomFactor));
            PaintOnPictureBox();
        }

        private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
        {
            lblMouseCoords.Text = $"X:{e.X}, Y:{e.Y}";
        }

        public void LoadData()
        {
            Map = new MapInfo();

            // var fileContent = File.ReadAllBytes("C:\\Mir3D\\Clean\\Mir3D\\Database\\System\\GameMap\\Terrains\\0245-魔龙殿.terrain");
            var fileContent = File.ReadAllBytes("C:\\Mir3D\\Clean\\Mir3D\\Database\\System\\GameMap\\Terrains\\0175-祖玛寺长廊.terrain");

            using var ms = new MemoryStream(fileContent);
            using var br = new BinaryReader(ms);

            var sx = br.ReadInt32();
            var sy = br.ReadInt32();
            var ex = br.ReadInt32();
            var ey = br.ReadInt32();
            var hx = br.ReadInt32();
            var hy = br.ReadInt32();

            Map.Width = ex - sx;
            Map.Height = ey - sy;

            Map.Cells = new CellInfo[Map.Width, Map.Height];

            for (var x = 0; x < Map.Width; x++)
            {
                for (var y = 0; y < Map.Height; y++)
                {
                    var cell = Map.Cells[x, y] = new CellInfo();

                    var cellFlag = br.ReadInt32();
                    var terrainHeight = (short)(cellFlag & 65535U) - 30U;

                    cell.IsBlocked = (cellFlag & 268435456U) != 268435456U;
                    cell.IsFreeZone = (cellFlag & 131072U) == 131072U;
                    cell.IsSafeZone = (cellFlag & 262144U) == 262144U;
                    cell.IsStallArea = (cellFlag & 1048576U) == 1048576U;
                    cell.IsWalkable1 = (cellFlag & 4194304U) == 4194304U;
                    cell.IsWalkable2 = (cellFlag & 8388608U) == 8388608U;
                }
            }

            var bitmap = new Bitmap(Map.Width, Map.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            for (var x = 0; x < Map.Width; x++)
            {
                for (var y = 0; y < Map.Height; y++)
                {
                    var cell = Map.Cells[x, y];

                    if (cell.IsBlocked)
                        bitmap.SetPixel(x, y, Color.Orange);
                    else if (cell.IsSafeZone)
                        bitmap.SetPixel(x, y, Color.Blue);
                    else if (cell.IsFreeZone)
                        bitmap.SetPixel(x, y, Color.Green);
                    else if (cell.IsStallArea)
                        bitmap.SetPixel(x, y, Color.Orange);
                    else if (cell.IsWalkable1)
                        bitmap.SetPixel(x, y, Color.White);
                    else if (cell.IsWalkable2)
                        bitmap.SetPixel(x, y, Color.WhiteSmoke);
                    else
                        bitmap.SetPixel(x, y, Color.Red);
                }
            }

            MapOriginalBitmap = bitmap;
        }

        public void PaintOnPictureBox(CancellationToken cancellationToken = default)
        {
            pictureBox1.Image = ScaleImage(
                MapOriginalBitmap, 
                (int)(MapOriginalBitmap.Width * ZoomFactor), 
                (int)(MapOriginalBitmap.Height * ZoomFactor)
            );

            using (var gr = Graphics.FromImage(pictureBox1.Image))
            {
                if (SelectPosition != Point.Empty)
                {
                    var scaledPositionX = SelectPosition.X * ZoomFactor;
                    var scaledPositionY = SelectPosition.Y * ZoomFactor;
                    var size = 4 * ZoomFactor;

                    gr.DrawRectangle(new Pen(Color.Red), scaledPositionX - size / 2, scaledPositionY - size / 2, size, size);
                    gr.FillRectangle(new SolidBrush(Color.FromArgb(50, Color.Red)), scaledPositionX - size / 2, scaledPositionY - size / 2, size, size);
                }
            }

            ddbZoom.Text = $"Zoom: {ZoomFactor * 100}%";
            lblSelectedPoint.Text = $"Selected ({(SelectPosition == Point.Empty ? "N/a" : $"X:{SelectPosition.X},Y:{SelectPosition.Y}")})";

            Refresh();
        }

        public static Image ScaleImage(Image image, int newWidth, int newHeight)
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
    }
}