using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Utility.Managers;
using Utility.Models;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public Team? SelectedOpponent { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SetResolution();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblTeam.Content = Settings.TeamSelected != null ? Settings.TeamSelected : "Select team";
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

        private async void FillLblResultsAsync()
        {
            lblResult.Content = await MatchManager.GetMatchResultsAsync(SelectedOpponent);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string btnName = ((Button)sender).Name;
            if (Settings.TeamSelected is null)
            {
                MessageBox.Show("You need to select team!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (SelectedOpponent is null)
            {
                MessageBox.Show("You need to select opponent!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            TeamDetailsWindow teamDetailsWindow = new(btnName == BtnTeam.Name ? Settings.TeamSelected : SelectedOpponent);
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
                if (SelectedOpponent is not null)
                {
                    FillLblResultsAsync();
                    lblOpponent.Content = SelectedOpponent;
                }
            }
        }
    }
}
