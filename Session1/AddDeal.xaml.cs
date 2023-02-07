using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
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
    /// Логика взаимодействия для AddDeal.xaml
    /// </summary>
    public partial class AddDeal : Window
    {
        public AddDeal()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBoxItem comboItem;

            foreach (var item in db.Demands)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = item.id.ToString();
                demandCombo.Items.Add(comboItem);
            }

            foreach (var item in db.supplies)
            {
                comboItem = new ComboBoxItem();
                comboItem.Content = item.Id.ToString();
                supplyCombo.Items.Add(comboItem);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Deals deal = new Deals();

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

            deal.DemandId = int.Parse(demandCombo.Text);
            deal.SupplyId = int.Parse(supplyCombo.Text);

            var findDemands = from p in db.Deals
                                where p.DemandId == deal.DemandId
                                select p;
            var findSupplies = from p in db.Deals
                                 where p.SupplyId == deal.SupplyId
                                 select p;

            if (!findSupplies.Any() && !findDemands.Any())
            {
                db.Deals.Add(deal);
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
