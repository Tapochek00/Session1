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
    /// Логика взаимодействия для SuppliesMain.xaml
    /// </summary>
    public partial class SuppliesMain : Window
    {
        public SuppliesMain()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.supplies.Load();
            Supplies.ItemsSource = db.supplies.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddSupply win = new AddSupply();
            win.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = Supplies.SelectedIndex;
            if (indexRow != -1)
            {
                supplies row = (supplies)Supplies.Items[indexRow];
                Data.Id = row.Id;
                EditSupply edit = new EditSupply();
                edit.ShowDialog();
                Supplies.Items.Refresh();
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
                    supplies row = (supplies)Supplies.SelectedItems[0];
                    db.supplies.Remove(row);
                    db.SaveChanges();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Выберите запись");
                }
            }
        }
    }
}
