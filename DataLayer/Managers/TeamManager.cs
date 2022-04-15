using Newtonsoft.Json;
using RestSharp;
using Utility.Constants;

namespace Utility.Models
{
    public class TeamManager
    {
        private static readonly string endpoint = Settings.GenderSelected == Gender.Male ? ApiConstants.MaleEndpoint : ApiConstants.FemaleEndpoint;

        public static List<Team>? LoadFromFile(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return JsonConvert.DeserializeObject<List<Team>>(json);
        }

        public static List<Team>? LoadFromApi()
        {
            var apiClient = new RestClient(endpoint);
            var apiResult = apiClient.Execute<Team>(new RestRequest());

            return JsonConvert.DeserializeObject<List<Team>>(apiResult.Content);
        }
    }
}
