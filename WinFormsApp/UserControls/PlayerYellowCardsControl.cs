using Utility.Models;

namespace WinFormsApp.UserControls
{
    public partial class PlayerYellowCardControl : UserControl
    {
        private readonly StartingEleven? player;

        public PlayerYellowCardControl(StartingEleven player)
        {
            InitializeComponent();
            this.player = player;
            DoubleBuffered = true;
            CheckIfImageExists();
            FillForm();
        }

        private void FillForm()
        {
            lblName.Text = player?.Name?.ToUpper();
            imgYellowCard.Visible = player?.NumberOfYellowCards >= 1;
            lblNumberOfCards.Visible = player?.NumberOfYellowCards >= 1;
            lblNumberOfCards.Text = player?.NumberOfYellowCards.ToString();
        }

        private void CheckIfImageExists()
        {
            if (player?.PicturePath is not null)
            {
                SetImageToPlayer(player.PicturePath);
            }
        }

        private void SetImageToPlayer(string path)
        {
            BackgroundImage = Image.FromFile(path);
        }
    }
}