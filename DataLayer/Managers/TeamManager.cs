using Utility.Models;

namespace Utility.Managers
{
    public static class TeamManager
    {
        public static Task<IList<Team>?> GetAllTeams()
            => Task.Run(() => Settings.AccessSelected == Access.Online ? DataManager<Team>.LoadFromApi() : DataManager<Team>.LoadFromFile());
    }
}