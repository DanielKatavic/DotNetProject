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
    }
}