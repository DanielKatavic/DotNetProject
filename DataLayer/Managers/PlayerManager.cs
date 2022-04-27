using Utility.Models;
using System.Reflection;

namespace Utility.Managers
{
    public static partial class PlayerManager
    {
        private static IList<Match>? matches = MatchManager.GetAllMatches();

        private static readonly Predicate<TeamEvent> isYellowCard = te => te.TypeOfEvent is "yellow-card" or "yellow-card-second";
        private static readonly Predicate<TeamEvent> isGoal = te => te.TypeOfEvent is "goal";
        private static readonly Predicate<Match> isHomeTeam = m => m.HomeTeam?.Country == Settings.TeamSelected?.Country;

        private static ISet<StartingEleven> playersWithYellowCards = new SortedSet<StartingEleven>();
        private static ISet<StartingEleven> playersWithGoals = new SortedSet<StartingEleven>();
    }

    public static partial class PlayerManager
    {
        public static ISet<StartingEleven>? GetAllPlayers()
        {
            var teamIndex = matches?.ToList().FindIndex(isHomeTeam);
            return matches?[(int)teamIndex].HomeTeamStatistics?.AllPlayers;
        }

        public static ISet<StartingEleven> GetPlayersWithGoals()
        {
            IEnumerable<List<TeamEvent>?>? teamEvents = GetTeamEvents(MethodBase.GetCurrentMethod()?.Name ?? string.Empty);
            teamEvents?.ToList().ForEach(te => te?.ForEach(g => AddGoalToPlayer(g)));
            return playersWithGoals;
        }

        public static ISet<StartingEleven> GetPlayersWithYellowCards()
        {
            IEnumerable<List<TeamEvent>?>? teamEvents = GetTeamEvents(MethodBase.GetCurrentMethod()?.Name ?? string.Empty);
            teamEvents?.ToList().ForEach(te => te?.ForEach(yc => AddYellowCardToPlayer(yc)));
            return playersWithYellowCards;
        }

        public static void ResetCollections()
        {
            playersWithYellowCards.Clear();
            playersWithGoals.Clear();
            matches = MatchManager.GetAllMatches();
        }

        private static IEnumerable<List<TeamEvent>?>? GetTeamEvents(string nameOfMethod)
            => matches?.ToList().Select(
              m => m?.HomeTeam?.Country == Settings.TeamSelected?.Country ?
                  m?.HomeTeamEvents?.FindAll(nameOfMethod == "GetPlayersWithGoals" ? isGoal : isYellowCard) :
                  m?.AwayTeamEvents?.FindAll(nameOfMethod == "GetPlayersWithGoals" ? isGoal : isYellowCard));

        private static void AddGoalToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = GetAllPlayers()?.ToList().First(p => p.Name == teamEvent.Player);
            if (player is not null)
            {
                player.NumberOfGoals++;
                playersWithGoals.Add(player);
            }
        }

        private static void AddYellowCardToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = GetAllPlayers()?.ToList().First(p => p.Name == teamEvent.Player);
            if (player is not null)
            {
                player.NumberOfYellowCards = teamEvent.TypeOfEvent is "yellow-card" ? 1 : 2;
                playersWithYellowCards.Add(player);
            }
        }
    }
}