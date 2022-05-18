using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Models;
using WinFormsApp.UserControls;

namespace WinFormsApp.Tabs
{
    internal static class TabManager
    {
        internal static void ClearTab(params FlowLayoutPanel[] panels)
        {
            foreach (FlowLayoutPanel panel in panels)
            {
                panel.Controls.Clear();
            }
        }

        internal static void ClearTab(FlowLayoutPanel panel)
            => panel.Controls.Clear();

        internal static void FillSecondTab(ISet<StartingEleven>? playersWithYellowCards, ISet<StartingEleven>? playersWithGoals, FlowLayoutPanel flpYellowCards, FlowLayoutPanel flpGoals)
        {
            playersWithYellowCards?
                .OrderByDescending(p => p.NumberOfYellowCards)
                .ToList().ForEach(player => flpYellowCards.Controls.Add(new PlayerYellowCardControl(player)));

            playersWithGoals?
                .OrderByDescending(p => p.NumberOfGoals)
                .ToList().ForEach(player => flpGoals.Controls.Add(new PlayerGoalsControl(player)));
        }

        internal static void FillThirdTab(IList<Match>? matches, FlowLayoutPanel flpMatches)
            => matches?
                .OrderByDescending(m => m.Attendance)
                .ToList().ForEach(match =>
                {
                    if (match.HomeTeam?.Country == Settings.TeamSelected?.Country
                    || match.AwayTeam?.Country == Settings.TeamSelected?.Country)
                    {
                        flpMatches.Controls.Add(new TeamMatchesControl(match));
                    }
                });
    }
}
