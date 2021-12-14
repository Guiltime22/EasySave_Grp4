using System;
using System.Collections.Generic;
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

namespace EasySave_GRP4.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
