using ContentEditor.Providers;
using ContentEditor.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentEditor.Views
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<UBaseEditor, UserControl>))]
    public abstract class UBaseEditor : UserControl
    {
        public readonly string AttachedTabName;

        public UBaseEditor(string attachedTabName)
        {
            Dock = DockStyle.Fill;
            AttachedTabName = attachedTabName;
        }

        public abstract void ReloadDatabase(IDatabaseManager database);
    }
}
