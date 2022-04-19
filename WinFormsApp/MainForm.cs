using Utility.Managers;
using Utility.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly ISet<StartingEleven>? _players = LoadPlayers();
        private readonly IList<PlayerCardControl> _playerCards = new List<PlayerCardControl>();

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
            _players?.ToList().ForEach(player => _playerCards.Add(new PlayerCardControl(player, this)));

            flpPlayers.Controls.AddRange(_playerCards.ToArray());
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
            PlayerCardControl? panel = e.Data?.GetData(typeof(PlayerCardControl)) as PlayerCardControl;
            if (panel.playerIsFavourite)
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
            PlayerCardControl? panel = e.Data?.GetData(typeof(PlayerCardControl)) as PlayerCardControl;
            panel?.AddPlayerToFavourites();
        }
    }
}