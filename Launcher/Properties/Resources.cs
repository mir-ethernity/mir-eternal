using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Launcher.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
            {
                if (Launcher.Properties.Resources.resourceMan == null)
                    Launcher.Properties.Resources.resourceMan = new ResourceManager("Launcher.Properties.Resources", typeof (Launcher.Properties.Resources).Assembly);
        return Launcher.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => Launcher.Properties.Resources.resourceCulture;
      set => Launcher.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap GameLauncherImage => (Bitmap)Launcher.Properties.Resources.ResourceManager.GetObject(nameof (Launcher), Launcher.Properties.Resources.resourceCulture);
  }
}
