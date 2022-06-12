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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetResolution();
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
            IList<Team>? teams = await TeamManager.GetAllTeams();
            exTeamSelected.Header = $"Selected team: {Settings.TeamSelected}";
            cbTeams.ItemsSource = teams;
        }

        private void ChangeTeam_Click(object sender, RoutedEventArgs e)
        {
            exTeamSelected.Header = $"Selected team: {cbTeams.SelectedItem}";
        }
    }
}
