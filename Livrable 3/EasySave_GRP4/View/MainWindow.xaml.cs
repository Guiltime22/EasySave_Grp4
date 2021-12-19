using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static EasySave_GRP4.Model.Model_Factory;

namespace EasySave_GRP4.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
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
                CreateSave.Content = "Crée un travail de sauvegarde";
                ExecuteSave.Content = "Executer un travail de sauvegarde";
                Gestion.Content = "Gerer les travaux";
            }
            else if (Jlang.Langue == "English")
            {
                CreateSave.Content = "Create a save job";
                ExecuteSave.Content = "Execute a save job";
                Gestion.Content = "Manage save jobs";
            }
        }

        private void CreateSave_Click(object sender, RoutedEventArgs e)
        {
            View.CreateSave Create_Dialog = new View.CreateSave();
            Create_Dialog.Show();
        }

        private void ExecuteSave_Click(object sender, RoutedEventArgs e)
        {
            View.ExecuteSave Execute_Dialog = new View.ExecuteSave();
            Execute_Dialog.Show();
        }

        private void Parametres_Click(object sender, RoutedEventArgs e)
        {
            View.Parametres parametres = new View.Parametres();
            parametres.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            View.GestionSave Execute_Dialog = new View.GestionSave();
            Execute_Dialog.Show();
        }
    }
}
