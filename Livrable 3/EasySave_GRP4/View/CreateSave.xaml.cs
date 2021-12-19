using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
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
    public partial class CreateSave : Window
    {
        public CreateSave()
        {
            InitializeComponent();
            SwapLanguage();
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
                buttonCreateSave.Content ="Crée la sauvegarde" ;
            }
            else if (Jlang.Langue == "English")
            {
                labelName.Content = "Name : ";
                labelDest.Content = "Destination : ";
                labelSource.Content = "Source : ";
                labelType.Content = "Type : ";
                buttonCreateSave.Content = "Create save";
            }
        }



private void buttonSourceFolderDialog_Click(object sender, RoutedEventArgs e)
        {
            
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog(); // Create OpenFileDialog
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
            
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog(); // Create OpenFileDialog
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

        private void buttonCreateSave_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text !="" && textBoxSource.Text !="" && textBoxDestination.Text !="" && ComboType.Text !="")
            {
                View_Factory.CCT.Create_Travail(textBoxName.Text, textBoxSource.Text, textBoxDestination.Text, ComboType.Text);
                Close();
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
