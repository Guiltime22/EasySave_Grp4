﻿using System;
using System.Collections.Generic;
using System.Data;
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
                MessageBox.Show("Le répertoire source précisé est vide");
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
                MessageBox.Show("Le répertoire Destination précisé est vide");
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
            Thread Aff = new Thread(Aff_Loaded);
            Aff.Start();
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
                MessageBox.Show("Veuillez remplir tout les champs");
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
                MessageBox.Show("Veuillez remplir tout les champs");
            }
        }
    }
}
