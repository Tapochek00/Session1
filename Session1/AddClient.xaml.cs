using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Phone.Text.Length == 0 && Email.Text.Length == 0)
                {
                    MessageBox.Show("Введите номер телефона и/или email");
                    return;
                }
                Client client = new Client();
                if (LastName.Text.Length != 0) client.LastName = LastName.Text;
                if (FirstName.Text.Length != 0) client.FirstName = FirstName.Text;
                if (Patronymic.Text.Length != 0) client.Patronymic = Patronymic.Text;
                if (Phone.Text.Length != 0) client.Phone = Phone.Text;
                if (Email.Text.Length != 0) client.email = Email.Text;

                client.Id = db.Client.ToList().Last().Id + 1;

                db.Client.Add(client);
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
