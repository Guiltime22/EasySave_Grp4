using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using static EasySave_GRP4.Model.Model_Factory;

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
                StreamReader r = new StreamReader(@"..\..\..\Config\Parametres.json");
                string jsonlang = r.ReadToEnd();
                JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
                if (Jlang.Langue == "French")
                {
                    MessageBox.Show("L'application est déja en cours d'execution !");
                }
                else if (Jlang.Langue == "English")
                {
                MessageBox.Show("App is already running !");
                }
                Application.Current.Shutdown();
            }
            base.OnStartup(e);
        }
    }
}
