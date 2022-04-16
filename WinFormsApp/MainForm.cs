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
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTeamName.Text = Settings.TeamSelected;
            LoadPlayers();
            MessageBox.Show(Settings.TeamSelected);
        }

        private void LoadPlayers()
        {
            IList<Match>? matches = DataManager<Match>.LoadFromApi();
            IList<PlayerCard> playerCards = new List<PlayerCard>();

            var startingEleven = matches?[0].HomeTeamStatistics?.StartingEleven;
            var substitues = matches?[0].HomeTeamStatistics?.Substitutes;

            ISet<StartingEleven>? players = new HashSet<StartingEleven>(startingEleven);

            substitues?.ToList().ForEach(s => players.Add(s));
            
            players?.ToList().ForEach(player => playerCards.Add(new PlayerCard(player)));

            flowLayoutPanel.Controls.AddRange(playerCards.ToArray());
        }
    }
}