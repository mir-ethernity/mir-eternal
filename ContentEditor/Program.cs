using ContentEditor.Services;
using WinFormsTranslator;
using WinFormsTransltor;

namespace ContentEditor
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            TranslatorContext.Initialize();
            Application.Run(TranslatorContext.Attach(new FMain()));

        }
    }
}