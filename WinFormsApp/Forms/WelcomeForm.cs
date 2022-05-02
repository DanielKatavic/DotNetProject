using Utility.Dal;
using Utility.Managers;
using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void WelcomeForm_FormClosing(object sender, FormClosingEventArgs e) 
            => SettingsManager.SaveSettings(Settings.ParseForFileLine());

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            SetSettingsData();
            this.Hide();
            TeamSelectForm teamSelectForm = new();
            teamSelectForm.ShowDialog();
            this.Close();
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