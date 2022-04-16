using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.Models;

namespace WinFormsApp
{
    public partial class PlayerCard : UserControl
    {
        public PlayerCard()
        {
            InitializeComponent();
        }

        public PlayerCard(StartingEleven player)
        {
            InitializeComponent();
            lblName.Text = player.Name;
            lblShirtNumber.Text = player.ShirtNumber.ToString();
        }
    }
}
