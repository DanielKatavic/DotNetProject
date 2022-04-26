using Utility.Models;

namespace Utility.Managers
{
    public static class PlayerManager
    {
        private static readonly IList<Match>? matches = MatchManager.AllMatches;

        private static readonly Predicate<TeamEvent> isYellowCard = te => te.TypeOfEvent is "yellow-card" or "yellow-card-second";
        private static readonly Predicate<TeamEvent> isGoal = te => te.TypeOfEvent is "goal";
        private static readonly Predicate<Match> isHomeTeam = m => m.HomeTeam?.Country == Settings.TeamSelected?.Country;
        private static readonly string? methodName = System.Reflection.MethodBase.GetCurrentMethod()?.Name;

        private static readonly ISet<StartingEleven> playersWithYellowCards = new SortedSet<StartingEleven>();
        private static readonly ISet<StartingEleven> playersWithGoals = new SortedSet<StartingEleven>();

        public static readonly ISet<StartingEleven>? AllPlayers = LoadPlayers();

        private static ISet<StartingEleven>? LoadPlayers()
        {
            var teamIndex = matches?.ToList().FindIndex(isHomeTeam);
            return matches?[(int)teamIndex].HomeTeamStatistics?.AllPlayers;
        }

        public static ISet<StartingEleven> GetPlayersWithGoals()
        {
            IEnumerable<List<TeamEvent>?>? teamEvents = GetTeamEvents(methodName ?? string.Empty);
            teamEvents?.ToList().ForEach(te => te?.ForEach(g => AddGoalToPlayer(g)));
            return playersWithGoals;
        }

        public static ISet<StartingEleven> GetPlayersWithYellowCards()
        {
            IEnumerable<List<TeamEvent>?>? teamEvents = GetTeamEvents(methodName ?? string.Empty);
            teamEvents?.ToList().ForEach(te => te?.ForEach(yc => AddYellowCardToPlayer(yc)));
            return playersWithYellowCards;
        }

        private static IEnumerable<List<TeamEvent>?>? GetTeamEvents(string nameOfMethod)
            => matches?.ToList().Select(
              m => m?.HomeTeam?.Country == Settings.TeamSelected?.Country ?
                  m?.HomeTeamEvents?.FindAll(nameOfMethod == "LoadGoals" ? isGoal : isYellowCard) :
                  m?.AwayTeamEvents?.FindAll(nameOfMethod == "LoadGoals" ? isGoal : isYellowCard));

        private static void AddGoalToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = AllPlayers?.ToList().First(p => p.Name == teamEvent.Player);
            if (player is not null)
            {
                player.NumberOfGoals++;
                playersWithGoals.Add(player);
            }
        }

        private static void AddYellowCardToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = AllPlayers?.ToList().First(p => p.Name == teamEvent.Player);
            if (player is not null)
            {
                player.NumberOfYellowCards = teamEvent.TypeOfEvent is "yellow-card" ? 1 : 2;
                playersWithYellowCards.Add(player);
            }
        }
    }
}