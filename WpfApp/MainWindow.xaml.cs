using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Utility.Managers;
using Utility.Models;
using WpfApp.UserControls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetResolution();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
            => lblTeam.Content = Settings.TeamSelected != null ? Settings.TeamSelected : "Select team";

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

        private async void FillMatchInfoAsync()
        {
            ClearPanels();
            Match? match = await MatchManager.GetMatch();
            FillFootballField(match);
            lblResult.Content = MatchManager.GetMatchResultsAsync();
        }

        private void ClearPanels()
        {
            foreach (StackPanel stackPanel in FieldGrid.Children)
            {
                stackPanel.Children.Clear();
            }
        }

        private void FillFootballField(Match? match)
        {
            bool isHomeTeam = match?.HomeTeam?.Code == Settings.TeamSelected?.FifaCode;
            PlayerManager.FillPlayersWithEvents(match);
            match?.HomeTeamStatistics?.StartingEleven?.ToList().ForEach(se =>
            {
                if (isHomeTeam)
                {
                    FillHomeTeamSide(se);
                }
                else
                {
                    FillAwayTeamSide(se);
                }
            });
            match?.AwayTeamStatistics?.StartingEleven?.ToList().ForEach(se =>
            {
                if (!isHomeTeam)
                {
                    FillHomeTeamSide(se);
                }
                else
                {
                    FillAwayTeamSide(se);
                }
            });
        }

        private void FillAwayTeamSide(StartingEleven se)
        {
            if (se.Position == Position.Goalie)
            {
                AwayGoaliePanel.Children.Add(new PlayerIconUserControl(se, false));
            }
            if (se.Position == Position.Defender)
            {
                AwayDefendersPanel.Children.Add(new PlayerIconUserControl(se, false));
            }
            if (se.Position == Position.Midfield)
            {
                AwayMidfieldsPanel.Children.Add(new PlayerIconUserControl(se, false));
            }
            if (se.Position == Position.Forward)
            {
                AwayForwardsPanel.Children.Add(new PlayerIconUserControl(se, false));
            }
        }

        private void FillHomeTeamSide(StartingEleven se)
        {
            if (se.Position == Position.Goalie)
            {
                TeamGoaliePanel.Children.Add(new PlayerIconUserControl(se, true));
            }
            if (se.Position == Position.Defender)
            {
                TeamDefendersPanel.Children.Add(new PlayerIconUserControl(se, true));
            }
            if (se.Position == Position.Midfield)
            {
                TeamMidfieldsPanel.Children.Add(new PlayerIconUserControl(se, true));
            }
            if (se.Position == Position.Forward)
            {
                TeamForwardsPanel.Children.Add(new PlayerIconUserControl(se, true));
            }
        }

        private void BtnTeamInfo_Click(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (Settings.TeamSelected is null)
            {
                MessageBox.Show("You need to select team!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (btnName == BtnOpponent.Name && Settings.OpponentSelected is null)
            {
                MessageBox.Show("You need to select opponent!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            TeamDetailsWindow teamDetailsWindow = new(btnName == BtnTeam.Name ? Settings.TeamSelected : Settings.OpponentSelected)
            {
                Owner = this
            };
            teamDetailsWindow.ShowDialog();
        }

        private void Label_MouseDownAsync(object sender, MouseButtonEventArgs e)
        {
            TeamSelectWindow teamSelectWindow = new(sender)
            {
                Owner = this
            };
            teamSelectWindow.ShowDialog();
            if (((Label)sender).Name == nameof(lblTeam) && Settings.TeamSelected is not null)
            {
                lblTeam.Content = Settings.TeamSelected;
            }
            else
            {
                if (Settings.OpponentSelected is not null)
                {
                    FillMatchInfoAsync();
                    lblOpponent.Content = Settings.OpponentSelected;
                }
            }
        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow newWindow = new();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }

        private void BtnTranslate_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
