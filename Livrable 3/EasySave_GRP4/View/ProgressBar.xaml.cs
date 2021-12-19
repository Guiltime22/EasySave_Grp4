using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using static EasySave_GRP4.Model.Model_Factory;
using Newtonsoft.Json;
using EasySave_GRP4.Model;
using System.Diagnostics;

namespace EasySave_GRP4.View
{
    public partial class ProgressBar : Window
    {
        int progression;
        public ProgressBar()
        {
            InitializeComponent();
            Thread Recup_Etat = new Thread(Suivit_Loaded);
            Recup_Etat.Start();
            Thread th = new Thread(serverEcoute);
            th.Start();
        }

        public void serverEcoute()
        {
            progression = 1;
            Server server = new Server();
            server.SeConnecter("127.0.0.1", 80);
            server.AccepterConnection();
            MessageBox.Show("Le client est connecté");
            string dataReceive = "";
            while (true)
            {
                dataReceive = server.EcouterReseau();
                Debug.WriteLine(dataReceive);
                if (dataReceive == "demande d info")
                {
                    
                   server.envoiData(progression.ToString());
                }
            }
        }

        private void Suivit_Loaded()
        {
            while (true)
            {
                
                Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Send, new Action(delegate ()
                {
                    Affi_Data.ItemsSource = View_Factory.CPT.Afficher_Data();
                    //progression = worksState[0].Progression.Replace("%", "");

                }));
                Thread.Sleep(800);
            }
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.CET.Play_Travail();
            StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonlang = rlang.ReadToEnd();
            JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
            if (Jlang.Langue == "French")
            {
                MessageBox.Show("Travaille résumé");
            }
            else if (Jlang.Langue == "English")
            {
                MessageBox.Show("Job is played");
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.CET.Pause_Travail();
            StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonlang = rlang.ReadToEnd();
            JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
            if (Jlang.Langue == "French")
            {
                MessageBox.Show("Travail pausé");
            }
            else if (Jlang.Langue == "English")
            {
                MessageBox.Show("Job is paused");
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.CET.Stop_Travail();
            StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonlang = rlang.ReadToEnd();
            JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
            if (Jlang.Langue == "French")
            {
                MessageBox.Show("Travail stoppé");
            }
            else if (Jlang.Langue == "English")
            {
                MessageBox.Show("Job is stopped");
            }
        }

        private void Aff_Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            
        }

        private void Affi_Data_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
