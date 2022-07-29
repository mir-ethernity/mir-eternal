using System;
using System.Threading;
using System.Windows.Forms;

namespace AccountServer
{	
	internal static class Program
	{		
		[STAThread]
		private static void Main()
		{
			bool flag;
			Program.myMutex = new Mutex(false, "CY_LoginServer_Mutex", out flag);
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
		
		private static Mutex myMutex;
	}
}
