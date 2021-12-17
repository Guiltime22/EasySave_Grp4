using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace EasySave_GRP4
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Mutex _mutex = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            const string AppName = "EASYSAVE_GRP4";
            bool OpenApp;

            _mutex = new Mutex(true, AppName, out OpenApp);

            if (!OpenApp)
            {
                //app is already running! Exiting the application  
                MessageBox.Show("App is already running my dude !");
                Application.Current.Shutdown();
            }
            base.OnStartup(e);
        }
    }
}
