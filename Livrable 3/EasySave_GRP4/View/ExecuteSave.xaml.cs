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
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class ExecuteSave : Window
    {
        
        public ExecuteSave()
        {
            InitializeComponent();
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Aff_Data.ItemsSource = View_Factory.CET.Afficher_Travail();
        }

        private void Execute_Button_Click(object sender, RoutedEventArgs e)
        {
           View.ProgressBar Progress_Dialog = new View.ProgressBar();
           Progress_Dialog.Show();
            /*if (Execute_Unique.IsChecked == true)
            {
                
                View_Factory.CET.Executer_Travail_Unique(Execute_N.Text);
                Close();
           
            }
            else if(Execute_Seq.IsChecked == true)
            {

                View_Factory.CET.Executer_Travail_Seq();
                Close();
               
            }
       

    */
        }

        private void Execute_Unique_Checked(object sender, RoutedEventArgs e)
        {
            Execute_N.IsEnabled = true;
        }

        private void Execute_Seq_Checked(object sender, RoutedEventArgs e)
        {
            Execute_N.IsEnabled = false;
        }

    }
}
