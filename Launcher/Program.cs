using System;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
	// Token: 0x02000004 RID: 4
	internal static class Program
	{
		// Token: 0x0600001C RID: 28 RVA: 0x00007220 File Offset: 0x00005420
		[STAThread]
		private static void Main()
		{
            Program.myMutex = new Mutex(false, "CY_Launcher_Mutex", out bool flag);
            if (flag)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
				return;
			}
			MessageBox.Show("The logger is already running");
			Environment.Exit(0);
		}

        // Token: 0x04000036 RID: 54
        private static Mutex myMutex;

        public static Mutex MyMutex { get => myMutex; set => myMutex = value; }
    }
}
