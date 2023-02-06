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
    /// Логика взаимодействия для AddSupply.xaml
    /// </summary>
    public partial class AddSupply : Window
    {
        public AddSupply()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboItem;

            foreach (var item in db.Client)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = item.Id.ToString() + " " + item.LastName
                    + " " + item.FirstName + " " + item.Patronymic;
                Client.Items.Add(comboItem);
            }

            foreach (var item in db.Realtor)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = item.Id.ToString() + " " + item.LastName
                    + " " + item.FirstName + " " + item.Patronymic;
                Agent.Items.Add(comboItem);
            }

            foreach (var item in db.RealEstateObjects)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = item.Id.ToString();
                RealEstateId.Items.Add(comboItem);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                supplies sup = new supplies();
                bool isInt = int.TryParse(Price.Text, out int price);

                StringBuilder errors = new StringBuilder();
                if (Client.Text.Length == 0)
                    errors.AppendLine("Выберите клиента");
                if (Agent.Text.Length == 0)
                    errors.AppendLine("Выберите риэлтора");
                if (RealEstateId.Text.Length == 0) errors.AppendLine("Выберите объект недвижимости");
                if (Price.Text.Length == 0) errors.AppendLine("Введите цену");
                if (!isInt) errors.AppendLine("Введите правильную цену");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                string[] findClient = Client.Text.Split(' ');

                string[] findAgent = Agent.Text.Split(' ');

                sup.ClientId = int.Parse(findClient[0]);
                sup.AgentId = int.Parse(findAgent[0]);
                sup.RealEstateId = int.Parse(RealEstateId.Text);
                sup.Price = price;

                db.supplies.Add(sup);
                db.SaveChanges();
                Close();
            }
            catch { }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
