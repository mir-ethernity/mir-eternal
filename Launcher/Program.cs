using System;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
    internal static class Program
    {
        public static Mutex MyMutex
        {
            get => Program.myMutex;
            set => Program.myMutex = value;
        }
        private static Mutex myMutex;

        [STAThread]
        private static void Main()
        {
            bool createdNew;
            Program.myMutex = new Mutex(false, "CY_Launcher_Mutex", out createdNew);
            if (createdNew || 1 == 1)
            {
                Application.EnableVisualStyles();
                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run((Form)new MainForm());
            }
            else
            {
                int num = (int)MessageBox.Show("Launcher Already Running");
                Environment.Exit(0);
            }
        }


    }
}
