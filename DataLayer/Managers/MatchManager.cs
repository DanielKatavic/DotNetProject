using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Models;

namespace Utility.Managers
{
    public class MatchManager
    {
        public static readonly IList<Match>? AllMatches = DataManager<Match>.LoadFromApi();
    }
}
