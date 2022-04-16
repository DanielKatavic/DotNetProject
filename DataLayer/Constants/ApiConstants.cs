using Utility.Models;

namespace Utility.Constants
{
    public static class ApiConstants
    {
        private static string MaleTeamEndpoint = "https://world-cup-json-2018.herokuapp.com/teams/results";
        private static string FemaleTeamEndpoint = "http://worldcup.sfg.io/teams/results";
        private static string MaleMatchEndpoint = $"http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        private static string FemaleMatchEndpoint = $"http://worldcup.sfg.io/matches/country?fifa_code=";

        private static readonly string TeamEndpoint = Settings.GenderSelected == Gender.Male ? MaleTeamEndpoint : FemaleTeamEndpoint;
        
        private static string GetMatchEndpoint(string fifaCode) 
            =>  Settings.GenderSelected == Gender.Male ? MaleMatchEndpoint + fifaCode : FemaleMatchEndpoint + fifaCode;

        public static string GetEndpoint(Type t, string fifaCode)
        {
            if(t == typeof(Team)) return TeamEndpoint;
            
            if(t == typeof(Match)) return GetMatchEndpoint(fifaCode);
            
            return string.Empty;
        }
    }
}