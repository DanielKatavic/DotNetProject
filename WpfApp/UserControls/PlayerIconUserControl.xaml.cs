using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Utility.Models;

namespace WpfApp.UserControls
{
    /// <summary>
    /// Interaction logic for PlayerIconUserControl.xaml
    /// </summary>
    public partial class PlayerIconUserControl : UserControl
    {
        private StartingEleven? player;

        public PlayerIconUserControl() 
            => InitializeComponent();

        public PlayerIconUserControl(StartingEleven player, bool isSelectedTeam) : this()
        {
            this.player = player;
            lblShirtNumber.Content = player.ShirtNumber;
            lblName.Content = player.Name.ToUpper();
            playerIcon.Fill = isSelectedTeam ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.Red);
        }

        private void Icon_MouseDown(object sender, MouseButtonEventArgs e) 
            => new PlayerDetailsWindow(player).ShowDialog();
    }
}
