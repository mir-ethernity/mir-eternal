using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mir3DClientEditor.Dialogs
{
    public partial class CustomMessageBox : Form
    {
        public string? ButtonIdPressed { get; private set; } = null;
        private CustomMessageBox(string caption, string message, IEnumerable<CustomMessageBoxButton> buttons)
        {
            InitializeComponent();
            FormClosing += CustomMessageBox_FormClosing;
            Text = caption;
            MessageLabel.Text = message;

            foreach (var button in buttons)
            {
                var btn = new Button();
                btn.Text = button.Label;
                btn.Name = $"{button.Id}Button";
                btn.Tag = button.Id;
                btn.Click += Btn_Click;
                ButtonsPanel.Controls.Add(btn);
            }
        }

        private void CustomMessageBox_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            ButtonIdPressed = (string)((Button)sender).Tag;
            Dispose();
        }

        public static string? Show(string caption, string message, IEnumerable<CustomMessageBoxButton> buttons)
        {
            var dialog = new CustomMessageBox(caption, message, buttons);

            var completed = dialog.ShowDialog();

            if (completed == DialogResult.OK)
                return dialog.ButtonIdPressed;

            return null;
        }
    }
}
