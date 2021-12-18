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

namespace EasySave_GRP4.View
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class ProgressBar : Window
    {
        public ProgressBar()
        {
            InitializeComponent();
            Thread Recup_Etat = new Thread(Suivit_Loaded);
            Recup_Etat.Start();
        }
        private void Suivit_Loaded()
        {
            while (true)
            {
                //
                Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Send, new Action(delegate ()
                {
                    Affi_Data.ItemsSource = View_Factory.CPT.Afficher_Data();


                }));
                Thread.Sleep(800);
            }
        }
        private void Play_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.CET.Play_Travail();
            MessageBox.Show("Play my dude");
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.CET.Pause_Travail();
            MessageBox.Show("Pause my dude");
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            View_Factory.CET.Stop_Travail();
            MessageBox.Show("Hbess hnaya khir");
        }

        private void Aff_Data_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //Affi_Data.ItemsSource = View_Factory.CPT.Afficher_Data();
        }

        private void Affi_Data_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex() + 1).ToString();
        }
    }
}
