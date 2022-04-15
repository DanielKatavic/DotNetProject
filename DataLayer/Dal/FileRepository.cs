using Utility.Constants;
using Utility.Models;

namespace Utility.Dal
{
    public class FileRepository : IRepository
    {
        private readonly string teamsFilePath = Settings.GenderSelected == Gender.Male ? FileConstants.MaleTeamPath : FileConstants.FemaleTeamPath;
        private readonly string matchesFilePath = @"C:\Users\Daniel\Desktop\worldcup.sfg.io\men\matches.json";

        public void SaveSettings(string informations) 
            => File.WriteAllText(FileConstants.SettingsPath, informations);

        public string LoadJson()
        {
            if(!File.Exists(matchesFilePath))
            {
                throw new FileNotFoundException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return File.ReadAllText(matchesFilePath);
        }

        public static bool SettingsExists() 
            => File.Exists(FileConstants.SettingsPath);
    }
}