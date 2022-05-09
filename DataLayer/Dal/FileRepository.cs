using System.Text;
using Utility.Constants;
using Utility.Models;

namespace Utility.Dal
{
    public class FileRepository : IRepository
    {
        public void SaveSettings(string settings) 
            => File.WriteAllText(FileConstants.SettingsPath, settings);

        public string LoadSettings()
            => File.ReadAllText(FileConstants.SettingsPath);

        public static bool SettingsExists()
            => File.Exists(FileConstants.SettingsPath);

        public void SavePlayersImage(StartingEleven player) 
            => File.AppendAllText(FileConstants.PlayersImagePath, player.FormatForFileImages());

        public string[] LoadPlayersWithImage()
        {
            if (!File.Exists(FileConstants.PlayersImagePath)) return Array.Empty<string>();
            return File.ReadAllLines(FileConstants.PlayersImagePath);
        }

        public void SaveFavouritePlayers(IList<StartingEleven> favouritePlayers) 
            => File.WriteAllLines(FileConstants.FavouritePlayersPath, favouritePlayers.ToList().Select(fp => fp.FormatForFileFavourites()));

        public string[] LoadFavouritePlayers()
        {
            if(!File.Exists(FileConstants.FavouritePlayersPath)) return Array.Empty<string>();
            return File.ReadAllLines(FileConstants.FavouritePlayersPath);
        }

        public string LoadJson(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return File.ReadAllText(path);
        }
    }
}