using Utility.Models;

namespace Utility.Constants
{
    public static class FileConstants
    {
        public const string SettingsPath = "settings.txt";
        public const string PlayersImagePath = "players-with-image.txt";
        public const string FavouritePlayersPath = "favourite-players.txt";

        private const string MaleTeamPath = @"..\..\..\..\worldcup.sfg.io\men\teams.json";
        private const string FemaleTeamPath = @"..\..\..\..\worldcup.sfg.io\women\teams.json";
        private const string MaleMatchPath = @"..\..\..\..\worldcup.sfg.io\men\matches.json";
        private const string FemaleMatchPath = @"..\..\..\..\worldcup.sfg.io\women\matches.json";

        private static string GetMatchPath(Gender genderSelected)
            => genderSelected == Gender.Male ? MaleMatchPath : FemaleMatchPath;

        private static string GetTeamPath(Gender genderSelected)
            => genderSelected == Gender.Male ? MaleTeamPath : FemaleTeamPath;

        public static string GetFilePath(Type t, Gender genderSelected)
        {
            if (t == typeof(Team)) return GetTeamPath(genderSelected);

            if (t == typeof(Match)) return GetMatchPath(genderSelected);

            return string.Empty;
        }
    }
}