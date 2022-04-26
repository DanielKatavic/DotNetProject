using Utility.Models;

namespace Utility.Constants
{
    public static class ApiConstants
    {
        private const string MaleTeamEndpoint = "https://world-cup-json-2018.herokuapp.com/teams/results";
        private const string FemaleTeamEndpoint = "http://worldcup.sfg.io/teams/results";
        private const string MaleMatchEndpoint = $"http://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=";
        private const string FemaleMatchEndpoint = $"http://worldcup.sfg.io/matches/country?fifa_code=";

        private static string GetTeamEndpoint(Gender genderSelected) 
            => genderSelected == Gender.Male ? MaleTeamEndpoint : FemaleTeamEndpoint;
        
        private static string GetMatchEndpoint(string fifaCode, Gender genderSelected) 
            =>  genderSelected == Gender.Male ? MaleMatchEndpoint + fifaCode : FemaleMatchEndpoint + fifaCode;

        public static string GetEndpoint(Type t, string fifaCode, Gender genderSelected)
        {
            if(t == typeof(Team)) return GetTeamEndpoint(genderSelected);
            
            if(t == typeof(Match)) return GetMatchEndpoint(fifaCode, genderSelected);
            
            return string.Empty;
        }
    }
}