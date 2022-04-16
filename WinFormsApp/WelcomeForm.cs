using Utility.Dal;
using Utility.Managers;
using Utility.Models;

namespace WinFormsApp
{
    public partial class WelcomeForm : Form
    {
        private readonly IRepository _repository;

        public WelcomeForm()
        {
            _repository = RepositoryFactory.GetRepository();
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Jeste li sigurni da želite izaæi?", "Izlaz", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK) Application.Exit();
        }

        private void WelcomeForm_FormClosing(object sender, FormClosingEventArgs e) 
            => _repository.SaveSettings(SettingsManager.ParseForFileLine());

        private void btnContinue_Click(object sender, EventArgs e)
        {
            SetSettingsData();
            //this.Hide();
            TeamSelectForm teamSelectForm = new();
            teamSelectForm.ShowDialog();
            //this.Close();
        }

        private void WelcomeForm_Load(object sender, EventArgs e) 
            => SetComboBoxesValues();

        private void SetSettingsData()
        {
            Settings.GenderSelected = (Gender)cbGender.SelectedItem;
            Settings.LangSelected = (Language)cbLanguage.SelectedItem;
            Settings.AccessSelected = (Access)cbAccess.SelectedItem;
        }

        private void SetComboBoxesValues()
        {
            cbGender.DataSource = Enum.GetValues(typeof(Gender));
            cbLanguage.DataSource = Enum.GetValues(typeof(Language));
            cbAccess.DataSource = Enum.GetValues(typeof(Access));
        }
    }
}