using System.Drawing.Printing;
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
            => FillFormAsync();

        private async void FillFormAsync()
        {
            try
            {
                await LoadDataFromManager();
                lblTeamName.Text = Settings.TeamSelected?.Country;
                ShowPlayers();
                tabControl.Visible = true;
            }
            catch
            {
                MessageBoxManager.ShowErrorMessage("Igrači nisu uspješno učitani", "Greška");
                Application.Exit();
            }
        }

        private async Task LoadDataFromManager()
        {
            PlayerManager.ResetCollections();
            ShowProgress(15);
            players = await PlayerManager.GetAllPlayers();
            ShowProgress(30);
            PlayerManager.LoadFavouritePlayers();
            ShowProgress(45);
            PlayerManager.LoadPlayersWithImage();
            ShowProgress(60);
            matches = await MatchManager.GetAllMatches();
            ShowProgress(75);
            playersWithYellowCards = PlayerManager.GetPlayersWithYellowCards();
            ShowProgress(90);
            playersWithGoals = PlayerManager.GetPlayersWithGoals();
            ShowProgress(100);
        }

        private void ShowProgress(int progress)
        {
            progressBar.Value = progress;
            lblProgress.Text = $"{progress}%";
        }

        internal void ShowFavouritePlayers(PlayerUserControl playerUC)
        {
            if (playerUC.player.IsFavouritePlayer)
            {
                flpFavourites.Controls.Add(playerUC);
                flpPlayers.Controls.Remove(playerUC);
            }
            else
            {
                flpFavourites.Controls.Remove(playerUC);
                flpPlayers.Controls.Add(playerUC);
            }
        }

        private void ShowPlayers()
            => players?.OrderBy(p => p.ShirtNumber).ToList().ForEach(player => flpPlayers.Controls.Add(new PlayerUserControl(player)));

        private void Players_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            List<PlayerUserControl>? panelsList = e.Data?.GetData(typeof(List<PlayerUserControl>)) as List<PlayerUserControl>;
            if (panelsList is null) return;
            if (panelsList[0].player.IsFavouritePlayer)
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
            if (e.Data?.GetData(typeof(List<PlayerUserControl>)) is not List<PlayerUserControl> panelsList) return;
            if (GetFlpFavouritesCount() < 3 || panelsList[0].player.IsFavouritePlayer)
            {
                panelsList?.ForEach(panel => panel.AddPlayerToFavourites());
            }
            else
            {
                MessageBoxManager.ShowErrorMessage();
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
                .ToList().ForEach(match =>
                {
                    if (match.HomeTeam?.Country == Settings.TeamSelected?.Country
                    || match.AwayTeam?.Country == Settings.TeamSelected?.Country)
                    {
                        flpMatches.Controls.Add(new TeamMatchesControl(match));
                    }
                });

        private void SettingsIcon_Click(object sender, EventArgs e)
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
            ResetForm();
        }

        private void ChangeLangToEng_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            ResetForm();
        }

        private void ResetForm()
        {
            ShowProgress(0);
            Controls.Clear();
            InitializeComponent();
            FillFormAsync();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
            => PlayerManager.SaveFavouritePlayers();

        private void YellowCards_PrintPage(object sender, PrintPageEventArgs e) 
            => PrintManager.PrintPlayers(flpYellowCards, e);

        private void Goals_PrintPage(object sender, PrintPageEventArgs e) 
            => PrintManager.PrintPlayers(flpGoals, e);

        private void Matches_PrintPage(object sender, PrintPageEventArgs e) 
            => PrintManager.PrintMatches(flpMatches, e);

        private void Print_Click(object sender, EventArgs e)
        {
            ContextMenuStrip? owner = ((ToolStripItem)sender).Owner as ContextMenuStrip;
            string? panelName = owner?.SourceControl.Name;
            printPreviewDialog.Document = GetCorrectDocument(panelName ?? string.Empty);
            printPreviewDialog.ShowDialog();
        }

        private PrintDocument GetCorrectDocument(string panelName)
        {
            return panelName switch
            {
                nameof(flpYellowCards) => printDocYellowCards,
                nameof(flpGoals) => printDocGoals,
                nameof(flpMatches) => printDocMatches,
                _ => new PrintDocument(),
            };
        }
    }
}