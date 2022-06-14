using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Utility.Managers;
using Utility.Models;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private IList<Team>? teams;
        private IList<Match>? matches;
        private IEnumerable<Match>? playedMatches;
        private Team? opponent;

        public MainWindow()
        {
            InitializeComponent();
            SetResolution();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillWindowAsync();
        }

        private void SetResolution()
        {
            if (Settings.IsFullScreen)
            {
                WindowState = WindowState.Maximized;
            }
            else
            {
                this.Height = Settings.WindowHeight;
                this.Width = Settings.WindowWidth;
            }
        }

        private async void FillWindowAsync()
        {
            await LoadDataAsync();
            //exTeamSelected.Header = Settings.TeamSelected;
            cbTeams.ItemsSource = teams;
            //FillCBOpponent();
        }

        private async Task LoadDataAsync()
        {
            teams = await TeamManager.GetAllTeams();
            matches = await MatchManager.GetAllMatches();
        }

        private void ChangeTeam_Click(object sender, RoutedEventArgs e)
        {
            exTeamSelected.Header = cbTeams.SelectedItem;
            Settings.TeamSelected = (Team?)cbTeams.SelectedItem;
            FillCBOpponent();
            exTeamSelected.IsExpanded = false;
        }

        private void FillCBOpponent()
        {
            playedMatches = matches?.ToList().Where(m => m.HomeTeam?.Code == Settings.TeamSelected?.FifaCode || m.AwayTeam?.Code == Settings.TeamSelected?.FifaCode);
            cbOpponent.ItemsSource = playedMatches?.Select(m => m.HomeTeam?.Code == Settings.TeamSelected?.FifaCode ? m.AwayTeam : m.HomeTeam);
        }

        private void ChangeOpponent_Click(object sender, RoutedEventArgs e)
        {
            exOpponent.IsExpanded = false;
            Team? selectedOpponent = cbOpponent.SelectedItem as Team;
            opponent = teams?.FirstOrDefault(t => t.FifaCode == selectedOpponent?.Code);
            exOpponent.Header = opponent;
            Match? match = playedMatches?.ToList().FirstOrDefault(m => m.HomeTeam?.Code == opponent?.FifaCode || m.AwayTeam?.Code == opponent?.FifaCode);
            lblResult.Content = $"{(match?.HomeTeam?.Code != opponent?.FifaCode ? match?.HomeTeam?.Goals : match?.AwayTeam?.Goals)} : {selectedOpponent?.Goals}";
            btnOpponent.Content = "Change opponent";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (Settings.TeamSelected is null)
            {
                MessageBox.Show("You need to select team!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (btnName == BtnOpponent.Name && opponent is null)
            {
                MessageBox.Show("You need to select opponent!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            TeamDetailsWindow teamDetailsWindow = new(btnName == BtnTeam.Name ? Settings.TeamSelected : opponent);
            teamDetailsWindow.ShowDialog();
        }
    }
}
