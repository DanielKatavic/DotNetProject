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
        public bool playerIsFavourite = false;
        private readonly StartingEleven? _player;
        private readonly MainForm? _mainForm;

        public PlayerCardForm(StartingEleven player, MainForm mainForm)
        {
            InitializeComponent();
            _player = player;
            _mainForm = mainForm;
            FillForm();
        }

        private void FillForm()
        {
            lblName.Text = _player?.Name?.ToUpper();
            lblShirtNumber.Text = _player?.ShirtNumber.ToString();
            if (_player.Captain) lblCaptain.Visible = true;
        }

        private void AddToFavourites_Click(object sender, EventArgs e)
        {
            AddPlayerToFavourites();
        }

        private void ChangePlayersImage_Click(object sender, EventArgs e)
            => ChangeImage();

        internal void AddPlayerToFavourites()
        {
            playerIsFavourite = !playerIsFavourite;
            if (playerIsFavourite)
            {
                cmAddToFav.Text = "Ukloni iz favorita";
                lblFavourite.Text = "★";
                lblFavourite.ForeColor = Color.Orange;
            }
            else
            {
                cmAddToFav.Text = "Dodaj u favorite";
                lblFavourite.Text = "☆";
                lblFavourite.ForeColor = Color.Black;
            }
            _mainForm?.ShowFavourites(this);
        }

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

        private void PlayerCardForm_MouseDown(object sender, MouseEventArgs e)
        {
            PlayerCardForm? form = sender as PlayerCardForm;
            form?.DoDragDrop(form, DragDropEffects.Move);
        }
    }
}