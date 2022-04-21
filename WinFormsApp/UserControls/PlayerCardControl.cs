using Utility.Models;
using WinFormsApp.Forms;

namespace WinFormsApp.UserControls
{
    public partial class PlayerCardControl : UserControl
    {
        private readonly StartingEleven? player;
        private static IList<PlayerCardControl> selectedPlayerCards = new List<PlayerCardControl>();
        
        internal bool playerIsFavourite = false;

        public PlayerCardControl(StartingEleven player)
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
            if (player.Captain) lblCaptain.Visible = true;
        }

        private void AddToFavourites_Click(object sender, EventArgs e) 
            => AddPlayerToFavourites();

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
                Filter = "Images|*.png;*.jpg;*.jpeg",
                Title = "Change players image",
                InitialDirectory = Application.StartupPath
            };
            if (ofp.ShowDialog() == DialogResult.OK)
            {
                BackgroundImage = Image.FromFile(ofp.FileName);
            }
        }

        private void PlayerCardControl_MouseDown(object sender, MouseEventArgs e)
        {
            object data = selectedPlayerCards.Count == 0 ? new List<PlayerCardControl> { this } : selectedPlayerCards;

            if (e.Button == MouseButtons.Left)
            {
                if (sender is PlayerCardControl pcc) pcc.DoDragDrop(data, DragDropEffects.Move);
                if (sender is Label lbl) lbl.DoDragDrop(data, DragDropEffects.Move);
                
            }
            if (e.Button == MouseButtons.Left && (ModifierKeys & Keys.Control) == Keys.Control)
            {
                BorderStyle = BorderStyle.Fixed3D;
                selectedPlayerCards?.Add(this);
            }
        }

        internal static void ResetSelectedControls()
        {
            selectedPlayerCards.ToList().ForEach(spc => spc.BorderStyle = BorderStyle.None);
            selectedPlayerCards?.Clear();
        }
    }
}