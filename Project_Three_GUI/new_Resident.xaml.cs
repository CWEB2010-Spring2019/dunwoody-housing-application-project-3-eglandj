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
        List<Student> information = File.ReadAllLines(@"..\..\Student_Data.csv")//Reading all lines from the csv file
                                       .Skip(1)//Skips the first line in the csv file
                                       .Select(students => new Student(students))//Creating new objects for the read data
                                       .ToList();//Putting the objects into a list
        public new_Resident()
        {
            InitializeComponent();
            populateStudentType();
            CreateButton.Visibility = Visibility.Hidden;
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
        public void populateRooms(List<Student> information)
        {
            RoomNumber.IsEnabled = true;
            RoomNumber.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                int room = Convert.ToInt32(FloorNumber.SelectedValue + i.ToString("D2"));
                RoomNumber.Items.Add(room);
                foreach (Student info in information)
                {
                    RoomNumber.Items.Remove(info.roomNumber);
                }
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
            populateRooms(information);
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
            string fileName = @"..\..\Student_Data.csv";
            int count = 0;
            foreach (Student info in information)
            {
                count++;
            }
            try
            {
                if (StudentType.SelectedValue.ToString() == "Athlete")
                {
                    string athlete = Environment.NewLine;
                    athlete += (count + 1).ToString("D4") + "," + FirstName.Text + "," + LastName.Text + "," + StudentType.SelectedValue.ToString() + "," +
                        FloorNumber.SelectedValue + "," + RoomNumber.SelectedValue + "," + 1200;
                    File.AppendAllText(fileName, athlete);
                    MessageBox.Show("Athlete Resident Created");
                }
                else if (StudentType.SelectedValue.ToString() == "Scholarship")
                {

                    string scholarship = Environment.NewLine;
                    scholarship += (count + 1).ToString("D4") + "," + FirstName.Text + "," + LastName.Text + "," + StudentType.SelectedValue.ToString() + "," +
                        FloorNumber.SelectedValue + "," + RoomNumber.SelectedValue + "," + 100;
                    File.AppendAllText(fileName, scholarship);
                    MessageBox.Show("Scholarship Resident Created");
                }
                else if (StudentType.SelectedValue.ToString() == "Worker")
                {
                    //$1245 a month minus half of their monthly student worker pay(which is calculated 
                    //    by taking the monthly hours worked * base hourly rate). The base hourly rate for a student worker is $14.00

                    double fee = 1245 - (0.5 * (Convert.ToDouble(MonthlyHours.Text) * 14.00));
                    string scholarship = Environment.NewLine;
                    scholarship += (count + 1).ToString("D4") + "," + FirstName.Text + "," + LastName.Text + "," + StudentType.SelectedValue.ToString() + "," +
                        FloorNumber.SelectedValue + "," + RoomNumber.SelectedValue + "," + fee;
                    File.AppendAllText(fileName, scholarship);
                    MessageBox.Show("Worker Resident Created");
                }
                FirstName.Text = null;
                LastName.Text = null;
                StudentType.SelectedValue = null;
                Selection selectionPage = new Selection();
                this.NavigationService.Navigate(selectionPage);
            }
            catch
            {
                MessageBox.Show("Please fill in the data correctly");
            }
           
        }

    }
}
