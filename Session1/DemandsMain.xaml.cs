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
    /// Логика взаимодействия для DemandsMain.xaml
    /// </summary>
    public partial class DemandsMain : Window
    {
        public DemandsMain()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.Demands.Load();
            demands.ItemsSource = db.Demands.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddDemand win = new AddDemand();
            win.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = demands.SelectedIndex;
            if (indexRow != -1)
            {
                Demands row = (Demands)demands.Items[indexRow];
                Data.Id = row.id;
                EditDemand edit = new EditDemand();
                edit.ShowDialog();
                demands.Items.Refresh();
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
                    Demands row = (Demands)demands.SelectedItems[0];
                    var findInDeals = from p in db.Deals
                                      where p.DemandId == row.id
                                      select p;
                    if (!findInDeals.Any())
                    {
                        db.Demands.Remove(row);
                        db.SaveChanges();
                    }
                    else MessageBox.Show("Предложение связано со сделкой");
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
    }
}
