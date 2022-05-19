using Newtonsoft.Json;
using RestSharp;
using Utility.Constants;
using Utility.Dal;
using Utility.Models;

namespace Utility.Managers
{
    public class DataManager<T>
    {
        private static readonly IRepository repository = RepositoryFactory.GetRepository();

        public static IList<T>? LoadFromFile()
        {
            string path = FileConstants.GetFilePath(typeof(T), Settings.GenderSelected);
            string json = repository.LoadJson(path);

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return JsonConvert.DeserializeObject<IList<T>>(json);
        }

        public static IList<T>? LoadFromApi()
        {
            var source = ApiConstants.GetEndpoint(typeof(T), 
                Settings.TeamSelected?.FifaCode ?? string.Empty, 
                Settings.GenderSelected);

            var apiClient = new RestClient(source);
            var apiResult = apiClient.Execute<T>(new RestRequest());

            return JsonConvert.DeserializeObject<IList<T>>(apiResult.Content);
        }
    }
}