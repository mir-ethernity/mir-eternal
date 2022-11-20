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
        public abstract string AttachedTabName { get; }

        public UBaseEditor()
        {
            Dock = DockStyle.Fill;
        }

        public abstract void ReloadDatabase(IDatabaseManager database);
    }
}
