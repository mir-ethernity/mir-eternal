using ContentEditor.Models;
using ContentEditor.Services;
using Microsoft.VisualBasic.Devices;
using Sunny.UI;
using System.Threading;
using WinFormsTranslator;

namespace ContentEditor
{
    public partial class FMapEditor : Form
    {
        public MapInfo Map { get; private set; }
        public TerrainInfo? Terrain { get; private set; }

        public Point SelectPosition { get; private set; }
        public float ZoomFactor { get; private set; } = 1;


        public Bitmap TerrainBitmap { get; private set; }
        public IDatabaseManager Database { get; }

        public FMapEditor(IDatabaseManager database, MapInfo map)
        {
            InitializeComponent();
            Database = database;
            Map = map;
        }

        private async void FMain_Load(object sender, EventArgs e)
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

            Terrain = await Database.Terrain.GetTerrain(Map.TerrainFile);
            RenderTerrainBitmap();
            PaintOnPictureBox();
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

        private void RenderTerrainBitmap()
        {
            if (Terrain == null)
            {
                TerrainBitmap = new Bitmap(1, 1);
                return;
            }

            var bitmap = new Bitmap(Terrain.Width, Terrain.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            for (var x = 0; x < Terrain.Width; x++)
            {
                for (var y = 0; y < Terrain.Height; y++)
                {
                    var cell = Terrain.Cells[x, y];

                    if (cell.IsBlocked)
                        bitmap.SetPixel(x, y, Color.Black);
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

            TerrainBitmap = bitmap;
        }

        public void PaintOnPictureBox(CancellationToken cancellationToken = default)
        {
            pictureBox1.Image = ScaleImage(
                TerrainBitmap,
                (int)(TerrainBitmap.Width * ZoomFactor),
                (int)(TerrainBitmap.Height * ZoomFactor)
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

            ddbZoom.Text = TranslatorContext.GetString("fmapeditor.statusstrip1.ddbzoom.text", new string[] { (ZoomFactor * 100).ToString() }, $"Zoom: %s%");
            lblSelectedPoint.Text = TranslatorContext.GetString("mapeditor.statusstrip1.lblselectedpoint.text", new string[] { SelectPosition.X.ToString(), SelectPosition.Y.ToString() }, "Selected (X:%s,Y:%s)");

            Refresh();
        }

        public static Image ScaleImage(Image image, int newWidth, int newHeight)
        {
            Bitmap newImage = new Bitmap(newWidth, newHeight);
            using (Graphics g = Graphics.FromImage(newImage))
                g.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public static DialogResult ShowEditor(IDatabaseManager database, int mapId)
        {
            var map = database.Map.DataSource.FirstOrDefault(x => x.MapId == mapId);
            if (map == null) return DialogResult.Abort;
            var form = TranslatorContext.Attach(new FMapEditor(database, map));
            return form.ShowDialog();
        }
    }
}