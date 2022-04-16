using Newtonsoft.Json;
using RestSharp;
using Utility.Constants;
using Utility.Models;

namespace Utility.Managers
{
    public class DataManager<T>
    {
        public static IList<T>? LoadFromFile(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return JsonConvert.DeserializeObject<IList<T>>(json);
        }

        public static IList<T>? LoadFromApi()
        {
            var source = ApiConstants.GetEndpoint(typeof(T), Settings.TeamSelected?.FifaCode);

            var apiClient = new RestClient(source);
            var apiResult = apiClient.Execute<T>(new RestRequest());

            return JsonConvert.DeserializeObject<IList<T>>(apiResult.Content);
        }
    }
}