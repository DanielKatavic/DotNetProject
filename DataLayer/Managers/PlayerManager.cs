using Utility.Models;

namespace Utility.Managers
{
    public class PlayerManager
    {
        public static ISet<StartingEleven>? LoadPlayers()
        {
            IList<Match>? matches = DataManager<Match>.LoadFromApi();

            var teamIndex = matches?.ToList().FindIndex(m => m.HomeTeam?.Country == Settings.TeamSelected?.Country);

            return matches?[(int)teamIndex].HomeTeamStatistics?.AllPlayers;
        }
    }
}