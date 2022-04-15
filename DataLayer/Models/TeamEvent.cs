using Newtonsoft.Json;

namespace Utility.Models
{
    public enum TypeOfEvent { Goal, GoalOwn, GoalPenalty, RedCard, SubstitutionIn, SubstitutionOut, YellowCard, YellowCardSecond };

    public class TeamEvent
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type_of_event")]
        public string? TypeOfEvent { get; set; }

        [JsonProperty("player")]
        public string? Player { get; set; }

        [JsonProperty("time")]
        public string? Time { get; set; }
    }
}