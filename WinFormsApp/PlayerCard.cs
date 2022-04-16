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
    public partial class PlayerCardForm : UserControl
    {
        private bool playerIsFavourite = false;

        public PlayerCardForm() 
            => InitializeComponent();

        public PlayerCardForm(StartingEleven player)
        {
            InitializeComponent();
            FillForm(player);
        }

        private void FillForm(StartingEleven player)
        {
            lblName.Text = player.Name?.ToUpper();
            lblShirtNumber.Text = player.ShirtNumber.ToString();
            if (player.Captain) lblCaptain.Visible = true;
        }

        private void lblFavourite_MouseDown(object sender, MouseEventArgs e)
        {
            playerIsFavourite = !playerIsFavourite;
            if (playerIsFavourite)
            {
                lblFavourite.Text = "★";
                lblFavourite.ForeColor = Color.Orange;
            }
            else
            {
                lblFavourite.Text = "☆";
                lblFavourite.ForeColor = Color.Black;
            }
        }

        private void ChangePlayersImage_Click(object sender, EventArgs e) 
            => ChangeImage();

        private void ChangeImage()
        {
            OpenFileDialog ofp = new()
            {
                Filter = "Images|*.png;*.jpg;*.jpeg",
                Title = "Change players image",
                InitialDirectory = Application.StartupPath
            };
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                pnlImage.BackgroundImage = Image.FromFile(ofp.FileName);
            }
        }
    }
}