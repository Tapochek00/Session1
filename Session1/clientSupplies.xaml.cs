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
using System.Windows.Shapes;

namespace Session1
{
    /// <summary>
    /// Логика взаимодействия для clientSupplies.xaml
    /// </summary>
    public partial class clientSupplies : Window
    {
        public clientSupplies()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var clientDemands = from p in db.supplies
                                where p.ClientId == Data.Id
                                select new
                                {
                                    p.Id,
                                    p.AgentId,
                                    p.RealEstateId,
                                    p.Price
                                };
            Supplies.ItemsSource = clientDemands.ToList();
        }
    }
}
