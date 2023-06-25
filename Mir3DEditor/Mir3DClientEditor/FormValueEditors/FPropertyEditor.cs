using Mir3DClientEditor.Dialogs;
using Newtonsoft.Json.Linq;
using Sunny.UI;
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
            if (property.GoodValue is UValueArrayProperty propertyArray && propertyArray.Array.Length > 0 && propertyArray.Array[0] is UValueUnknownProperty)
            {
                if (propertyArray.Array.Length == 0)
                    return false;

                var firstValue = propertyArray.Array[0];

                if (firstValue is UValueUnknownProperty)
                {
                    var result = CustomMessageBox.Show("Resource", "Do you want to export the resource or import it?", new List<CustomMessageBoxButton>() {
                        new CustomMessageBoxButton("export", "Export"),
                        new CustomMessageBoxButton("import", "Import")
                    });

                    var sourceFileFullPath = (property.Owner.Properties.Find(x => x.Name == "SourceFile")?.GoodValue as UValueStrProperty)?.Text ?? "content.raw";
                    var sourceFile = Path.GetFileName(sourceFileFullPath);

                    switch (result)
                    {
                        case "export":
                            var saveFileDialog = new SaveFileDialog();
                            saveFileDialog.FileName = sourceFile;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                var buffer = new byte[propertyArray.Array.Length];
                                for (var i = 0; i < propertyArray.Array.Length; i++)
                                    buffer[i] = ((UValueUnknownProperty)propertyArray.Array[i]).Raw[0];
                                File.WriteAllBytes(saveFileDialog.FileName, buffer);
                            }
                            return false;
                        case "import":
                            var openFileDialog = new OpenFileDialog();
                            openFileDialog.FileName = sourceFile;
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                var buffer = File.ReadAllBytes(openFileDialog.FileName);
                                propertyArray.Array = new UValueProperty[buffer.Length];
                                for (var i = 0; i < buffer.Length; i++)
                                    propertyArray.Array[i] = new UValueUnknownProperty() { Property = property, Raw = new byte[1] { buffer[i] }, OriginalBuffer = new byte[1] { buffer[i] }, Size = 1 };
                                return true;
                            }
                            return false;
                    }
                }

                return false;
            }

            var form = new FPropertyEditor();
            form.Property = property;
            form.GridEditor.SetProperty(property);
            form.Text = $"{property.Name}";
            form.ShowDialog();

            return form.GridEditor?.HasPendingChangesToSave ?? false;
        }
    }
}
