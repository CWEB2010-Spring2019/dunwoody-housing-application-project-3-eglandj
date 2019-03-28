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
        string[] information = File.ReadAllLines(@"..\..\Student_Data.csv");
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
        public void populateRooms()
        {
            var RoomQuery =
                from info in information
                let element = info.Split(',')
                select element[5];

            List<string> roomNumber = RoomQuery.ToList();

            RoomNumber.IsEnabled = true;
            RoomNumber.Items.Clear();
            for (int i = 0; i < 10; i++)
            {
                int room = Convert.ToInt32(FloorNumber.SelectedValue + i.ToString("D2"));
                RoomNumber.Items.Add(room);
            }
            foreach (string info in RoomQuery)
            {
                RoomNumber.Items.Remove(Convert.ToInt32(info));
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
            string fileName = @"..\..\Student_Data.csv";
            int count = 0;
            var countQuery =
                from info in information
                let elements = info.Split(',')
                select elements[0];
            foreach (var info in countQuery)
            {
                count++;
            }

            try
            {
                if (StudentType.SelectedValue.ToString() == "Athlete")
                {
                    Athlete studentAthlete = new Athlete((count + 1).ToString("D4"), FirstName.Text, LastName.Text, StudentType.SelectedValue.ToString(),
                        Convert.ToInt32(FloorNumber.SelectedValue), Convert.ToInt32(RoomNumber.SelectedValue));
                    string athlete = Environment.NewLine;
                    athlete += studentAthlete.ID_Number + "," + studentAthlete.firstName + "," + studentAthlete.lastName + "," + studentAthlete.studentType + "," +
                          studentAthlete.floorNumber + "," + studentAthlete.roomNumber + "," + studentAthlete.rentFee;
                    File.AppendAllText(fileName, athlete);
                    MessageBox.Show("Athlete Resident Created");
                }
                else if (StudentType.SelectedValue.ToString() == "Scholarship")
                {
                    Scholarship studentScholar = new Scholarship((count + 1).ToString("D4"), FirstName.Text, LastName.Text, StudentType.SelectedValue.ToString(),
                        Convert.ToInt32(FloorNumber.SelectedValue), Convert.ToInt32(RoomNumber.SelectedValue));
                    string scholarship = Environment.NewLine;
                    scholarship += studentScholar.ID_Number + "," + studentScholar.firstName + "," + studentScholar.lastName + "," + studentScholar.studentType + "," +
                          studentScholar.floorNumber + "," + studentScholar.roomNumber + "," + studentScholar.rentFee;
                    File.AppendAllText(fileName, scholarship);
                    MessageBox.Show("Scholarship Resident Created");
                }
                else if (StudentType.SelectedValue.ToString() == "Worker")
                {
                    if(Convert.ToDouble(MonthlyHours.Text) > 160 || Convert.ToDouble(MonthlyHours.Text) < 1)
                    {
                        MessageBox.Show("Hours are unrealistic");
                        throw new Exception();
                    }
                    else
                    {
                        Worker studentWorker = new Worker((count + 1).ToString("D4"), FirstName.Text, LastName.Text, StudentType.SelectedValue.ToString(),
                        Convert.ToInt32(FloorNumber.SelectedValue), Convert.ToInt32(RoomNumber.SelectedValue), Convert.ToDouble(MonthlyHours.Text));
                        string worker = Environment.NewLine;
                        worker += studentWorker.ID_Number + "," + studentWorker.firstName + "," + studentWorker.lastName + "," + studentWorker.studentType + "," +
                              studentWorker.floorNumber + "," + studentWorker.roomNumber + "," + studentWorker.rentFee;
                        File.AppendAllText(fileName, worker);
                        MessageBox.Show("Worker Resident Created");
                    }
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
