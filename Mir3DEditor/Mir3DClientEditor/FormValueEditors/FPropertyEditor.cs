using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UELib.Core;
using UELib.Core.Classes.Values;

namespace Mir3DClientEditor.FormValueEditors
{
    public partial class FPropertyEditor : Form
    {
        public UDefaultProperty Property { get; set; }
        public UValueProperty[] Values { get; set; }

        public FPropertyEditor()
        {
            InitializeComponent();
        }

        public static bool Show(UDefaultProperty property)
        {
            var form = new FPropertyEditor();
            form.Property = property;
            form.GridEditor.SetProperty(property);
            form.Text = $"{property.Name}";
            form.ShowDialog();

            return form.GridEditor?.HasPendingChangesToSave ?? false;
        }
    }
}
