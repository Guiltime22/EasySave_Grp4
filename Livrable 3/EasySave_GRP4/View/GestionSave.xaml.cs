using System;
using System.Collections.Generic;
using System.Data;
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
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class GestionSave : Window
    {

        private void Aff_Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
        private void buttonSourceFolderDialog_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                textBoxSource.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {

                MessageBox.Show("Le répertoire source précisé est vide");

            }
        }
        private void buttonDestFolderDialog_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Ookii.Dialogs.Wpf.VistaFolderBrowserDialog openDlg = new Ookii.Dialogs.Wpf.VistaFolderBrowserDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                textBoxDestination.Text = openDlg.SelectedPath;
                // TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
            else
            {

                MessageBox.Show("Le répertoire Destination précisé est vide");

            }
        }
        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Aff_Data.ItemsSource = View_Factory.CET.Afficher_le_travail();
        }
        public GestionSave()
        {
            InitializeComponent();
        }

        private void Modifier_Click(object sender, RoutedEventArgs e) //bouton modifier +supprimer, passe en paramètres ce qu'il faut 
        {
            if (textBoxName.Text != "" && textBoxSource.Text != "" && textBoxDestination.Text != "" && ComboType.Text != "")
            {

                View_Factory.GT.Modifier_Travail(textBoxName.Text, textBoxSource.Text, textBoxDestination.Text, ComboType.Text);
               
            }
            else
            {
                MessageBox.Show("Veuillez remplir tout les champs");
            }

        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != "")
            {

                View_Factory.GT.Supprimer_Travail(textBoxName.Text);
               
            }
            else
            {
                MessageBox.Show("Veuillez remplir tout les champs");
            }
        }
    }
}
