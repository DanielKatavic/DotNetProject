using Utility.Models;

namespace Utility.Managers
{
    public static class MatchManager
    {
        public static IList<Match>? GetAllMatches() 
            => DataManager<Match>.LoadFromApi();
    }
}
