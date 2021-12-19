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
    public partial class Parametres : Window
    {
        public Parametres()
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
                Lang.Content = "Langue";
                crypt.Content = "Fichier a cryptage";
                met.Content = "Logiciel métier";
                prio.Content = "Type prioritaire";
                nko.Content = "Limite en ko";
                Parametres_Button.Content = "Enregistrer";
            }
            else if (Jlang.Langue == "English")
            {
                Lang.Content = "Language";
                crypt.Content = "File to crypt";
                met.Content = "Job application";
                prio.Content = "Priority files";
                nko.Content = "Max size in ko";
                Parametres_Button.Content = "Save";
            }
        }

        private void Parametres_Button_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.PR.Parametres(Langue.Text, Cryptage.Text, Metier.Text, Prioritaire_Copy.Text, Taille.Text);
            Close();
        }
    }
}
