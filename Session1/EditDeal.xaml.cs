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
    /// Логика взаимодействия для EditDeal.xaml
    /// </summary>
    public partial class EditDeal : Window
    {
        public EditDeal()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboItem;
            Deals deal = db.Deals.Find(Data.Id);

            foreach (var item in db.Demands)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = item.id.ToString();
                if (item.id == deal.DemandId) comboItem.IsSelected = true;
                demandCombo.Items.Add(comboItem);
            }

            foreach (var item in db.supplies)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = item.Id.ToString();
                if (item.Id == deal.SupplyId) comboItem.IsSelected = true;
                supplyCombo.Items.Add(comboItem);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Deals deal = db.Deals.Find(Data.Id);

            StringBuilder errors = new StringBuilder();
            if (demandCombo.Text.Length == 0)
                errors.AppendLine("Выберите потребность");
            if (supplyCombo.Text.Length == 0)
                errors.AppendLine("Выберите сделку");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            int demandId = int.Parse(demandCombo.Text);
            int supplyId = int.Parse(supplyCombo.Text);

            var findDemands = from p in db.Deals
                              where p.DemandId == demandId
                              && p.DemandId != deal.DemandId
                              select p;
            var findSupplies = from p in db.Deals
                               where p.SupplyId == supplyId
                               && p.SupplyId != deal.SupplyId
                               select p;

            if (!findSupplies.Any() && !findDemands.Any())
            {
                deal.DemandId = demandId;
                deal.SupplyId = supplyId;
                db.SaveChanges();
                Close();
            }
            else if (findDemands.Any())
                MessageBox.Show("Потребность уже участвует в другой сделке");
            else MessageBox.Show("Предложение уже участвует в другой сделке");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
