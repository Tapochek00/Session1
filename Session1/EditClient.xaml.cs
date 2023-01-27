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
    /// Логика взаимодействия для EditClient.xaml
    /// </summary>
    public partial class EditClient : Window
    {
        public EditClient()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Phone.Text.Length == 0 && Email.Text.Length == 0)
                {
                    MessageBox.Show("Введите номер телефона и/или email");
                    return;
                }

                Client client = db.Client.Find(Data.Id);
                if (LastName.Text.Length != 0) client.LastName = LastName.Text;
                if (FirstName.Text.Length != 0) client.FirstName = FirstName.Text;
                if (Patronymic.Text.Length != 0) client.Patronymic = Patronymic.Text;
                if (Phone.Text.Length != 0) client.Phone = Phone.Text;
                if (Email.Text.Length != 0) client.email = Email.Text;
                
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
            Client client = db.Client.Find(Data.Id);

            LastName.Text = client.LastName;
            FirstName.Text = client.FirstName;
            Patronymic.Text = client.Patronymic;
            Phone.Text = client.Phone;
            Email.Text = client.email;
        }
    }
}
