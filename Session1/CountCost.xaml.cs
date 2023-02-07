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
    /// Логика взаимодействия для CountCost.xaml
    /// </summary>
    public partial class CountCost : Window
    {
        public CountCost()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private async void Count_Click(object sender, RoutedEventArgs e)
        {
            Deals deal = db.Deals.Find(Data.Id);
            supplies sup = db.supplies.Find(deal.SupplyId);
            string type = db.RealEstateObjects.Find(sup.RealEstateId).ObjectType;
            double dealShare = (double)db.Realtor.Find(sup.AgentId).DealShare;
            double price = sup.Price;
            double result;
            if (combo.Text.Length == 0) MessageBox.Show("Выберите, для кого нужно произвести расчёт");
            else if (combo.Text == "Клиент-продавец")
            {
                if (type == "Квартира") result = 36000 + price * 0.01;
                else if (type == "Дом") result = 30000 + price * 0.01;
                else result = 30000 + price * 0.02;
                MessageBox.Show($"Стоимость услуг для клиента-продавца: {result}");
            }
            else if (combo.Text == "Клиент-покупатель") 
            {
                result = price * 0.03;
                MessageBox.Show($"Стоимость услуг для клиента-покупателя: {result}");
            }
            else if (combo.Text == "Риэлтор клиента-продавца") 
            {
                if (type == "Квартира") result = 36000 + price * 0.01;
                else if (type == "Дом") result = 30000 + price * 0.01;
                else result = 30000 + price * 0.02;
                if (dealShare != 0) result *= dealShare / 100;
                else result *= 0.45;
                MessageBox.Show($"Размер отчислений риэлтору клиента-продавца: {result}");
            }
            else if (combo.Text == "Риэлтор клиента-покупателя") 
            {
                result = price * 0.03;
                if (dealShare != 0) result *= dealShare / 100;
                else result *= 0.45;
                MessageBox.Show($"Стоимость услуг для клиента-покупателя: {result}");
            }
            else if (combo.Text == "Размер отчислений компании") 
            {
                if (type == "Квартира") result = 36000 + price * 0.01;
                else if (type == "Дом") result = 30000 + price * 0.01;
                else result = 30000 + price * 0.02;
                result += price * 0.03;
                if (dealShare != 0) result *= 1 - dealShare / 100;
                else result *= 0.55;
                MessageBox.Show($"Размер отчислений компании: {result}");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
