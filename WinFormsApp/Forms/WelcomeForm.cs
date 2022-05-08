using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm() 
            => InitializeComponent();

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowWarningMessage() == DialogResult.OK)
            {
                SetSettingsData();
                TeamSelectForm teamSelectForm = new();
                teamSelectForm.ShowDialog();
                this.Close();
            }
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

        private void btnCancel_Click(object sender, EventArgs e) 
            => this.Close();
    }
}