using System.ComponentModel;
using Utility.Dal;
using Utility.Managers;
using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class TeamSelectForm : Form
    {
        public TeamSelectForm() 
            => InitializeComponent();

        private void TeamSelectForm_Load(object sender, EventArgs e) 
            => backgroundWorker.RunWorkerAsync();

        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(700);
            backgroundWorker.ReportProgress(50);
            try
            {
                e.Result = Settings.AccessSelected
                          == Access.Online ? DataManager<Team>.LoadFromApi()
                          : DataManager<Team>.LoadFromFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
            Thread.Sleep(300);
            backgroundWorker.ReportProgress(100);
        }

        private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) 
            => progressBar.Value = e.ProgressPercentage;

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;
            if (e.Cancelled)
            {
                lblProgress.Text = "Timovi nisu uspješno učitani";
                lblProgress.ForeColor = Color.Red;
            }
            else
            {
                lblProgress.Text = "Timovi uspješno učitani";
                lblProgress.ForeColor = Color.Green;
                btnContinue.Enabled = true;
                cbTeams.DataSource = e.Result;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e) 
            => this.Close();

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            Settings.TeamSelected = cbTeams.SelectedItem as Team;
            this.Hide();
            MainForm mainForm = new();
            mainForm.ShowDialog();
            this.Close();
        }
    }
}