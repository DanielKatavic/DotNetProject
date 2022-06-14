using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Models
{
    public class GroupResults
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("letter")]
        public string? Letter { get; set; }

        [JsonProperty("ordered_teams")]
        public List<Team>? OrderedTeams { get; set; }
    }
}
