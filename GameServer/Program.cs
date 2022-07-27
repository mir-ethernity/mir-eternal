using System;
using System.Threading;
using System.Windows.Forms;

namespace GameServer
{
	
	internal static class Program
	{
		
		[STAThread]
		private static void Main()
		{
			bool flag;
			var myMutex = new Mutex(false, "LOMCN_GameServer_Mutex", out flag);
			if (flag)
			{
				Application.EnableVisualStyles();
				Application.SetHighDpiMode(HighDpiMode.SystemAware);
				Application.SetCompatibleTextRenderingDefault(false);
				
				Application.Run(new MainForm());
				return;
			}
			MessageBox.Show("The server is already up and running");
			Environment.Exit(0);
		}
	}
}
