using Utility.Models;
using WinFormsApp.Forms;

namespace WinFormsApp.UserControls
{
    public partial class PlayerUserControl : UserControl
    {
        private readonly StartingEleven? player;
        private static IList<PlayerUserControl> selectedPlayerCards = new List<PlayerUserControl>();

        internal bool playerIsFavourite = false;

        public PlayerUserControl(StartingEleven player)
        {
            InitializeComponent();
            this.player = player;
            DoubleBuffered = true;
            FillForm();
        }

        private void FillForm()
        {
            lblName.Text = player?.Name?.ToUpper();
            lblShirtNumber.Text = player?.ShirtNumber.ToString();
            lblPosition.Text = player?.Position?.ToString();
            if (player is not null && player.Captain) imgCapitain.Visible = true;
            ttUserControl.SetToolTip(this, $"{player?.Name?.ToUpper()}" +
                $"{Environment.NewLine}Broj dresa: {player?.ShirtNumber}" +
                $"{Environment.NewLine}{player?.Position}");
        }

        private void AddToFavourites_Click(object sender, EventArgs e)
        {
            if ((ParentForm as MainForm)?.GetFlpFavouritesCount() < 3 || playerIsFavourite)
            {
                AddPlayerToFavourites();
            }
            else
            {
                MessageBox.Show("Ne možete dodati više od tri omiljena igrača!");
            }
        }

        private void ChangePlayersImage_Click(object sender, EventArgs e)
            => ChangeImage();

        internal void AddPlayerToFavourites()
        {
            playerIsFavourite = !playerIsFavourite;

            if (playerIsFavourite) SetPlayerFavStatus("Ukloni iz favorita", "★", Color.Orange);
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
                BackgroundImage = Image.FromFile(ofp.FileName);
                lblName.ForeColor = Color.White;
                lblPosition.ForeColor = Color.White;
                lblShirtNumber.Visible = false;
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
                if (selectedPlayerCards.Count + (ParentForm as MainForm)?.GetFlpFavouritesCount() < 3 || playerIsFavourite)
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