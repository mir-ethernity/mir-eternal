namespace ClientPacketSnifferApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var t = BitConverter.ToInt32(new byte[] { 46, 179, 0, 0 }, 0);
            var o = BitConverter.ToInt16(new byte[] { 16, 39 }, 0);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FMain());
        }
    }
}