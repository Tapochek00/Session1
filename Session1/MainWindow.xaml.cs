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

namespace Session1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientMain win = new ClientMain();
            win.ShowDialog();
        }

        private void btnRealtor_Click(object sender, RoutedEventArgs e)
        {
            RealtorMain win = new RealtorMain();
            win.ShowDialog();
        }

        private void RealEstateObjects_Click(object sender, RoutedEventArgs e)
        {
            RealEstateObjectsMain win = new RealEstateObjectsMain();
            win.ShowDialog();
        }

        private void Supplies_Click(object sender, RoutedEventArgs e)
        {
            SuppliesMain win = new SuppliesMain();
            win.ShowDialog();
        }

        private void Demands_Click(object sender, RoutedEventArgs e)
        {
            DemandsMain win = new DemandsMain();
            win.ShowDialog();
        }
    }
}
