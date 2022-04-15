using Utility.Models;

namespace Utility.Constants
{
    public static class ApiConstants
    {
        private static string MaleTeamEndpoint = "https://world-cup-json-2018.herokuapp.com/teams/results";
        private static string FemaleTeamEndpoint = "http://worldcup.sfg.io/teams/results";
        private static string MaleMatchEndpoint = $"http://worldcup.sfg.io/matches/country?fifa_code={Settings.TeamSelected}";
        private static string FemaleMatchEndpoint = $"https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code={Settings.TeamSelected}";

        public static readonly string TeamEndpoint = Settings.GenderSelected == Gender.Male ? MaleTeamEndpoint : FemaleTeamEndpoint;
        public static readonly string MatchEndpoint = Settings.GenderSelected == Gender.Male ? MaleMatchEndpoint : FemaleMatchEndpoint;
    }
}