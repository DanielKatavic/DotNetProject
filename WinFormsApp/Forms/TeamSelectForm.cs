using Utility.Managers;
using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class TeamSelectForm : Form
    {
        public TeamSelectForm() 
            => InitializeComponent();

        private void TeamSelectForm_Load(object sender, EventArgs e)
        {
            try
            {
                FillFormAsync();
            }
            catch
            {
                MessageBoxManager.ShowErrorMessage("Timovi nisu uspješno učitani!", "Greška");
                lblProgress.Text = "Timovi nisu uspješno učitani";
                lblProgress.ForeColor = Color.Red;
            }
        }

        private async void FillFormAsync()
        {
            await LoadDataFromManager();
            UseWaitCursor = false;
            lblProgress.Text = "Timovi uspješno učitani";
            lblProgress.ForeColor = Color.Green;
            btnContinue.Enabled = true;
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

        private void BtnCancel_Click(object sender, EventArgs e) 
            => this.Close();

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
            SettingsManager.SaveSettings(Settings.ParseForFileLine());
        }
    }
}