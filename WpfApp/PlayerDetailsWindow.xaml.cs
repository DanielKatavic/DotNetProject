using System.Windows;
using Utility.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        public PlayerDetailsWindow()
        {
            InitializeComponent();
        }

        public PlayerDetailsWindow(StartingEleven player) : this()
        {
            lblName.Content = player.Name.ToUpper();
            lblShirtNumber.Content = player.ShirtNumber;
            lblPosition.Content = player.Position;
            imgCaptain.Visibility = player.Captain ? Visibility.Visible : Visibility.Hidden;
            lblGoals.Content = player.NumberOfGoals;
            lblYellowCards.Content = player.NumberOfYellowCards;
        }
    }
}
