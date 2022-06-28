using Utility.Managers;
using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class TeamSelectForm : Form
    {
        private MainForm? mainForm;

        public TeamSelectForm()
        {
            SettingsManager.SetFormLanguage();
            InitializeComponent();
        }

        public TeamSelectForm(MainForm? mainForm) : this()
            => this.mainForm = mainForm;

        private void TeamSelectForm_Load(object sender, EventArgs e)
            => FillFormAsync();

        private async void FillFormAsync()
        {
            try
            {
                if (!InternetAvailability.IsInternetAvailable())
                {
                    MessageBoxManager.ShowNoConnectionMessage();
                    Settings.AccessSelected = Access.Offline;
                }
                await LoadDataFromManager();
                SetProgressBarLabel("Timovi uspješno učitani!", Color.Green);
                btnContinue.Enabled = true;
                cbTeams.Enabled = true;
            }
            catch (Exception)
            {
                MessageBoxManager.ShowErrorMessage("Timovi nisu uspješno učitani!", "Greška");
                progressBar.Value = 100;
                SetProgressBarLabel("Timovi nisu uspješno učitani!", Color.Red);
            }
            UseWaitCursor = false;
        }

        private void ResetForm()
        {
            Controls.Clear();
            InitializeComponent();
            FillFormAsync();
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
            if (teams is null) throw new Exception();
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
                if (mainForm is null)
                {
                    this.Hide();
                    mainForm = new MainForm();
                    mainForm.FormClosing += (s, e) => this.Close();
                    mainForm.Show();
                }
            }
        }

        private void SaveSettings()
        {
            Settings.TeamSelected = cbTeams.SelectedItem as Team;
            SettingsManager.SaveSettings();
        }

        private void BtnCancel_Click(object sender, EventArgs e) => this.Close();
    }
}