using Utility.Models;

namespace WinFormsApp
{
    public partial class PlayerCardControl : UserControl
    {
        public bool playerIsFavourite = false;
        private readonly StartingEleven? _player;
        private readonly MainForm? _mainForm;

        public PlayerCardControl(StartingEleven player, MainForm mainForm)
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
            lblPosition.Text = _player?.Position?.ToString();
            if (_player.Captain) lblCaptain.Visible = true;
        }

        private void AddToFavourites_Click(object sender, EventArgs e) 
            => AddPlayerToFavourites();

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
            _mainForm?.ShowFavouritePlayers(this);
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
                BackgroundImage = Image.FromFile(ofp.FileName);
            }
        }

        private void PlayerCardForm_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (sender is PlayerCardControl pcc) pcc.DoDragDrop(this, DragDropEffects.Move);
                if (sender is Label lbl) lbl.DoDragDrop(this, DragDropEffects.Move);
            }
        }
    }
}