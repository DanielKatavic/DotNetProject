using Utility.Managers;
using Utility.Models;
using WinFormsApp.UserControls;

namespace WinFormsApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly ISet<StartingEleven>? players;
        private readonly IList<Match>? matches;

        private readonly ISet<StartingEleven>? playersWithYellowCards;
        private readonly ISet<StartingEleven>? playersWithGoals;

        public MainForm()
        {
            try
            {
                PlayerManager.ResetCollections();
                players = PlayerManager.GetAllPlayers();
                matches = MatchManager.GetAllMatches();
                playersWithYellowCards = PlayerManager.GetPlayersWithYellowCards();
                playersWithGoals = PlayerManager.GetPlayersWithGoals();
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
            => players?.OrderBy(p => p.ShirtNumber).ToList().ForEach(player => flpPlayers.Controls.Add(new PlayerUserControl(player)));

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
            if (GetFlpFavouritesCount() < 3 || panelsList[0].playerIsFavourite)
            {
                panelsList?.ForEach(panel => panel.AddPlayerToFavourites());
            }
            else
            {
                MessageBox.Show("Ne možete dodati više od tri omiljena igrača!");
            }
            PlayerUserControl.ResetSelectedControls();
        }

        internal int GetFlpFavouritesCount() 
            => flpFavourites.Controls.Count;

        private void SecondPage_Enter(object sender, EventArgs e)
        {
            ClearSecondPage();
            FillSecondPage();
        }

        private void ThirdPage_Enter(object sender, EventArgs e)
        {
            ClearThirdPage();
            FillThirdPage();
        }

        private void ClearSecondPage()
        {
            flpYellowCards.Controls.Clear();
            flpGoals.Controls.Clear();
        }

        private void FillSecondPage()
        {
            playersWithYellowCards?
                .OrderByDescending(p => p.NumberOfYellowCards)
                .ToList().ForEach(player => flpYellowCards.Controls.Add(new PlayerYellowCardControl(player)));
            
            playersWithGoals?
                .OrderByDescending(p => p.NumberOfGoals)
                .ToList().ForEach(player => flpGoals.Controls.Add(new PlayerGoalsControl(player)));
        }

        private void ClearThirdPage() 
            => flpMatches.Controls.Clear();

        private void FillThirdPage() 
            => matches?
                .OrderByDescending(m => m.Attendance)
                .ToList().ForEach(match => flpMatches.Controls.Add(new TeamMatchesControl(match)));

        private void Settings_Click(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new();
            if (welcomeForm.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void ChangeLangToCro_Click(object sender, EventArgs e)
        {

        }

        private void ChangeLangToEng_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Dispose();
            InitializeComponent();
        }
    }
}