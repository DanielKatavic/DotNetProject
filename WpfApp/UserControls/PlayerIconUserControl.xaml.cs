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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        {
            InitializeComponent();
        }

        public PlayerIconUserControl(StartingEleven player, bool isHomeTeam) : this()
        {
            this.player = player;
            lblShirtNumber.Content = player.ShirtNumber;
            playerIcon.Fill = isHomeTeam ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.Red);
        }

        private void Icon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new PlayerDetailsWindow(player).ShowDialog();
        }
    }
}
