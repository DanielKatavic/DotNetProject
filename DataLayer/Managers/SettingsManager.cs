using System.Globalization;
using Utility.Dal;
using Utility.Models;

namespace Utility.Managers
{
    public class SettingsManager
    {
        private static readonly IRepository repository = RepositoryFactory.GetRepository();

        public static void LoadSettings()
            => Settings.ParseFromFileLine(repository.LoadSettings());

        public static void SaveSettings() 
            => repository.SaveSettings(Settings.ParseForFileLine());

        public static void SetFormLanguage()
        {
            string culture = Settings.LangSelected == Language.Hrvatski ? "hr" : "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }
}
