using System.Globalization;
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
                TeamSelectForm teamSelectForm = new();
                if (teamSelectForm.ShowDialog() == DialogResult.OK)
                {
                    SetSettingsData();
                    this.Close();
                }
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

        private void BtnCancel_Click(object sender, EventArgs e) => this.Close();

        private void LanguageChanged(object sender, EventArgs e)
        {
            Language selectedLanguage = (Language)cbLanguage.SelectedItem;
            SetFormLanguage(selectedLanguage);
            ResetForm(cbLanguage.SelectedIndex);
        }

        private void ResetForm(int selectedIndex)
        {
            Controls.Clear();
            InitializeComponent();
            SetComboBoxesValues();
            cbLanguage.SelectedIndex = selectedIndex;
        }

        private static void SetFormLanguage(Language language)
        {
            string culture = language == Language.Hrvatski ? "hr" : "en";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
    }
}