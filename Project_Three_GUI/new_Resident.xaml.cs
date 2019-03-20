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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Three_GUI
{
    /// <summary>
    /// Interaction logic for new_Resident.xaml
    /// </summary>
    public partial class new_Resident : Page
    {
        public new_Resident()
        {
            InitializeComponent();
            populateStudentType();
            MonthlyHours.Visibility = Visibility.Hidden;
            MonthlyHoursLabel.Visibility = Visibility.Hidden;
            FloorNumber.IsEnabled = false;
            RoomNumber.IsEnabled = false;
        }
        public void populateStudentType()
        {
            StudentType.Items.Add("Athlete");
            StudentType.Items.Add("Scholarship");
            StudentType.Items.Add("Worker");
        }
        public void populateFloors()
        {
            FloorNumber.Items.Clear();
            FloorNumber.IsEnabled = true;
            if (StudentType.SelectedValue.ToString() == "Athlete")
            {
                FloorNumber.Items.Add("7");
                FloorNumber.Items.Add("8");
            }
            else if (StudentType.SelectedValue.ToString() == "Scholarship")
            {
                FloorNumber.Items.Add("4");
                FloorNumber.Items.Add("5");
                FloorNumber.Items.Add("6");
            }
            else if (StudentType.SelectedValue.ToString() == "Worker")
            {
                FloorNumber.Items.Add("1");
                FloorNumber.Items.Add("2");
                FloorNumber.Items.Add("3");
            }
        }
        public void populateRooms()
        {
            RoomNumber.Items.Clear();
            RoomNumber.IsEnabled = true;
            for (int i = 0; i < 10; i++)
            {
                RoomNumber.Items.Add(FloorNumber.SelectedValue + "0" + i.ToString());
            }
            
        }

        private void StudentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateFloors();
        }

        private void FloorNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateRooms();
        }

        private void RoomNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
