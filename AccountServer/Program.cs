using System;
using System.Threading;
using System.Windows.Forms;

namespace AccountServer
{
	// Token: 0x02000003 RID: 3
	internal static class Program
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00003634 File Offset: 0x00001834
		[STAThread]
		private static void Main()
		{
			bool flag;
			Program.myMutex = new Mutex(false, "CY_LoginServer_Mutex", out flag);
			if (flag)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new MainForm());
				return;
			}
			MessageBox.Show("服务器已经在运行中");
			Environment.Exit(0);
		}

		// Token: 0x04000021 RID: 33
		private static Mutex myMutex;
	}
}
