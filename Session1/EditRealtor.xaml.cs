using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
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
    /// Логика взаимодействия для EditRealtor.xaml
    /// </summary>
    public partial class EditRealtor : Window
    {
        public EditRealtor()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StringBuilder errors = new StringBuilder();
                if (LastName.Text.Length == 0)
                    errors.AppendLine("Введите фамилию");
                if (FirstName.Text.Length == 0)
                    errors.AppendLine("Введите имя");
                if (Patronymic.Text.Length == 0)
                    errors.AppendLine("Введите отчество");
                if (double.TryParse(DealShare.Text, out double dealShare))
                    errors.AppendLine("Доля от комиссии может состоять только из чисел");
                if (dealShare < 0 || dealShare > 100)
                    errors.AppendLine("Доля от комиссии должна быть" +
                        " не меньше 0 и не больше 100");

                if (errors.Length > 0)
                {
                    MessageBox.Show(errors.ToString());
                    return;
                }

                Realtor realtor = db.Realtor.Find(Data.Id);
                realtor.LastName = LastName.Text;
                realtor.FirstName = FirstName.Text;
                realtor.Patronymic = Patronymic.Text;
                if (DealShare.Text.Length != 0) realtor.DealShare = dealShare;

                db.SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Realtor realtor = db.Realtor.Find(Data.Id);

            LastName.Text = realtor.LastName;
            FirstName.Text = realtor.FirstName;
            Patronymic.Text = realtor.Patronymic;
            DealShare.Text = realtor.DealShare.ToString();
        }
    }
}
