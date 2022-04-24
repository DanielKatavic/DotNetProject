using Utility.Managers;
using Utility.Models;
using WinFormsApp.UserControls;

namespace WinFormsApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly ISet<StartingEleven>? players;

        public MainForm()
        {
            try
            {
                players = PlayerManager.LoadPlayers();
            }
            catch 
            {
                MessageBox.Show("Igrači nisu uspješno učitani!");
                Application.Exit();
            }
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTeamName.Text = Settings.TeamSelected?.ToString();
            ShowPlayers();
        }

        internal void ShowFavouritePlayers(PlayerUserControl playerCard)
        {
            if (playerCard.playerIsFavourite)
            {
                flpFavourites.Controls.Add(playerCard);
                flpPlayers.Controls.Remove(playerCard);
            }
            else
            {
                flpFavourites.Controls.Remove(playerCard);
                flpPlayers.Controls.Add(playerCard);
            }
        }

        private void ShowPlayers() 
            => players?.ToList().ForEach(player => flpPlayers.Controls.Add(new PlayerUserControl(player)));

        private void Players_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            List<PlayerUserControl>? panelsList = e.Data?.GetData(typeof(List<PlayerUserControl>)) as List<PlayerUserControl>;
            if (panelsList[0].playerIsFavourite)
            {
                flpPlayers.AllowDrop = true;
                flpFavourites.AllowDrop = false;
            }
            else
            {
                flpPlayers.AllowDrop = false;
                flpFavourites.AllowDrop = true;
            }
        }

        private void Players_DragDrop(object sender, DragEventArgs e)
        {
            List<PlayerUserControl>? panelsList = e.Data?.GetData(typeof(List<PlayerUserControl>)) as List<PlayerUserControl>;
            panelsList?.ForEach(panel => panel.AddPlayerToFavourites());
            PlayerUserControl.ResetSelectedControls();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            PlayerManager.players = players;

            PlayerManager.LoadYellowCards();
            players?.ToList().ForEach(player => flpYellowCards.Controls.Add(new PlayerYellowCardControl(player)));

            PlayerManager.LoadGoals();
            players?.ToList().ForEach(player => flpGoals.Controls.Add(new PlayerGoalsControl(player)));
        }
    }
}