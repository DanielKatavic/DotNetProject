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
            FillForm();
        }

        private void FillForm()
        {
            lblName.Text = player?.Name?.ToUpper();
            if(player?.NumberOfYellowCards == 1) imgYellowCard.Visible = true;
        }
    }
}