using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Utility.Managers;
using Utility.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for TeamSelectWindow.xaml
    /// </summary>
    public partial class TeamSelectWindow : Window
    {
        private IList<Team>? teams;
        private readonly object parent;

        public TeamSelectWindow(object parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            FillWindow();
        }

        private async void FillWindow()
        {
            teams = ((Label)parent).Name == "lblTeam" ? await TeamManager.GetAllTeams() : await TeamManager.GetAllOpponentsAsync();
            cbTeams.ItemsSource = teams;
        }

        private void BtnSelectTeam_Click(object sender, RoutedEventArgs e)
        {
            if (((Label)parent).Name == "lblTeam")
            {
                Settings.TeamSelected = (Team?)cbTeams.SelectedItem;
            }
            else
            {
                Settings.OpponentSelected = (Team?)cbTeams.SelectedItem;
            }
            this.Close();
        }
    }
}
