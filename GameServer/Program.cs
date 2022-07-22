using System;
using System.Threading;
using System.Windows.Forms;

namespace GameServer
{
	// Token: 0x0200003E RID: 62
	internal static class Program
	{
		// Token: 0x0600010F RID: 271 RVA: 0x0001C26C File Offset: 0x0001A46C
		[STAThread]
		private static void Main()
		{
			bool flag;
			Program.myMutex = new Mutex(false, "CY_GameServer_Mutex", out flag);
			if (flag)
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				
				Application.Run(new MainForm());
				return;
			}
			MessageBox.Show("The server is already up and running");
			Environment.Exit(0);
		}

		// Token: 0x04000113 RID: 275
		private static Mutex myMutex;
	}
}
