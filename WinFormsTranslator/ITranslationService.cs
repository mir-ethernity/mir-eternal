using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTransltor
{
    public interface ITranslationService
    {
        CultureInfo CurrentCulture { get; }
        Task Initialize();
        string GetString(string key, string[]? args = null, string defaultTranslation = "");
        IEnumerable<Language> GetLanguages();
        void ChangeLanguage(string cultureCode);
        void Attach(Control control);
        void Detach(Control control);
    }
}
