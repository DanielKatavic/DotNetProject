using Utility.Models;

namespace Utility.Managers
{
    public static class MatchManager
    {
        public static Task<IList<Match>?> GetAllMatches() 
            => Task.Run(() => DataManager<Match>.LoadFromApi());
    }
}
