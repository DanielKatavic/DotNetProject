using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Utility.Dal;
using Utility.Managers;
using Utility.Models;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            if (FileRepository.SettingsExists())
            {
                SettingsManager.LoadSettings();
            }
            StartupUri = new Uri(FileRepository.SettingsExists() ? $"{nameof(MainWindow)}.xaml" : $"{nameof(WelcomeWindow)}.xaml", UriKind.Relative);
            base.OnStartup(e);
        }
    }
}
