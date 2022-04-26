using Utility.Models;

namespace Utility.Managers
{
    public class MatchManager
    {
        public static readonly IList<Match>? AllMatches = DataManager<Match>.LoadFromApi();
    }
}
