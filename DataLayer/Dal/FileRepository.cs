using Utility.Constants;
using Utility.Models;

namespace Utility.Dal
{
    public class FileRepository : IRepository
    {
        public void SaveSettings(string informations) 
            => File.WriteAllText(FileConstants.SettingsPath, informations);

        public string LoadSettings()
            => File.ReadAllText(FileConstants.SettingsPath);

        public static bool SettingsExists()
            => File.Exists(FileConstants.SettingsPath);

        public string LoadFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return File.ReadAllText(path);
        }
    }
}