using System.Windows;
using System.Windows.Media;
using Utility.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for PlayerDetailsWindow.xaml
    /// </summary>
    public partial class PlayerDetailsWindow : Window
    {
        public PlayerDetailsWindow()
            => InitializeComponent();

        public PlayerDetailsWindow(StartingEleven player) : this()
        {
            lblName.Content = player.Name.ToUpper();
            lblShirtNumber.Content = player.ShirtNumber;
            lblPosition.Content = player.Position;
            imgCaptain.Visibility = player.Captain ? Visibility.Visible : Visibility.Hidden;
            lblGoals.Content = player.NumberOfGoals;
            lblYellowCards.Content = player.NumberOfYellowCards;
            if (player.PicturePath is not null)
            {
                imgPlayer.Source = new ImageSourceConverter().ConvertFromString(player.PicturePath) as ImageSource;
                lblShirtNumber.Visibility = Visibility.Hidden;
                lblName.Content += $" {player.ShirtNumber}";
            }
        }
    }
}
