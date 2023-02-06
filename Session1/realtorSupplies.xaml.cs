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
    /// Логика взаимодействия для realtorSupplies.xaml
    /// </summary>
    public partial class realtorSupplies : Window
    {
        public realtorSupplies()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var agentDemands = from p in db.supplies
                                where p.AgentId == Data.Id
                                select new
                                {
                                    p.ClientId,
                                    p.RealEstateId,
                                    p.Price
                                };
            Supplies.ItemsSource = agentDemands.ToList();
        }
    }
}
