using Utility.Managers;
using Utility.Models;
using WinFormsApp.Forms;

namespace WinFormsApp.UserControls
{
    public partial class PlayerUserControl : UserControl
    {
        public readonly StartingEleven player;
        private static IList<PlayerUserControl> selectedPlayerCards = new List<PlayerUserControl>();

        public PlayerUserControl(StartingEleven player)
        {
            InitializeComponent();
            this.player = player;
            DoubleBuffered = true;
        }

        private void PlayerUserControl_Load(object sender, EventArgs e)
        {
            CheckIfPlayerIsFav();
            CheckIfImageExists();
            FillForm();
        }

        private void CheckIfPlayerIsFav()
        {
            if(player.IsFavouritePlayer)
            {
                SetPlayerFavStatus("Ukloni iz favorita", "★", Color.Orange);
                (ParentForm as MainForm)?.ShowFavouritePlayers(this);
            }
        }

        private void CheckIfImageExists()
        {
            if(player.PicturePath is not null)
            {
                SetImageToPlayer(player.PicturePath);
            }
        }

        private void SetImageToPlayer(string path)
        {
            BackgroundImage = Image.FromFile(path);
            lblName.ForeColor = Color.White;
            lblPosition.ForeColor = Color.White;
            lblShirtNumber.Visible = false;
        }

        private void FillForm()
        {
            lblName.Text = player.Name?.ToUpper();
            lblShirtNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.Position.ToString();
            if (player.Captain) imgCapitain.Visible = true;
            ttUserControl.SetToolTip(this, $"{player?.Name?.ToUpper()}" +
                $"{Environment.NewLine}Broj dresa: {player?.ShirtNumber}" +
                $"{Environment.NewLine}{player?.Position}");
        }

        private void AddToFavourites_Click(object sender, EventArgs e)
        {
            if ((ParentForm as MainForm)?.GetFlpFavouritesCount() < 3 || player.IsFavouritePlayer)
            {
                AddPlayerToFavourites();
            }
            else
            {
                MessageBoxManager.ShowErrorMessage();
            }
        }

        private void ChangePlayersImage_Click(object sender, EventArgs e)
            => ChangeImage();

        internal void AddPlayerToFavourites()
        {
            player.IsFavouritePlayer = !player.IsFavouritePlayer;

            if (player.IsFavouritePlayer) SetPlayerFavStatus("Ukloni iz favorita", "★", Color.Orange);
            else SetPlayerFavStatus("Dodaj u favorite", "☆", Color.Black);

            (ParentForm as MainForm)?.ShowFavouritePlayers(this);
        }

        private void SetPlayerFavStatus(string cmText, string lblText, Color color)
        {
            cmAddToFav.Text = cmText;
            lblFavourite.Text = lblText;
            lblFavourite.ForeColor = color;
        }

        private void ChangeImage()
        {
            OpenFileDialog ofp = new()
            {
                Filter = "Slike|*.png;*.jpg;*.jpeg",
                Title = "Promijeni sliku igrača",
                InitialDirectory = Application.StartupPath
            };
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                if (player is not null)
                {
                    player.PicturePath = ofp.FileName;
                    PlayerManager.SavePlayerWithImage(player);
                }
                SetImageToPlayer(ofp.FileName);
            }
        }

        private void PlayerCardControl_MouseDown(object sender, MouseEventArgs e)
        {
            object data = selectedPlayerCards.Count == 0 ? new List<PlayerUserControl> { this } : selectedPlayerCards;

            if (e.Button == MouseButtons.Left)
            {
                if (sender is PlayerUserControl pcc) pcc.DoDragDrop(data, DragDropEffects.Move);
                if (sender is Label lbl) lbl.DoDragDrop(data, DragDropEffects.Move);
            }
            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (selectedPlayerCards.Count + (ParentForm as MainForm)?.GetFlpFavouritesCount() < 3 || player.IsFavouritePlayer)
                {
                    BorderStyle = BorderStyle.FixedSingle;
                    selectedPlayerCards?.Add(this);
                }
            }
        }

        internal static void ResetSelectedControls()
        {
            selectedPlayerCards.ToList().ForEach(spc => spc.BorderStyle = BorderStyle.None);
            selectedPlayerCards?.Clear();
        }
    }
}