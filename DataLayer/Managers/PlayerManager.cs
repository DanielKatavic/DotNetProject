using Utility.Models;

namespace Utility.Managers
{
    public class PlayerManager
    {
        private static readonly IList<Match>? matches = DataManager<Match>.LoadFromApi();
        private static readonly Predicate<TeamEvent> match = te => te.TypeOfEvent is "yellow-card" or "yellow-card-second";
        private static readonly Predicate<Match> isHomeTeam = m => m.HomeTeam?.Country == Settings.TeamSelected?.Country;

        public static ISet<StartingEleven>? LoadPlayers()
        {
            var teamIndex = matches?.ToList().FindIndex(isHomeTeam);
            return matches?[(int)teamIndex].HomeTeamStatistics?.AllPlayers;
        }

        public static void LoadYellowCards(ISet<StartingEleven>? players)
        {
            IEnumerable<List<TeamEvent>?>? yellowCards = GetAllYellowCards();
            yellowCards?.ToList().ForEach(yc => yc?.ForEach(te => AddYellowCardToPlayer(te, players)));
        }

        private static IEnumerable<List<TeamEvent>?>? GetAllYellowCards()
            => matches?.ToList().Select(m =>
                 m.HomeTeam?.Country == Settings.TeamSelected?.Country ?
                    m?.HomeTeamEvents?.FindAll(match) :
                    m?.AwayTeamEvents?.FindAll(match)
            );

        private static void AddYellowCardToPlayer(TeamEvent teamEvent, ISet<StartingEleven>? players)
        {
            StartingEleven? player = players?.ToList().First(p => p.Name == teamEvent.Player);
            if(player is not null) player.NumberOfYellowCards = teamEvent.TypeOfEvent is "yellow-card" ? 1 : 2;
        }
    }
}