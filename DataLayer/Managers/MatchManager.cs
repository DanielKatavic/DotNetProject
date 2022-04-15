using Newtonsoft.Json;
using RestSharp;
using Utility.Constants;
using Utility.Models;

namespace Utility.Managers
{
    public class MatchManager
    {
        public static List<Match>? LoadFromFile(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return JsonConvert.DeserializeObject<List<Match>>(json);
        }

        public static List<Match>? LoadFromApi()
        {
            var apiClient = new RestClient(ApiConstants.MatchEndpoint);
            var apiResult = apiClient.Execute<Match>(new RestRequest());

            return JsonConvert.DeserializeObject<List<Match>>(apiResult.Content);
        }
    }
}
