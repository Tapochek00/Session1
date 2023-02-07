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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Session1
{
    /// <summary>
    /// Логика взаимодействия для RealtorMain.xaml
    /// </summary>
    public partial class RealtorMain : Window
    {
        public RealtorMain()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Realtor.Load();
            realtorTable.ItemsSource = db.Realtor.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddRealtor win = new AddRealtor();
            win.Owner = this;
            win.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = realtorTable.SelectedIndex;
            if (indexRow != -1)
            {
                Realtor row = (Realtor)realtorTable.Items[indexRow];
                Data.Id = row.Id;
                EditRealtor edit = new EditRealtor();
                edit.Owner = this;
                edit.ShowDialog();
                realtorTable.Items.Refresh();
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
                    Realtor row = (Realtor)realtorTable.SelectedItems[0];
                    var findInSupplies = from p in db.supplies
                                         where p.AgentId == row.Id
                                         select p;
                    var findInDemands = from p in db.Demands
                                         where p.AgentId == row.Id
                                         select p;
                    if (!findInSupplies.Any() && !findInDemands.Any())
                    {
                        db.Realtor.Remove(row);
                        db.SaveChanges();
                    }
                    else if (findInDemands.Any()) MessageBox.Show("Риэлтор связан с потребностью");
                    else MessageBox.Show("Риэлтор связан с предложением");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void agentDemands_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = realtorTable.SelectedIndex;
            if (indexRow != -1)
            {
                Realtor row = (Realtor)realtorTable.Items[indexRow];
                Data.Id = row.Id;
                realtorDemands win = new realtorDemands();
                win.ShowDialog();
            }
        }

        private void agentSupplies_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = realtorTable.SelectedIndex;
            if (indexRow != -1)
            {
                Realtor row = (Realtor)realtorTable.Items[indexRow];
                Data.Id = row.Id;
                realtorSupplies win = new realtorSupplies();
                win.ShowDialog();
            }
        }
    }
}
