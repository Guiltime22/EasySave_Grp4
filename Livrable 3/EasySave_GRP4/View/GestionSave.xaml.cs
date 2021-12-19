using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static EasySave_GRP4.Model.Model_Factory;

namespace EasySave_GRP4.View
{
    public partial class GestionSave : Window
    {

        private void Aff_Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void buttonSourceFolderDialog_Click(object sender, RoutedEventArgs e)
        {
            
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            Nullable<bool> result = openDlg.ShowDialog();
            
            if (result == true)
            {
                textBoxSource.Text = openDlg.SelectedPath;
            }
            else
            {


                StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
                string jsonlang = rlang.ReadToEnd();
                JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
                if (Jlang.Langue == "French")
                {
                    MessageBox.Show("Le répertoire source précisé est vide");
                }
                else if (Jlang.Langue == "English")
                {
                    MessageBox.Show("Source directory is empty");
                }

            }
        }
        private void buttonDestFolderDialog_Click(object sender, RoutedEventArgs e)
        {
            
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();
            Nullable<bool> result = openDlg.ShowDialog();
            
            if (result == true)
            {
                textBoxDestination.Text = openDlg.SelectedPath;
            }
            else
            {

                StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
                string jsonlang = rlang.ReadToEnd();
                JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
                if (Jlang.Langue == "French")
                {
                    MessageBox.Show("Le répertoire destinataire précisé est vide");
                }
                else if (Jlang.Langue == "English")
                {
                    MessageBox.Show("destination directory is empty");
                }

            }
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
        private void Aff_Loaded()
        {
            while (true)
            {
                
                Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Send, new Action(delegate ()
                {
                    Aff_Data.ItemsSource = View_Factory.CET.Afficher_le_travail();
                }));
                Thread.Sleep(800);
            }
        }
        public GestionSave()
        {
            InitializeComponent();
            SwapLanguage();
            Thread Aff = new Thread(Aff_Loaded);
            Aff.Start();
        }

        public void SwapLanguage()
        {
            StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
            string jsonlang = rlang.ReadToEnd();
            JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
            if (Jlang.Langue == "French")
            {
                labelName.Content = "Nom : ";
                labelDest.Content = "Destination : ";
                labelSource.Content = "Source : ";
                labelType.Content = "Type : ";
                Modifier.Content = "Modifier";
                Supprimer.Content = "Supprimer";
            }
            else if (Jlang.Langue == "English")
            {
                labelName.Content = "Name : ";
                labelDest.Content = "Destination : ";
                labelSource.Content = "Source : ";
                labelType.Content = "Type : ";
                Modifier.Content = "Modify";
                Supprimer.Content = "Delete";
            }

        }

        private void Modifier_Click(object sender, RoutedEventArgs e) //modify and delete button 
        {
            if (textBoxName.Text != "" && textBoxSource.Text != "" && textBoxDestination.Text != "" && ComboType.Text != "")
            {

                View_Factory.GT.Modifier_Travail(textBoxName.Text, textBoxSource.Text, textBoxDestination.Text, ComboType.Text);
                MessageBox.Show("Travail modifié");
               
            }
            else
            {
                StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
                string jsonlang = rlang.ReadToEnd();
                JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
                if (Jlang.Langue == "French")
                {
                MessageBox.Show("Veuillez remplir tout les champs");
                }
                else if (Jlang.Langue == "English")
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }

        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != "")
            {

                View_Factory.GT.Supprimer_Travail(textBoxName.Text);
                MessageBox.Show("Travail supprimé");
               
            }
            else
            {
                StreamReader rlang = new StreamReader(@"..\..\..\Config\Parametres.json");
                string jsonlang = rlang.ReadToEnd();
                JFile_parametres Jlang = JsonConvert.DeserializeObject<JFile_parametres>(jsonlang);
                if (Jlang.Langue == "French")
                {
                    MessageBox.Show("Veuillez remplir tout les champs");
                }
                else if (Jlang.Langue == "English")
                {
                    MessageBox.Show("Please fill all the fields");
                }
            }
        }
    }
}
