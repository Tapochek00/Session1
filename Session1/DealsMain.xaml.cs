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
    /// Логика взаимодействия для DealsMain.xaml
    /// </summary>
    public partial class DealsMain : Window
    {
        public DealsMain()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Deals.Load();
            DealsTable.ItemsSource = db.Deals.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDeal win = new AddDeal();
            win.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DealsTable.SelectedIndex;
            if (indexRow != -1)
            {
                Deals row = (Deals)DealsTable.Items[indexRow];
                Data.Id = row.Id;
                EditDeal edit = new EditDeal();
                edit.Owner = this;
                edit.ShowDialog();
                DealsTable.Items.Refresh();
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
                    Deals row = (Deals)DealsTable.SelectedItems[0];
                    db.Deals.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }

        private void Cost_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = DealsTable.SelectedIndex;
            if (indexRow != -1)
            {
                Deals row = (Deals)DealsTable.Items[indexRow];
                Data.Id = row.Id;
                CountCost win = new CountCost();
                win.ShowDialog();
            }
        }
    }
}
