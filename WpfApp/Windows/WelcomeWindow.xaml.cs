﻿using System;
using System.Windows;
using Utility.Models;
using Utility.Managers;
using System.Windows.Controls;
using System.Reflection;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WelcomeWindow : Window
    {
        public WelcomeWindow()
        {
            SetLanguage();
            InitializeComponent();
            FillWindow();
        }

        private void SetLanguage()
            => SettingsManager.SetFormLanguage();

        private void FillWindow()
        {
            cbGender.ItemsSource = Enum.GetValues(typeof(Gender));
            cbLanguage.ItemsSource = Enum.GetValues(typeof(Language));
            cbLanguage.DropDownClosed += CbLanguage_DropDownClosed;
        }

        private void CbLanguage_DropDownClosed(object? sender, EventArgs e)
        {
            Settings.LangSelected = (Language)cbLanguage.SelectedItem;
            SetLanguage();
            RefreshWindow();
        }

        private void RefreshWindow()
        {
            this.Title = Properties.Resources.welcome;
            lblWelcome.Content = Properties.Resources.welcome;
            lblGender.Content = Properties.Resources.genderSelect;
            lblLanguage.Content = Properties.Resources.langSelect;
            lblResolution.Content = Properties.Resources.resolutionSelect;
            chbIsFullScreen.Content = Properties.Resources.fullscreen;
            btnAccept.Content = Properties.Resources.accept;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
            => cbResolution.Visibility = cbResolution.Visibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;

        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            bool windowIsDialog = IsModal();

            if (MessageBox.Show(Properties.Resources.mbWarningText, Properties.Resources.mbWarningCaption, MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                SaveSettings();
                MainWindow mainWindow = new();
                mainWindow.Show();
                if (windowIsDialog) this.DialogResult = true;
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => SaveSettings();

        private void SaveSettings()
        {
            Settings.LangSelected = (Language)cbLanguage.SelectedItem;
            Settings.GenderSelected = (Gender)cbGender.SelectedItem;
            Settings.IsFullScreen = chbIsFullScreen.IsChecked.Value;
            ComboBoxItem? selectedResolution = cbResolution.SelectedItem as ComboBoxItem;
            Settings.SaveResolution(selectedResolution?.Content.ToString());
            SettingsManager.SaveSettings();
        }

        public bool IsModal()
            => (bool)typeof(Window).GetField("_showingAsDialog", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(this);

    }
}
