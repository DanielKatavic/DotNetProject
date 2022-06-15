using Utility.Models;

namespace Utility.Managers
{
    public static class TeamManager
    {
        public static Task<IList<Team>?> GetAllTeams()
            => Task.Run(() => Settings.AccessSelected == Access.Online ? DataManager<Team>.LoadFromApi() : DataManager<Team>.LoadFromFile());

        public static Task<Team?> GetTeamData(Team? teamSelected)
            => Task.Run(() =>
            {
                IList<GroupResults>? groups = DataManager<GroupResults>.LoadFromFile();
                GroupResults? team = groups?.FirstOrDefault(g => g.Id == teamSelected?.GroupId);
                return team?.OrderedTeams?.FirstOrDefault(t => t.FifaCode == (teamSelected?.FifaCode));
            });

        public static async Task<IList<Team?>?> GetAllOpponentsAsync()
        {
            IList<Match>? matches = await MatchManager.GetAllMatches();
            IEnumerable<Match>? playedMatches = matches?.ToList().Where(m => m.HomeTeam?.Code == Settings.TeamSelected?.FifaCode || m.AwayTeam?.Code == Settings.TeamSelected?.FifaCode);
            return playedMatches?.Select(m => m.HomeTeam?.Code == Settings.TeamSelected?.FifaCode ? m.AwayTeam : m.HomeTeam).ToList();
        }
    }
}