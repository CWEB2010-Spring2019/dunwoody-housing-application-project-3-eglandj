using System;
using System.Collections.Generic;
using System.IO;
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
using Newtonsoft.Json;


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
            CreateButton.Visibility = Visibility.Hidden;
            MonthlyHours.Visibility = Visibility.Hidden;
            MonthlyHoursLabel.Visibility = Visibility.Hidden;
            FloorNumber.IsEnabled = false;
            RoomNumber.IsEnabled = false;
            Student[,] studentInfo = JsonConvert.DeserializeObject<Student[,]>(File.ReadAllText(@"..\..\Student_Data.JSON"));
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
                FloorNumber.Items.Add("4");
                FloorNumber.Items.Add("5");
                FloorNumber.Items.Add("6");
            }
            else if (StudentType.SelectedValue.ToString() == "Scholarship")
            {
                
                FloorNumber.Items.Add("7");
                FloorNumber.Items.Add("8");
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
                RoomNumber.Items.Add(FloorNumber.SelectedValue + i.ToString("D2"));
            }
        }

        private void StudentType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CreateButton.Visibility = Visibility.Hidden;
            populateFloors();
            if (StudentType.SelectedValue.ToString() == "Worker")
            {
                MonthlyHours.Visibility = Visibility.Visible;
                MonthlyHoursLabel.Visibility = Visibility.Visible;
            }
            else
            {
                MonthlyHours.Visibility = Visibility.Hidden;
                MonthlyHoursLabel.Visibility = Visibility.Hidden;
            }
        }

        private void FloorNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            populateRooms();
        }

        private void RoomNumber_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StudentType.SelectedValue.ToString() != "Worker")
            {
                if (FirstName.Text != null && LastName.Text != null && StudentType.SelectedValue != null && FloorNumber.SelectedValue != null && RoomNumber.SelectedValue != null)
                {
                    CreateButton.Visibility = Visibility.Visible;
                }
            }
        }

        private void MonthlyHours_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (FirstName.Text != null && LastName.Text != null && StudentType.SelectedValue != null && FloorNumber.SelectedValue != null && RoomNumber.SelectedValue != null && MonthlyHours.SelectedText != null)
            {
                CreateButton.Visibility = Visibility.Visible;
            }
            else
            {
                CreateButton.Visibility = Visibility.Hidden;
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StudentType.SelectedValue.ToString() == "Athlete")
                {
                    Athlete athlete = new Athlete(1, FirstName.Text, LastName.Text, Convert.ToInt32(FloorNumber.SelectedValue.ToString()), Convert.ToInt32(RoomNumber.SelectedValue.ToString()));
                    string json = JsonConvert.SerializeObject(athlete);
                }
                else if (StudentType.SelectedValue.ToString() == "Scholarship")
                {
                    Scholarship scholarship = new Scholarship(FirstName.Text, LastName.Text, Convert.ToInt32(FloorNumber.SelectedValue.ToString()), Convert.ToInt32(RoomNumber.SelectedValue.ToString()));
                }
                else if (StudentType.SelectedValue.ToString() == "Worker")
                {
                    Worker worker = new Worker(FirstName.Text, LastName.Text, Convert.ToInt32(FloorNumber.SelectedValue.ToString()), Convert.ToInt32(RoomNumber.SelectedValue.ToString()), Convert.ToDouble(MonthlyHours.Text));
                }
            }
            catch
            {
                MessageBox.Show("Please fill in the data correctly");
            }
           
        }

    }
}
