using Newtonsoft.Json;
using RestSharp;
using Utility.Constants;
using Utility.Models;

namespace Utility.Managers
{
    public class DataManager<T>
    {
        public static List<T>? LoadFromFile(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static List<T>? LoadFromApi()
        {
            var apiClient = new RestClient(typeof(T) == typeof(Team) ? ApiConstants.TeamEndpoint : ApiConstants.MatchEndpoint);
            var apiResult = apiClient.Execute<T>(new RestRequest());

            return JsonConvert.DeserializeObject<List<T>>(apiResult.Content);
        }
    }
}