using System.ComponentModel;
using Utility.Dal;
using Utility.Managers;
using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class TeamSelectForm : Form
    {
        private readonly IRepository _repository;

        public TeamSelectForm()
        {
            _repository = RepositoryFactory.GetRepository();
            InitializeComponent();
        }

        private void TeamSelectForm_Load(object sender, EventArgs e) 
            => backgroundWorker.RunWorkerAsync();

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(700);
            backgroundWorker.ReportProgress(50);
            Thread.Sleep(700);
            backgroundWorker.ReportProgress(100);

            try
            {
                e.Result = Settings.AccessSelected
                          == Access.Online ? DataManager<Team>.LoadFromApi()
                          : DataManager<Team>.LoadFromFile(_repository.LoadFile());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                e.Cancel = true;
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) 
            => progressBar.Value = e.ProgressPercentage;

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e) 
            => Close();

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Settings.TeamSelected = cbTeams.SelectedItem as Team;
            this.Hide();
            MainForm mainForm = new();
            mainForm.Show();
            this.Close();
        }
    }
}