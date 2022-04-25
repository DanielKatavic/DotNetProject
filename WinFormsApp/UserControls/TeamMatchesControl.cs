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
            if(match.HomeTeam?.Code is not null && match.AwayTeam?.Code is not null)
            {
                imgHomeTeam.Image = Properties.FlagsResources.ResourceManager.GetObject(match.HomeTeam.Code) as Image;
                imgAwayTeam.Image = Properties.FlagsResources.ResourceManager.GetObject(match.AwayTeam.Code) as Image;
            }
            lblHomeTeam.Text = match.HomeTeam?.Country;
            lblAwayTeam.Text = match.AwayTeam?.Country;
            lblLocation.Text = match?.Location;
            lblAttendance.Text = match?.Attendance.ToString();
            lblHTResult.Text = match?.HomeTeam?.Goals.ToString();
            lblATResult.Text = match?.AwayTeam?.Goals.ToString();
        }
    }
}
