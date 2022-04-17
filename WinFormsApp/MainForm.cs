using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utility.Managers;
using Utility.Models;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        private readonly ISet<StartingEleven> _players = LoadPlayers();
        private readonly IList<PlayerCardForm> _playerCards = new List<PlayerCardForm>();

        public MainForm()
            => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTeamName.Text = Settings.TeamSelected?.ToString();
            ShowPlayers();
        }

        internal void ShowFavourites(PlayerCardForm playerCard)
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
            _players?.ToList().ForEach(player => _playerCards.Add(new PlayerCardForm(player, this)));

            flpPlayers.Controls.AddRange(_playerCards.ToArray());
        }

        private static ISet<StartingEleven> LoadPlayers()
        {
            IList<Match>? matches = DataManager<Match>.LoadFromApi();

            var teamIndex = matches?.ToList().FindIndex(m => m.HomeTeam?.Country == Settings.TeamSelected?.Country);

            var startingEleven = matches?[(int)teamIndex].HomeTeamStatistics?.StartingEleven;
            var substitues = matches?[(int)teamIndex].HomeTeamStatistics?.Substitutes;

            ISet<StartingEleven>? players = new HashSet<StartingEleven>(startingEleven);

            substitues?.ToList().ForEach(s => players.Add(s));

            return players;
        }
    }
}