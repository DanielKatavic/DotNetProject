using Utility.Models;

namespace Utility.Dal
{
    public interface IRepository
    {
        void SaveSettings(string informations);
        string LoadJson(string path);
        public string LoadSettings();
        void SavePlayersImage(StartingEleven player);
        string[] LoadPlayersWithImage();
        void SaveFavouritePlayers(IList<StartingEleven> favouritePlayers);
        string[] LoadFavouritePlayers();
    }
}
