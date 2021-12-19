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
    public partial class CreateSave : Window
    {
        public CreateSave()
        {
            InitializeComponent();
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
               MessageBox.Show("Le répertoire source précisé est vide");   
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
                MessageBox.Show("Le répertoire Destination précisé est vide");   
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
                MessageBox.Show("Veuillez remplir tout les champs");
            }

        }
    }
}
