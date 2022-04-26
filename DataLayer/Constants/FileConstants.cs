using Utility.Models;

namespace Utility.Constants
{
    public static class FileConstants
    {
        public const string SettingsPath = "settings.txt";
        private const string MaleTeamPath = @"C:\Users\Daniel\Desktop\worldcup.sfg.io\men\teams.json";
        private const string FemaleTeamPath = @"C:\Users\Daniel\Desktop\worldcup.sfg.io\women\teams.json";
        private const string MaleMatchPath = @"C:\Users\Daniel\Desktop\worldcup.sfg.io\men\matches.json";
        private const string FemaleMatchPath = @"C:\Users\Daniel\Desktop\worldcup.sfg.io\women\matches.json";

        private static string GetMatchPath()
            => Settings.GenderSelected == Gender.Male ? MaleMatchPath : FemaleMatchPath;

        private static string GetTeamPath()
            => Settings.GenderSelected == Gender.Male ? MaleTeamPath : FemaleTeamPath;

        public static string GetFilePath(Type t, Gender genderSelected)
        {
            if (t == typeof(Team)) return GetTeamPath();

            if (t == typeof(Match)) return GetMatchPath();

            return string.Empty;
        }
    }
}