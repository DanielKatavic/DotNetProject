using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using Utility.Managers;
using Utility.Models;
using WpfApp.UserControls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private const int IconOffset = 7;

        public MainWindow()
        {
            SetLanguage();
            InitializeComponent();
            SetResolution();
        }

        private static void SetLanguage()
            => SettingsManager.SetFormLanguage();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTeam.Content = Settings.TeamSelected is not null ? Settings.TeamSelected : Properties.Resources.teamSelect;
            lblOpponent.Content = Settings.OpponentSelected is not null ? Settings.OpponentSelected : Properties.Resources.opponentSelect;
            if (Settings.TeamSelected is not null && Settings.OpponentSelected is not null)
            {
                FillMatchInfoAsync();
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetLoadingIconPosition();
        }

        private void SetLoadingIconPosition()
        {
            double left = (this.ActualWidth - LoadingIcon.ActualWidth) / 2;
            Canvas.SetLeft(LoadingIcon, left - IconOffset);

            double top = (this.ActualHeight - LoadingIcon.ActualHeight) / 2;
            Canvas.SetTop(LoadingIcon, top);
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

        private async void FillMatchInfoAsync()
        {
            ClearPanels();
            LoadingIcon.Visibility = Visibility.Visible;

            try
            {
                if (!InternetAvailability.IsInternetAvailable())
                {
                    MessageBox.Show("No internet connection!", "Error");
                    Settings.AccessSelected = Access.Offline;
                }
                Match? match = await MatchManager.GetMatch();
                PlayerManager.FillPlayersWithEvents(match ?? new Match());
                PlayerManager.LoadPlayersWithImage(match ?? new Match());
                FillFootballField(match);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }

            lblResult.Content = MatchManager.GetMatchResultsAsync();
            LoadingIcon.Visibility = Visibility.Hidden;
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
            bool isSelectedTeam = match?.HomeTeam?.Code == Settings.TeamSelected?.FifaCode;

            match?.HomeTeamStatistics?.StartingEleven?.ToList().ForEach(se =>
            {
                if (isSelectedTeam)
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
                if (!isSelectedTeam)
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
                MessageBox.Show(Properties.Resources.mbWarningTeam, Properties.Resources.mbWarningCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (btnName == BtnOpponent.Name && Settings.OpponentSelected is null)
            {
                MessageBox.Show(Properties.Resources.mbWarningOpponent, Properties.Resources.mbWarningCaption, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            TeamDetailsWindow teamDetailsWindow = new(btnName == BtnTeam.Name ? Settings.TeamSelected : Settings.OpponentSelected)
            {
                Owner = this
            };
            teamDetailsWindow.ShowDialog();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TeamSelectWindow teamSelectWindow = new(sender)
            {
                Owner = this
            };
            teamSelectWindow.ShowDialog();
            FillLabels(((Label)sender).Name);
        }

        private void FillLabels(string senderName)
        {
            if (senderName == nameof(lblTeam) && Settings.TeamSelected is not null)
            {
                lblTeam.Content = Settings.TeamSelected;
                lblResult.Content = "x : x";
                lblOpponent.Content = Properties.Resources.opponentSelect;
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
            WelcomeWindow welcomeWindow = new();
            if (welcomeWindow.ShowDialog().Value)
            {
                this.Close();
            }
        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ellipse? ellipse = sender as Ellipse;
            Settings.LangSelected = ellipse?.Name == nameof(ElCro) ? Utility.Models.Language.Hrvatski : Utility.Models.Language.English;
            SettingsManager.SetFormLanguage();
            RefreshWindow();
        }

        private void RefreshWindow()
        {
            if (Settings.TeamSelected is not null || Settings.OpponentSelected is not null) return;
            lblTeam.Content = Properties.Resources.teamSelect;
            lblOpponent.Content = Properties.Resources.opponentSelect;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show(Properties.Resources.mbWarningText, Properties.Resources.mbWarningCaption, MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                Settings.WindowHeight = (int)this.Height;
                Settings.WindowWidth = (int)this.Width;
                Settings.IsFullScreen = WindowState == WindowState.Maximized;
                SettingsManager.SaveSettings();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
