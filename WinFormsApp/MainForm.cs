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
        public MainForm() 
            => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTeamName.Text = Settings.TeamSelected?.ToString();
            ShowPlayers();
        }

        private void ShowPlayers()
        {
            ISet<StartingEleven> players = LoadPlayers();
            IList<PlayerCardForm> playerCards = new List<PlayerCardForm>();

            players?.ToList().ForEach(player => playerCards.Add(new PlayerCardForm(player)));

            flowLayoutPanel.Controls.AddRange(playerCards.ToArray());
        }

        private ISet<StartingEleven> LoadPlayers()
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