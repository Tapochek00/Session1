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
    /// Логика взаимодействия для clientDemands.xaml
    /// </summary>
    public partial class clientDemands : Window
    {
        public clientDemands()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var clientDemands = from p in db.Demands
                                where p.ClientId == Data.Id
                                select new
                                {
                                    p.id,
                                    p.AgentId,
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
                                    p.MaxFloor,
                                    p.MinTotalFloors,
                                    p.MaxTotalFloors
                                };
            demands.ItemsSource = clientDemands.ToList();
        }
    }
}
