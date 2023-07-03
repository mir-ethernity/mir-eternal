using ContentEditor.Models;
using ContentEditor.Properties;
using ContentEditor.Services;
using Microsoft.VisualBasic.Devices;
using Sunny.UI;
using System.Threading;
using System.Windows.Forms;
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
        public Bitmap GuardsBitmap { get; private set; }
        public Bitmap AreasBitmap { get; private set; }
        public Bitmap GatesBitmap { get; private set; }
        public Bitmap MonstersBitmap { get; private set; }

        public IDatabaseManager Database { get; }
        public Point? Moving { get; private set; } = null;

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
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseUp += PictureBox1_MouseUp;

            LayerAreas.CheckedChanged += RefreshPaint_Event;
            LayerGuards.CheckedChanged += RefreshPaint_Event;
            LayerGates.CheckedChanged += RefreshPaint_Event;
            LayerSpawns.CheckedChanged += RefreshPaint_Event;

            MapAttrFreeZone.CheckedChanged += RedrawTerrain_Event;
            MapAttrSafeZone.CheckedChanged += RedrawTerrain_Event;
            MapAttrStallArea.CheckedChanged += RedrawTerrain_Event;

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
            RenderAreasBitmap();
            RenderGuardsBitmap();
            RenderGatesBitmap();
            RenderMonstersBitmap();
            PaintOnPictureBox();
        }

        private void PictureBox1_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                Moving = null;
        }

        private void PictureBox1_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
                Moving = e.Location;
        }

        private void RefreshPaint_Event(object? sender, EventArgs e)
        {
            PaintOnPictureBox();
        }

        private void RedrawTerrain_Event(object? sender, EventArgs e)
        {
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
            if (Terrain == null) return;

            if (e.Button == MouseButtons.Left)
            {
                SelectPosition = new Point(
                    Terrain.StartX + (int)(e.Location.X / ZoomFactor),
                    Terrain.StartY + (int)(e.Location.Y / ZoomFactor)
                );
                PaintOnPictureBox();
            }
        }

        private void PictureBox1_MouseMove(object? sender, MouseEventArgs e)
        {
            if (Terrain == null) return;
            lblMouseCoords.Text = $"X:{Terrain.StartX + e.X}, Y:{Terrain.StartY + e.Y}";

            if (Moving != null)
            {
                var diff = new Point((e.Location.X - Moving.Value.X) / 2, (e.Location.Y - Moving.Value.Y) / 2);

                if (uiSplitContainer1.Panel2.HorizontalScroll.Value - diff.X >= 0)
                    uiSplitContainer1.Panel2.HorizontalScroll.Value -= diff.X;

                if (uiSplitContainer1.Panel2.VerticalScroll.Value - diff.Y >= 0)
                    uiSplitContainer1.Panel2.VerticalScroll.Value -= diff.Y;

                Moving = e.Location;
            }

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
                        bitmap.SetPixel(x, y, MapAttrSafeZone.Checked ? Color.Blue : Color.LightGray);
                    else if (cell.IsFreeZone)
                        bitmap.SetPixel(x, y, MapAttrFreeZone.Checked ? Color.Green : Color.LightGray);
                    else if (cell.IsStallArea)
                        bitmap.SetPixel(x, y, MapAttrStallArea.Checked ? Color.Orange : Color.LightGray);
                    else if (cell.IsWalkable1)
                        bitmap.SetPixel(x, y, Color.LightGray);
                    else if (cell.IsWalkable2)
                        bitmap.SetPixel(x, y, Color.LightGray);
                    else
                        bitmap.SetPixel(x, y, Color.Red);
                }
            }

            TerrainBitmap = bitmap;
        }

        private void RenderGatesBitmap()
        {
            if (Terrain == null || Map.Areas.Count == 0)
            {
                GatesBitmap = new Bitmap(1, 1);
                return;
            }

            var bitmap = new Bitmap(Terrain.Width, Terrain.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.Clear(Color.Transparent);

                foreach (var gate in Map.OutgoingGates)
                {
                    var size = 4;
                    gr.DrawRectangle(
                        new Pen(Color.Red),
                        gate.FromCoords.X - Terrain.StartX - size / 2,
                        gate.FromCoords.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                    gr.FillRectangle(
                        new SolidBrush(Color.FromArgb(50, Color.Red)),
                        gate.FromCoords.X - Terrain.StartX - size / 2,
                        gate.FromCoords.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                }

                foreach (var gate in Map.IncomingGates)
                {
                    var size = 4;
                    gr.DrawRectangle(
                        new Pen(Color.DeepPink),
                        gate.FromCoords.X - Terrain.StartX - size / 2,
                        gate.FromCoords.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                    gr.FillRectangle(
                        new SolidBrush(Color.FromArgb(50, Color.DeepPink)),
                        gate.FromCoords.X - Terrain.StartX - size / 2,
                        gate.FromCoords.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                }
            }

            GatesBitmap = bitmap;
        }


        private void RenderAreasBitmap()
        {
            if (Terrain == null || Map.Areas.Count == 0)
            {
                AreasBitmap = new Bitmap(1, 1);
                return;
            }

            var bitmap = new Bitmap(Terrain.Width, Terrain.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.Clear(Color.Transparent);

                foreach (var area in Map.Areas)
                {
                    gr.DrawRectangle(
                        new Pen(Color.Aqua),
                        area.FromCoords.X - Terrain.StartX - area.AreaRadius,
                        area.FromCoords.Y - Terrain.StartY - area.AreaRadius,
                        area.AreaRadius * 2,
                        area.AreaRadius * 2
                    );
                    gr.FillRectangle(
                        new SolidBrush(Color.FromArgb(50, Color.Aqua)),
                        area.FromCoords.X - Terrain.StartX - area.AreaRadius,
                        area.FromCoords.Y - Terrain.StartY - area.AreaRadius,
                        area.AreaRadius * 2,
                        area.AreaRadius * 2
                    );

                    var textSize = gr.MeasureString(area.RegionName, SystemFonts.MessageBoxFont);

                    gr.DrawString(
                        area.RegionName,
                        SystemFonts.MessageBoxFont,
                        Color.White,
                        area.FromCoords.X - Terrain.StartX + 1 - textSize.Width / 2,
                        area.FromCoords.Y - Terrain.StartY + 1 - textSize.Height / 2
                    );
                }
            }

            AreasBitmap = bitmap;
        }

        private void RenderMonstersBitmap()
        {
            if (Terrain == null || Map.Monsters.Count == 0)
            {
                MonstersBitmap = new Bitmap(1, 1);
                return;
            }

            var bitmap = new Bitmap(Terrain.Width, Terrain.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.Clear(Color.Transparent);

                foreach (var monster in Map.Monsters)
                {
                    gr.DrawRectangle(
                        new Pen(Color.DarkRed),
                        monster.FromCoords.X - Terrain.StartX - monster.AreaRadius,
                        monster.FromCoords.Y - Terrain.StartY - monster.AreaRadius,
                        monster.AreaRadius * 2,
                        monster.AreaRadius * 2
                    );
                    gr.FillRectangle(
                        new SolidBrush(Color.FromArgb(50, Color.DarkRed)),
                        monster.FromCoords.X - Terrain.StartX - monster.AreaRadius,
                        monster.FromCoords.Y - Terrain.StartY - monster.AreaRadius,
                        monster.AreaRadius * 2,
                        monster.AreaRadius * 2
                    );

                    var spawnInfo = new List<string>();

                    foreach (var spawn in monster.Spawns)
                        spawnInfo.Add($"* {spawn.MonsterName} (Count:{spawn.SpawnCount}, Revival Interval: {spawn.RevivalInterval})");

                    gr.DrawString(
                        string.Join("\n", spawnInfo),
                        SystemFonts.MessageBoxFont,
                        Color.BlueViolet,
                        monster.FromCoords.X - Terrain.StartX + 1,
                        monster.FromCoords.Y - Terrain.StartY + 1
                    );
                }
            }

            MonstersBitmap = bitmap;
        }

        private void RenderGuardsBitmap()
        {
            if (Terrain == null || Map.Guards.Count == 0)
            {
                GuardsBitmap = new Bitmap(1, 1);
                return;
            }

            var bitmap = new Bitmap(Terrain.Width, Terrain.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (var gr = Graphics.FromImage(bitmap))
            {
                gr.Clear(Color.Transparent);

                foreach (var guard in Map.Guards)
                {
                    var size = 4;
                    gr.DrawRectangle(
                        new Pen(Color.OrangeRed),
                        guard.FromCoords.X - Terrain.StartX - size / 2,
                        guard.FromCoords.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                    gr.FillRectangle(
                        new SolidBrush(Color.FromArgb(50, Color.OrangeRed)),
                        guard.FromCoords.X - Terrain.StartX - size / 2,
                        guard.FromCoords.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                }
            }

            GuardsBitmap = bitmap;
        }

        public void PaintOnPictureBox(CancellationToken cancellationToken = default)
        {
            if (Terrain == null) return;

            var surface = new Bitmap(Terrain.Width, Terrain.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);

            using (var gr = Graphics.FromImage(surface))
            {
                gr.Clear(Color.Black);
                gr.DrawImage(TerrainBitmap, Point.Empty);

                if (LayerAreas.Checked) gr.DrawImage(AreasBitmap, Point.Empty);
                if (LayerGuards.Checked) gr.DrawImage(GuardsBitmap, Point.Empty);
                if (LayerGates.Checked) gr.DrawImage(GatesBitmap, Point.Empty);
                if (LayerSpawns.Checked) gr.DrawImage(MonstersBitmap, Point.Empty);

                if (SelectPosition != Point.Empty)
                {
                    var size = 4;
                    gr.DrawRectangle(
                        new Pen(Color.Red),
                        SelectPosition.X - Terrain.StartX - size / 2,
                        SelectPosition.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                    gr.FillRectangle(
                        new SolidBrush(Color.FromArgb(50, Color.Red)),
                        SelectPosition.X - Terrain.StartX - size / 2,
                        SelectPosition.Y - Terrain.StartY - size / 2,
                        size,
                        size
                    );
                }
            }

            pictureBox1.Image = ScaleImage(
                surface,
                (int)(TerrainBitmap.Width * ZoomFactor),
                (int)(TerrainBitmap.Height * ZoomFactor)
            );

            ddbZoom.Text = TranslatorContext.GetString("fmapeditor.statusstrip1.ddbzoom.text", new string[] { (ZoomFactor * 100).ToString() }, $"Zoom: %s%");
            lblSelectedPoint.Text = TranslatorContext.GetString("fmapeditor.statusstrip1.lblselectedpoint.text", new string[] { SelectPosition.X.ToString(), SelectPosition.Y.ToString() }, "Selected (X:%s,Y:%s)");

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