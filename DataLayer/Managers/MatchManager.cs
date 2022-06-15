using Utility.Models;

namespace Utility.Managers
{
    public static class MatchManager
    {
        public static Task<IList<Match>?> GetAllMatches() 
            => Task.Run(() => Settings.AccessSelected == Access.Online ? DataManager<Match>.LoadFromApi() : DataManager<Match>.LoadFromFile());

        public static async Task<string> GetMatchResultsAsync(Team? selectedOpponent)
        {
            IList<Match>? matches = await GetAllMatches();
            IEnumerable<Match>? playedMatches = matches?.ToList().Where(m => m.HomeTeam?.Code == Settings.TeamSelected?.FifaCode || m.AwayTeam?.Code == Settings.TeamSelected?.FifaCode);
            IList<Team>? teams = await TeamManager.GetAllTeams();
            Team? opponent = teams?.FirstOrDefault(t => t.FifaCode == selectedOpponent?.Code);
            Match? match = playedMatches?.ToList().FirstOrDefault(m => m.HomeTeam?.Code == opponent?.FifaCode || m.AwayTeam?.Code == opponent?.FifaCode);
            return $"{(match?.HomeTeam?.Code != opponent?.FifaCode ? match?.HomeTeam?.Goals : match?.AwayTeam?.Goals)} : {selectedOpponent?.Goals}";
        }
    }
}
