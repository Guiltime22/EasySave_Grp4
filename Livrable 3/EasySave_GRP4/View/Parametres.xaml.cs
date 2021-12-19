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

namespace EasySave_GRP4.View
{
    public partial class Parametres : Window
    {
        public Parametres()
        {
            InitializeComponent();
        }

        private void Parametres_Button_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.PR.Parametres(Langue.Text, Cryptage.Text, Metier.Text, Prioritaire_Copy.Text, Taille.Text);
            Close();
        }
    }
}
