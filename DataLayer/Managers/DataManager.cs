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

        public static IList<T>? LoadFromFile(bool isResult = false)
        {
            string path = FileConstants.GetFilePath(typeof(T), Settings.GenderSelected, isResult);
            string json = repository.LoadJson(path);

            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("An error occurred while loading file!");
            }
            return JsonConvert.DeserializeObject<IList<T>>(json, Converter.Settings);
        }

        public static IList<T>? LoadFromApi()
        {
            var source = ApiConstants.GetEndpoint(typeof(T),
                Settings.TeamSelected?.FifaCode ?? string.Empty,
                Settings.GenderSelected);

            var apiClient = new RestClient(source);
            var apiResult = apiClient.Execute<T>(new RestRequest());

            if (apiResult.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
            {
                throw new Exception("An error occurred while loading json!");
            }

            return JsonConvert.DeserializeObject<IList<T>>(apiResult.Content, Converter.Settings);
        }
    }
}