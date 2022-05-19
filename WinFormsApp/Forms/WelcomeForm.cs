using Utility.Managers;
using Utility.Models;

namespace WinFormsApp.Forms
{
    public partial class WelcomeForm : Form
    {
        private readonly MainForm? mainForm;

        public WelcomeForm()
            => InitializeComponent();

        public WelcomeForm(MainForm mainForm) : this()
            => this.mainForm = mainForm;

        private void WelcomeForm_Load(object sender, EventArgs e)
            => SetComboBoxesValues();

        private void BtnContinue_Click(object sender, EventArgs e)
        {
            if (MessageBoxManager.ShowWarningMessage() == DialogResult.OK)
            {
                SetSettingsData();
                TeamSelectForm teamSelectForm = new(mainForm);
                if (mainForm is null)
                {
                    this.Hide();
                    teamSelectForm.FormClosing += (s, e) => this.Close();
                    teamSelectForm.Show();
                }
                else
                {
                    teamSelectForm.ShowDialog();
                }
            }
        }

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
            SettingsManager.SetFormLanguage(selectedLanguage);
            ResetForm(cbLanguage.SelectedIndex);
        }

        private void ResetForm(int selectedIndex)
        {
            Controls.Clear();
            InitializeComponent();
            SetComboBoxesValues();
            cbLanguage.SelectedIndex = selectedIndex;
        }
    }
}