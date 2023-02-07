using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Session1
{
    /// <summary>
    /// Логика взаимодействия для ClientMain.xaml
    /// </summary>
    public partial class ClientMain : Window
    {
        public ClientMain()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Client.Load();
            clientTable.ItemsSource = db.Client.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClient win = new AddClient();
            win.Owner = this;
            win.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = clientTable.SelectedIndex;
            if (indexRow != -1)
            {
                Client row = (Client)clientTable.Items[indexRow];
                Data.Id = row.Id;
                EditClient edit = new EditClient();
                edit.Owner = this;
                edit.ShowDialog();
                clientTable.Items.Refresh();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result;
            result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    Client row = (Client)clientTable.SelectedItems[0];
                    var findInSupplies = from p in db.supplies
                                         where p.ClientId == row.Id
                                         select p;
                    var findInDemands = from p in db.Demands
                                         where p.ClientId == row.Id
                                         select p;
                    if (!findInSupplies.Any())
                    {
                        db.Client.Remove(row);
                        db.SaveChanges();
                    }
                    else if (findInDemands.Any()) MessageBox.Show("Клиент связан с потребностью");
                    else MessageBox.Show("Клиент связан с предложением");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void clientDemands_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = clientTable.SelectedIndex;
            if (indexRow != -1)
            {
                Client row = (Client)clientTable.Items[indexRow];
                Data.Id = row.Id;
                clientDemands win = new clientDemands();
                win.ShowDialog();
            }
        }

        private void clientSupplies_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = clientTable.SelectedIndex;
            if (indexRow != -1)
            {
                Client row = (Client)clientTable.Items[indexRow];
                Data.Id = row.Id;
                clientSupplies win = new clientSupplies();
                win.ShowDialog();
            }
        }
    }
}
