using System.Globalization;
using Utility.Managers;
using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class TeamSelectForm : Form
    {
        public TeamSelectForm()
        {
            SetFormLanguage(Settings.LangSelected);
            InitializeComponent();
        }

        private static void SetFormLanguage(Language language)
        {
            string culture = language == Language.Hrvatski ? "hr" : "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private void TeamSelectForm_Load(object sender, EventArgs e) 
            => FillFormAsync();

        private async void FillFormAsync()
        {
            try
            {
                await LoadDataFromManager();
                SetProgressBarLabel("Timovi uspješno učitani!", Color.Green);
                btnContinue.Enabled = true;
                cbTeams.Enabled = true;
            }
            catch
            {
                MessageBoxManager.ShowErrorMessage("Timovi nisu uspješno učitani!", "Greška");
                progressBar.Value = 100;
                SetProgressBarLabel("Timovi nisu uspješno učitani!", Color.Red);
            }
            UseWaitCursor = false;
        }

        private void SetProgressBarLabel(string text, Color color)
        {
            lblProgress.Text = text;
            lblProgress.ForeColor = color;
        }

        private async Task LoadDataFromManager()
        {
            ShowProgress(50);
            IList<Team>? teams = await TeamManager.GetAllTeams();
            ShowProgress(100);
            cbTeams.DataSource = teams;
        }

        private void ShowProgress(int progress)
        {
            Thread.Sleep(700);
            progressBar.Value = progress;
        }

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowWarningMessage() == DialogResult.OK)
            {
                SaveSettings();
                this.Hide();
                MainForm mainForm = new();
                mainForm.ShowDialog();
                this.Close();
            }
        }

        private void SaveSettings()
        {
            Settings.TeamSelected = cbTeams.SelectedItem as Team;
            SettingsManager.SaveSettings();
        }
    }
}