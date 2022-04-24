using Utility.Models;

namespace Utility.Managers
{
    public class PlayerManager
    {
        private static readonly IList<Match>? matches = DataManager<Match>.LoadFromApi();

        private static readonly Predicate<TeamEvent> isYellowCard = te => te.TypeOfEvent is "yellow-card" or "yellow-card-second";
        private static readonly Predicate<TeamEvent> isGoal = te => te.TypeOfEvent is "goal";
        private static readonly Predicate<Match> isHomeTeam = m => m.HomeTeam?.Country == Settings.TeamSelected?.Country;
        private static readonly string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;

        public static ISet<StartingEleven>? players;  

        public static ISet<StartingEleven>? LoadPlayers()
        {
            var teamIndex = matches?.ToList().FindIndex(isHomeTeam);
            return matches?[(int)teamIndex].HomeTeamStatistics?.AllPlayers;
        }

        public static void LoadGoals()
        {
            IEnumerable<List<TeamEvent>?>? teamEvents = GetTeamEvents(methodName);
            teamEvents?.ToList().ForEach(te => te?.ForEach(g => AddGoalToPlayer(g)));
        }

        public static void LoadYellowCards()
        {
            IEnumerable<List<TeamEvent>?>? teamEvents = GetTeamEvents(methodName);
            teamEvents?.ToList().ForEach(te => te?.ForEach(yc => AddYellowCardToPlayer(yc)));
        }

        private static IEnumerable<List<TeamEvent>?>? GetTeamEvents(string nameOfMethod)
            => matches?.ToList().Select(
              m => m?.HomeTeam?.Country == Settings.TeamSelected?.Country ?
                  m?.HomeTeamEvents?.FindAll(nameOfMethod == "LoadGoals" ? isGoal : isYellowCard) :
                  m?.AwayTeamEvents?.FindAll(nameOfMethod == "LoadGoals" ? isGoal : isYellowCard));

        private static void AddYellowCardToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = players?.ToList().First(p => p.Name == teamEvent.Player);
            if (player is not null) player.NumberOfYellowCards = teamEvent.TypeOfEvent is "yellow-card" ? 1 : 2;
        }

        private static void AddGoalToPlayer(TeamEvent teamEvent)
        {
            StartingEleven? player = players?.ToList().First(p => p.Name == teamEvent.Player);
            if (player is not null) player.NumberOfGoals++;
        }
    }
}