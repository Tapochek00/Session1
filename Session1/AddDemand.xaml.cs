using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для AddDemand.xaml
    /// </summary>
    public partial class AddDemand : Window
    {
        public AddDemand()
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
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Demands dem = new Demands();

                StringBuilder errors = new StringBuilder();
                if (Client.Text.Length == 0)
                    errors.AppendLine("Выберите клиента");
                if (Agent.Text.Length == 0)
                    errors.AppendLine("Выберите риэлтора");
                if (ObjectType.Text.Length == 0) errors.AppendLine("Выберите объект недвижимости");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                string[] findClient = Client.Text.Split(' ');

                string[] findAgent = Agent.Text.Split(' ');

                dem.ClientId = int.Parse(findClient[0]);
                dem.AgentId = int.Parse(findAgent[0]);
                dem.ObjectType = ObjectType.Text;
                if (City.Text.Length != 0) dem.Address_City = City.Text;
                if (Street.Text.Length != 0) dem.Address_Street = Street.Text;
                if (House.Text.Length != 0) dem.Address_House = House.Text;
                if (Number.Text.Length != 0) dem.Address_Number = Number.Text;
                if (MinPrice.Text.Length != 0) dem.MinPrice = int.Parse(MinPrice.Text);
                if (MaxPrice.Text.Length != 0) dem.MaxPrice = int.Parse(MaxPrice.Text);
                if (MinArea.Text.Length != 0) dem.MinArea = int.Parse(MinArea.Text);
                if (MaxArea.Text.Length != 0) dem.MaxArea = int.Parse(MaxArea.Text);
                if (MinRooms.Text.Length != 0) dem.MinRooms = int.Parse(MinRooms.Text);
                if (MaxRooms.Text.Length != 0) dem.MaxRooms = int.Parse(MaxRooms.Text);
                if (MinFloor.Text.Length != 0) dem.MinFloor = int.Parse(MinFloor.Text);
                if (MinFloor.Text.Length != 0) dem.MaxFloor = int.Parse(MaxFloor.Text);

                db.Demands.Add(dem);
                db.SaveChanges();
                Close();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
