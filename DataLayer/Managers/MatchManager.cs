using Utility.Models;

namespace Utility.Managers
{
    public static class MatchManager
    {
        private static Team? opponent;
        private static Match? match;

        public static Task<IList<Match>?> GetAllMatches() 
            => Task.Run(() => Settings.AccessSelected == Access.Online ? DataManager<Match>.LoadFromApi() : DataManager<Match>.LoadFromFile());

        public static string GetMatchResultsAsync() 
            => $"{(match?.HomeTeam?.Code != opponent?.FifaCode ? match?.HomeTeam?.Goals : match?.AwayTeam?.Goals)} : {Settings.OpponentSelected?.Goals}";

        public static async Task<Match?> GetMatch()
        {
            IList<Match>? matches = await GetAllMatches();
            IEnumerable<Match>? playedMatches = matches?.ToList().Where(m => m.HomeTeam?.Code == Settings.TeamSelected?.FifaCode || m.AwayTeam?.Code == Settings.TeamSelected?.FifaCode);
            IList<Team>? teams = await TeamManager.GetAllTeams();
            opponent = teams?.FirstOrDefault(t => t.FifaCode == Settings.OpponentSelected?.Code);
            match = playedMatches?.ToList().FirstOrDefault(m => m.HomeTeam?.Code == opponent?.FifaCode || m.AwayTeam?.Code == opponent?.FifaCode);
            return match;
        }
    }
}
