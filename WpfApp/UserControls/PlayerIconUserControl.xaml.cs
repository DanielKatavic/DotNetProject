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
            SetPlayersImage();
        }

        private void SetPlayersImage()
        {
            if(player?.PicturePath is not null)
            {
                ImageBrush imageBrush = new(new ImageSourceConverter().ConvertFromString(player.PicturePath) as ImageSource);
                imageBrush.Stretch = Stretch.UniformToFill;
                playerIcon.Fill = imageBrush;
                lblShirtNumber.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void Icon_MouseDown(object sender, MouseButtonEventArgs e) 
            => new PlayerDetailsWindow(player).ShowDialog();
    }
}
