using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Models;

namespace Utility.Managers
{
    public class SettingsManager
    {
        private const char Del = '|';

        public static string ParseForFileLine()
            => $"{Settings.GenderSelected}{Del}{Settings.LangSelected}{Del}{Settings.AccessSelected}{Del}{Settings.TeamSelected}";

        public static void ParseFromFileLine(string line)
        {
            string[] details = line.Split(Del);
            Settings.GenderSelected = (Gender)Enum.Parse(typeof(Gender), details[0]);
            Settings.LangSelected = (Language)Enum.Parse(typeof(Language), details[1]);
            Settings.AccessSelected = (Access)Enum.Parse(typeof(Access), details[2]);
        }
    }
}
