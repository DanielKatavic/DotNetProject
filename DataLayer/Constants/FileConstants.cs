using Utility.Models;

namespace Utility.Constants
{
    public static class FileConstants
    {
        public const string SettingsPath = "settings.txt";
        public const string PlayersImagePath = "players-with-image.txt";
        public const string FavouritePlayersPath = "favourite-players.txt";

        private const string ResultsDir = "worldcup.sfg.io";

        public static string GetFilePath(Type t, Gender genderSelected)
        {
            string genderDir = (genderSelected == Gender.Male ? "men" : "women");

            if (t == typeof(Team)) return @$"..\..\..\..\{ResultsDir}\{genderDir}\teams.json";
            
            if (t == typeof(GroupResults)) return @$"..\..\..\..\{ResultsDir}\{genderDir}\group_results.json"; ;

            if (t == typeof(Match)) return @$"..\..\..\..\{ResultsDir}\{genderDir}\matches.json";

            return string.Empty;
        }
    }
}