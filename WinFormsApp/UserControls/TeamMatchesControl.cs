using Utility.Models;

namespace WinFormsApp.UserControls
{
    public partial class TeamMatchesControl : UserControl
    {
        private readonly Match match;

        public TeamMatchesControl(Match match)
        {
            InitializeComponent();
            this.match = match;
            FillForm();
        }

        private void FillForm()
        {
            imgHomeTeam.Image = Properties.FlagsResources.ResourceManager.GetObject(match.HomeTeam?.Code ?? string.Empty) as Image;
            imgAwayTeam.Image = Properties.FlagsResources.ResourceManager.GetObject(match.AwayTeam?.Code ?? string.Empty) as Image;
            lblHomeTeam.Text = match.HomeTeam?.Country;
            lblAwayTeam.Text = match.AwayTeam?.Country;
            lblLocation.Text = match?.Location;
            lblAttendance.Text = match?.Attendance.ToString();
            lblHTResult.Text = match?.HomeTeam?.Goals.ToString();
            lblATResult.Text = match?.AwayTeam?.Goals.ToString();
        }
    }
}
