using Utility.Managers;
using Utility.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly ISet<StartingEleven>? players = LoadPlayers();
        private readonly IList<PlayerCardControl> playerCards = new List<PlayerCardControl>();

        public MainForm()
            => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTeamName.Text = Settings.TeamSelected?.ToString();
            ShowPlayers();
        }

        internal void ShowFavouritePlayers(PlayerCardControl playerCard)
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
        {
            players?.ToList().ForEach(player => playerCards.Add(new PlayerCardControl(player, this)));

            flpPlayers.Controls.AddRange(playerCards.ToArray());
        }

        private static ISet<StartingEleven>? LoadPlayers()
        {
            IList<Match>? matches = DataManager<Match>.LoadFromApi();

            var teamIndex = matches?.ToList().FindIndex(m => m.HomeTeam?.Country == Settings.TeamSelected?.Country);

            return matches?[(int)teamIndex].HomeTeamStatistics?.AllPlayers;
        }

        private void Players_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            List<PlayerCardControl>? panelsList = e.Data?.GetData(typeof(List<PlayerCardControl>)) as List<PlayerCardControl>;
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
            List<PlayerCardControl>? panelsList = e.Data?.GetData(typeof(List<PlayerCardControl>)) as List<PlayerCardControl>;
            panelsList?.ToList().ForEach(panel => panel.AddPlayerToFavourites());
            PlayerCardControl.ResetSelectedControls();
        }
    }
}