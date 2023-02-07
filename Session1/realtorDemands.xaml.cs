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
    /// Логика взаимодействия для realtorDemands.xaml
    /// </summary>
    public partial class realtorDemands : Window
    {
        public realtorDemands()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var agentDemands = from p in db.Demands
                               where p.AgentId == Data.Id
                               select new
                               {
                                    p.id,
                                    p.ClientId,
                                    p.ObjectType,
                                    p.Address_City,
                                    p.Address_Street,
                                    p.Address_House,
                                    p.Address_Number,
                                    p.MinPrice,
                                    p.MaxPrice,
                                    p.MinArea,
                                    p.MaxArea,
                                    p.MinRooms,
                                    p.MaxRooms,
                                    p.MinFloor,
                                    p.MaxFloor
                                };
            demands.ItemsSource = agentDemands.ToList();
        }
    }
}
