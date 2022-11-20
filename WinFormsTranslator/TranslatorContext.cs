using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsTransltor;

namespace WinFormsTranslator
{

    public static class TranslatorContext
    {
        public static TranslationService? Translations { get; private set; } = null;

        public static async void Initialize()
        {
            Translations = new TranslationService();
            await Translations.Initialize();
        }

        public static T Attach<T>(T control) where T : Control
        {
            EnsureInitialized();
            Translations?.Attach(control);
            return control;
        }

        public static T Detach<T>(T control) where T : Control
        {
            EnsureInitialized();
            Translations?.Detach(control);
            return control;
        }

        public static string GetString(string key, string[]? args = null, string defaultTranslation = "") 
        {
            EnsureInitialized();
            return Translations?.GetString(key, args, defaultTranslation) ?? string.Empty;
        }

        public static string GetString<T>(T control, string property, string[]? args = null, string defaultTranslation = "") where T : Control
        {
            EnsureInitialized();
            return Translations?.GetString(control, property, args, defaultTranslation) ?? string.Empty;
        }

        private static void EnsureInitialized()
        {
            if (Translations == null) throw new ApplicationException($"TranslatorContext not initialized");
        }
    }
}
