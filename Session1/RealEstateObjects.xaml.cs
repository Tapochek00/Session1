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
    /// Логика взаимодействия для RealEstateObjects.xaml
    /// </summary>
    public partial class RealEstateObjects : Window
    {
        public RealEstateObjects()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db.RealEstateObjects.Load();
            objects.ItemsSource = db.RealEstateObjects.Local.ToBindingList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddObject win = new AddObject();
            win.ShowDialog();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            int indexRow = objects.SelectedIndex;
            if (indexRow != -1)
            {
                RealEstateObjects row = (RealEstateObjects)objects.Items[indexRow];
                Data.Id = row.Id;
                EditObject edit = new EditObject();
                edit.ShowDialog();
                objects.Items.Refresh();
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
                    RealEstateObjects row = (RealEstateObjects)objects.SelectedItems[0];
                    db.RealEstateObjects.Remove(row);
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
