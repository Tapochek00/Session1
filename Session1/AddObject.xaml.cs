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
    /// Логика взаимодействия для AddObject.xaml
    /// </summary>
    public partial class AddObject : Window
    {
        public AddObject()
        {
            InitializeComponent();
        }

        Context db = Context.GetContext();
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ObjectType.Text == null)
                {
                    MessageBox.Show("Выберите тип объекта недвижимости");
                    return;
                }
                RealEstateObjects obj = new RealEstateObjects();
                if (City.Text.Length != 0) obj.Address_City = City.Text;
                if (Street.Text.Length != 0) obj.Address_Street = Street.Text;
                if (House.Text.Length != 0) obj.Address_House = House.Text;
                if (Number.Text.Length != 0) obj.Address_Number = Number.Text;
                if (Coordinate_latitude.Text.Length != 0)
                    obj.Coordinate_latitude = double.Parse(Coordinate_latitude.Text);
                if (Coordinate_longitude.Text.Length != 0)
                    obj.Coordinate_longitude = double.Parse(Coordinate_longitude.Text);
                if (TotalArea.Text.Length != 0)
                    obj.TotalArea = double.Parse(TotalArea.Text);
                if (Rooms.Text.Length != 0) obj.Rooms = int.Parse(Rooms.Text);
                if (Floor.Text.Length != 0) obj.Floor = int.Parse(Floor.Text);
                if (TotalFloors.Text.Length != 0)
                    obj.TotalFloors = int.Parse(TotalFloors.Text);
                if (ObjectType.Text.Length != 0) obj.ObjectType = ObjectType.Text;

                db.RealEstateObjects.Add(obj);
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
    }
}
