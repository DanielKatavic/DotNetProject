using System;
using System.Windows;
using Utility.Models;
using Utility.Managers;
using System.Windows.Controls;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            InitializeComponent();
            FillWindow();
        }

        private void FillWindow()
        {
            cbGender.ItemsSource = Enum.GetValues(typeof(Utility.Models.Gender));
            cbLanguage.ItemsSource = Enum.GetValues(typeof(Utility.Models.Language));
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            cbResolution.Visibility = cbResolution.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to proceed?", "Alert", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
            {
                SaveSettings();
                MainWindow mainWindow = new();
                mainWindow.Show();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
        }

        private void SaveSettings()
        {
            Settings.LangSelected = (Language)cbLanguage.SelectedItem;
            Settings.GenderSelected = (Gender)cbGender.SelectedItem;
            Settings.IsFullScreen = chbIsFullScreen.IsChecked.Value;
            ComboBoxItem? selectedResolution = cbResolution.SelectedItem as ComboBoxItem;
            Settings.SaveResolution(selectedResolution?.Content.ToString());
            SettingsManager.SaveSettings();
        }
    }
}
