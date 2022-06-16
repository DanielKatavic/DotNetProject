using System.Threading.Tasks;
using System.Windows;
using Utility.Managers;
using Utility.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for TeamDetailsWindow.xaml
    /// </summary>
    public partial class TeamDetailsWindow : Window
    {
        private Team? teamSelected;
        private Team? teamDetails;

        public TeamDetailsWindow()
        {
            InitializeComponent();
        }

        public TeamDetailsWindow(Team? teamSelected) : this()
        {
            this.teamSelected = teamSelected;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillWindow();
        }

        private async void FillWindow()
        {
            await LoadDataAsync();
            lblTeamName.Content = teamSelected;
            lblPlayedMatches.Content = teamDetails?.GamesPlayed;
            lblWins.Content = teamDetails?.Wins;
            lblLosses.Content = teamDetails?.Losses;
            lblDraws.Content = teamDetails?.Draws;
            lblGoalsFor.Content = teamDetails?.GoalsFor;
            lblGoalsAgainst.Content = teamDetails?.GoalsAgainst;
            lblGoalsDifferential.Content = teamDetails?.GoalDifferential;
        }

        private async Task LoadDataAsync()
        {
            teamDetails = await TeamManager.GetTeamData(teamSelected);
        }
    }
}
