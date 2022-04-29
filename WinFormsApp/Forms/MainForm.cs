using Utility.Managers;
using Utility.Models;
using WinFormsApp.UserControls;

namespace WinFormsApp.Forms
{
    public partial class MainForm : Form
    {
        private ISet<StartingEleven>? players;
        private IList<Match>? matches;

        private ISet<StartingEleven>? playersWithYellowCards;
        private ISet<StartingEleven>? playersWithGoals;

        public MainForm() 
            => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                FillFormAsync();
            }
            catch
            {
                MessageBox.Show("Igrači nisu uspješno učitani!");
                Application.Exit();
            }
        }

        private async void FillFormAsync()
        {
            await LoadDataFromManager();
            lblTeamName.Text = Settings.TeamSelected?.Country;
            ShowPlayers();
            tabControl.Visible = true;
        }

        private async Task LoadDataFromManager()
        {
            PlayerManager.ResetCollections();
            ShowProgress(20);
            await PlayerManager.LoadAllPlayers();
            players = PlayerManager.Players;
            ShowProgress(40);
            matches = await MatchManager.GetAllMatches();
            ShowProgress(60);
            playersWithYellowCards = PlayerManager.GetPlayersWithYellowCards();
            ShowProgress(80);
            playersWithGoals = PlayerManager.GetPlayersWithGoals();
            ShowProgress(100);
        }

        private void ShowProgress(int progress)
        {
            progressBar.Value = progress;
            lblProgress.Text = $"{progress}%";
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
            if (panelsList is null) return;
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
            if (panelsList is null) return;
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
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("hr");
            Controls.Clear();
            InitializeComponent();
            FillFormAsync();
        }

        private void ChangeLangToEng_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            Controls.Clear();
            InitializeComponent();
            FillFormAsync();
        }
    }
}