using Mir3DClientEditor.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mir3DClientEditor.FormValueEditors
{
    [TypeDescriptionProvider(typeof(AbstractControlDescriptionProvider<BaseGridEditorControl, UserControl>))]
    public abstract class BaseGridEditorControl : UserControl
    {
        public abstract bool HasPendingChangesToSave { get; }
        public abstract void SetBuffer(string name, byte[] buffer);
        public abstract byte[] GetBuffer();
    }
}
