using Newtonsoft.Json;
using Utility.Models;

namespace Utility.Managers
{
    public class MatchManager
    {
        public static List<Match>? LoadFromJson(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                throw new ArgumentException("Dogodila se greška prilikom učitavanja datoteke!");
            }
            return JsonConvert.DeserializeObject<List<Match>>(json);
        }
    }
}
