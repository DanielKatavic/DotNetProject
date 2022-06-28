using System;
using System.Collections.Generic;
using System.Net.Http;
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
            try
            {
                if (!InternetAvailability.IsInternetAvailable())
                {
                    MessageBox.Show("No internet connection!", "Error");
                    Settings.AccessSelected = Access.Offline;
                }
                teams = ((Label)parent).Name == "lblTeam" ? await TeamManager.GetAllTeams() : await TeamManager.GetAllOpponentsAsync();
                cbTeams.ItemsSource = teams;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
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
