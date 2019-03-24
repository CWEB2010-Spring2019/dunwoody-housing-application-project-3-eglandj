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

namespace Project_Three_GUI
{
    /// <summary>
    /// Interaction logic for ResidentSearch.xaml
    /// </summary>
    public partial class ResidentSearch : Page
    {
        List<Student> information = File.ReadAllLines(@"..\..\Student_Data.csv")//Reading all lines from the csv file
                                       .Skip(1)//Skips the first line in the csv file
                                       .Select(students => new Student(students))//Creating new objects for the read data
                                       .ToList();//Putting the objects into a list
        public ResidentSearch()
        {
            InitializeComponent();
            numberOfStudents(information);
            generate_columns(information);
        }
        private void numberOfStudents(List<Student> information)
        {
            var athlete =
                from info in information
                where info.studentType == "Athlete"
                select info;
            var scholarship =
                from info in information
                where info.studentType == "Scholarship"
                select info;
            var worker =
                from info in information
                where info.studentType == "Worker"
                select info;

            AthleteStudents.Content = "Number of Athlete Students: " + athlete.Count();
            ScholarStudents.Content = "Number of Scholar Students: " + scholarship.Count();
            WorkerStudents.Content = "Number of Worker Students: " + worker.Count();
            floorRangeA.Content = "Number of Students on floors (1-3): " + worker.Count();
            floorRangeB.Content = "Number of Students on floors (4-6): " + athlete.Count();
            floorRangeC.Content = "Number of Students on floors (7-8): " + scholarship.Count();
        }
        private void generate_columns(List<Student> information)
        {
            DataGridTextColumn c1 = new DataGridTextColumn();
            c1.Header = "ID Number";
            c1.Binding = new Binding("ID_Number");
            c1.Width = 70;
            dataGrid1.Columns.Add(c1);
            DataGridTextColumn c2 = new DataGridTextColumn();
            c2.Header = "First Name";
            c2.Width = 70;
            c2.Binding = new Binding("firstName");
            dataGrid1.Columns.Add(c2);
            DataGridTextColumn c3 = new DataGridTextColumn();
            c3.Header = "Last Name";
            c3.Width = 70;
            c3.Binding = new Binding("lastName");
            dataGrid1.Columns.Add(c3);
            DataGridTextColumn c4 = new DataGridTextColumn();
            c4.Header = "Student Type";
            c4.Width = 90;
            c4.Binding = new Binding("studentType");
            dataGrid1.Columns.Add(c4);
            DataGridTextColumn c5 = new DataGridTextColumn();
            c5.Header = "Floor Number";
            c5.Width = 90;
            c5.Binding = new Binding("floorNumber");
            dataGrid1.Columns.Add(c5);
            DataGridTextColumn c6 = new DataGridTextColumn();
            c6.Header = "Room Number";
            c6.Width = 90;
            c6.Binding = new Binding("roomNumber");
            dataGrid1.Columns.Add(c6);
            DataGridTextColumn c7 = new DataGridTextColumn();
            c7.Header = "Rent Fee";
            c7.Width = 80;
            c7.Binding = new Binding("rentFee");
            dataGrid1.Columns.Add(c7);
            //ID Number,First Name,Last Name,Student Type,Floor Number,Room Number,Rent Fee
            foreach(Student info in information)
            {
                dataGrid1.Items.Add(new Student() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.Items.Clear();
            List<Student> updatedList = new List<Student>();
            try
            {
                string searchID = Convert.ToInt32(SearchIdBox.Text).ToString();
                foreach (Student info in information)
                {
                    if (info.ID_Number.ToString().Contains(searchID))
                    {
                        updatedList.Add(info);
                    }
                }
                foreach (Student info in updatedList)
                {
                    dataGrid1.Items.Add(new Student() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                }
            }
            catch
            {
                MessageBox.Show("Please enter an ID number");
                dataGrid1.Items.Clear();
                foreach (Student info in information)
                {
                    dataGrid1.Items.Add(new Student() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                }
            }
        }
    }
}
