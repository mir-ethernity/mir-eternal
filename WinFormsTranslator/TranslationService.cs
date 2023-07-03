using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTransltor
{
    public class TranslationService : ITranslationService
    {
        public TranslationService()
        {
            _translations = new Dictionary<string, Dictionary<string, string>>();
            _attachedControls = new List<TranslationMonitorControl>();
        }

        public string TranslationFolder = "Translations";

        private readonly Dictionary<string, Dictionary<string, string>> _translations;
        private readonly List<TranslationMonitorControl> _attachedControls;

        public CultureInfo CurrentCulture => CultureInfo.CurrentUICulture;


        public void Attach(Control control)
        {
            _attachedControls.Add(new TranslationMonitorControl(control, this));
            control.Disposed += (s, e) => Detach(control);
        }

        public void Detach(Control control)
        {
            var attachedControl = _attachedControls.FirstOrDefault(x => x.Root == control);
            if (attachedControl == null) return;
            attachedControl.Dispose();
            _attachedControls.Remove(attachedControl);
        }

        public void ChangeLanguage(string language)
        {
            CultureInfo.CurrentUICulture = new CultureInfo(language);
            Refresh();
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _translations.Keys
                .Select(x => new CultureInfo(x))
                .Select(x => new Language { Code = x.Name, Name = x.DisplayName })
                .ToArray();
        }

        public string GetString(string key, string[]? args = null, string defaultTranslation = "")
        {
            if (_translations.ContainsKey(CurrentCulture.Name) && _translations[CurrentCulture.Name].ContainsKey(key))
                return Format(_translations[CurrentCulture.Name][key], args);

            if (_translations.ContainsKey("en-US") && _translations["en-US"].ContainsKey(key))
            {
                SaveTerm(CurrentCulture.Name, key, _translations["en-US"][key]);
                return Format(_translations["en-US"][key], args);
            }

            SaveTerm("en-US", key, defaultTranslation);
            SaveTerm(CurrentCulture.Name, key, defaultTranslation);
            return Format(defaultTranslation, args);
        }

        public string GetString<T>(T control, string property, string[]? args = null, string defaultTranslation = "") where T : Control
        {
            string name = string.Empty;
            Control parent = control;

            do
            {
                name = $"{parent.Name}." + name;
            } while ((parent = parent.Parent) != null);

            name = (name.Replace(' ', '_') + property).ToLowerInvariant();

            return GetString(name, args, defaultTranslation);
        }

        private string Format(string text, string[]? args = null)
        {
            if (args == null || args.Length == 0)
                return text;

            var pattern = new Regex(Regex.Escape("%s"));

            var result = text;
            foreach (var arg in args)
                result = pattern.Replace(result, arg, 1);

            return result;
        }

        private void SaveTerm(string locale, string key, string translation)
        {
            if (!_translations.ContainsKey(locale))
                _translations.Add(locale, new Dictionary<string, string>());

            if (!_translations[locale].ContainsKey(key))
                _translations[locale].Add(key, translation);
            else
                _translations[locale][key] = translation;

            if (!Directory.Exists(TranslationFolder))
                Directory.CreateDirectory(TranslationFolder);

            File.WriteAllText(Path.Combine(TranslationFolder, $"{locale}.json"), JsonConvert.SerializeObject(_translations[locale], Formatting.Indented));
        }

        public async Task Initialize()
        {
#if DEBUG
            string fullPath = Path.GetFullPath(TranslationFolder);
            do
            {
                if (fullPath.EndsWith("ContentEditor"))
                    break;

                fullPath = Directory.GetParent(fullPath)?.FullName ?? "";
            } while (!string.IsNullOrEmpty(fullPath));

            TranslationFolder = Path.Combine(fullPath, TranslationFolder);
#endif

            if (!Directory.Exists(TranslationFolder))
                return;

            var files = Directory.GetFiles(TranslationFolder, "*.json");

            var regex = new Regex(@"^(?<lang>[a-z]{2})-(?<country>[A-Z]{2})$", RegexOptions.CultureInvariant);

            foreach (var file in files)
            {
                var countryCode = Path.GetFileNameWithoutExtension(file);
                if (regex.IsMatch(countryCode))
                {
                    var culture = new CultureInfo(countryCode);
                    var translations = new Dictionary<string, string>();
                    _translations.Add(culture.Name, translations);
                    var content = await File.ReadAllTextAsync(file);
                    var obj = JsonConvert.DeserializeObject<JObject>(content);
                    if (obj == null) continue;
                    ExpandTranslations(translations, obj);
                }
            }

            Refresh();
        }

        public void Refresh()
        {
            foreach (var attachedControl in _attachedControls)
                attachedControl.Refresh();
        }

        private void ExpandTranslations(Dictionary<string, string> translations, JObject obj, string keyPreffix = "")
        {
            var props = obj.Properties();
            foreach (var key in props)
            {
                var tmpkey = (keyPreffix.Length > 0 ? keyPreffix + "." : "") + key.Name.ToLowerInvariant();
                var value = key.Value;
                if (value == null) continue;

                switch (value.Type)
                {
                    case JTokenType.String:
                        if (!translations.ContainsKey(tmpkey))
                            translations.Add(tmpkey, value.Value<string>() ?? string.Empty);
                        break;
                    case JTokenType.Object:
                        ExpandTranslations(translations, (JObject)value, tmpkey);
                        break;
                    default:
                        throw new NotSupportedException($"Not supported token type '{value.Type}' for translations.");
                }
            }
        }
    }
}
