using System;
using System.Collections.Generic;
using System.Data;
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
        string[] information = File.ReadAllLines(@"..\..\Student_Data.csv");//Reading all lines from the csv file
                                       
        public ResidentSearch()
        {
            InitializeComponent();
            numberOfStudents(information);
            generate_columns(information);
        }
        private void numberOfStudents(string[] information)
        {
            IEnumerable<string> AthleteQuery =
                from info in information
                let elements = info.Split(',')
                where elements[3].ToString() == "Athlete"
                select elements[3];

            IEnumerable<string> WorkerQuery =
                from info in information
                let elements = info.Split(',')
                where elements[3].ToString() == "Worker"
                select elements[3];


            IEnumerable<string> ScholarshipQuery =
                from info in information
                let elements = info.Split(',')
                where elements[3].ToString() == "Scholarship"
                select elements[3];

            AthleteStudents.Content = "Number of Athlete Students: " + AthleteQuery.Count();
            ScholarStudents.Content = "Number of Scholar Students: " + ScholarshipQuery.Count();
            WorkerStudents.Content = "Number of Worker Students: " + WorkerQuery.Count();
            floorRangeA.Content = "Number of Students on floors (1-3): " + WorkerQuery.Count();
            floorRangeB.Content = "Number of Students on floors (4-6): " + AthleteQuery.Count();
            floorRangeC.Content = "Number of Students on floors (7-8): " + ScholarshipQuery.Count();
        }
        private void generate_columns(string[] information)
        {
            IEnumerable<Athlete> AthleteQuery =
               from info in information
               let elements = info.Split(',')
               where elements[3].ToString() == "Athlete"
               select new Athlete()
               {
                   ID_Number = elements[0],
                   firstName = elements[1],
                   lastName = elements[2],
                   studentType = elements[3],
                   floorNumber = Convert.ToInt32(elements[4]),
                   roomNumber = Convert.ToInt32(elements[5]),
                   rentFee = Convert.ToDouble(elements[6])
               };
            List<Athlete> athleteList = AthleteQuery.ToList();

            IEnumerable<Worker> WorkerQuery =
                from info in information
                let elements = info.Split(',')
                where elements[3].ToString() == "Worker"
                select new Worker()
                {
                    ID_Number = elements[0],
                    firstName = elements[1],
                    lastName = elements[2],
                    studentType = elements[3],
                    floorNumber = Convert.ToInt32(elements[4]),
                    roomNumber = Convert.ToInt32(elements[5]),
                    rentFee = Convert.ToDouble(elements[6])
                };
            List<Worker> workerList = WorkerQuery.ToList();

            IEnumerable<Scholarship> ScholarshipQuery =
                from info in information
                let elements = info.Split(',')
                where elements[3].ToString() == "Scholarship"
                select new Scholarship()
                {
                    ID_Number = elements[0],
                    firstName = elements[1],
                    lastName = elements[2],
                    studentType = elements[3],
                    floorNumber = Convert.ToInt32(elements[4]),
                    roomNumber = Convert.ToInt32(elements[5]),
                    rentFee = Convert.ToDouble(elements[6])
                };
            List<Scholarship> scholarshipList = ScholarshipQuery.ToList();

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
            foreach (Athlete info in athleteList)
            {
                dataGrid1.Items.Add(new Athlete() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
            }
            foreach (Worker info in workerList)
            {
                dataGrid1.Items.Add(new Worker() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
            }
            foreach (Scholarship info in scholarshipList)
            {
                dataGrid1.Items.Add(new Scholarship() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            dataGrid1.Items.Clear();
            IEnumerable<Athlete> AthleteQuery =
               from info in information
               let elements = info.Split(',')
               where elements[3].ToString() == "Athlete"
               select new Athlete()
               {
                   ID_Number = elements[0],
                   firstName = elements[1],
                   lastName = elements[2],
                   studentType = elements[3],
                   floorNumber = Convert.ToInt32(elements[4]),
                   roomNumber = Convert.ToInt32(elements[5]),
                   rentFee = Convert.ToDouble(elements[6])
               };
            List<Athlete> athleteList = AthleteQuery.ToList();

            IEnumerable<Worker> WorkerQuery =
                from info in information
                let elements = info.Split(',')
                where elements[3].ToString() == "Worker"
                select new Worker()
                {
                    ID_Number = elements[0],
                    firstName = elements[1],
                    lastName = elements[2],
                    studentType = elements[3],
                    floorNumber = Convert.ToInt32(elements[4]),
                    roomNumber = Convert.ToInt32(elements[5]),
                    rentFee = Convert.ToDouble(elements[6])
                };
            List<Worker> workerList = WorkerQuery.ToList();

            IEnumerable<Scholarship> ScholarshipQuery =
                from info in information
                let elements = info.Split(',')
                where elements[3].ToString() == "Scholarship"
                select new Scholarship()
                {
                    ID_Number = elements[0],
                    firstName = elements[1],
                    lastName = elements[2],
                    studentType = elements[3],
                    floorNumber = Convert.ToInt32(elements[4]),
                    roomNumber = Convert.ToInt32(elements[5]),
                    rentFee = Convert.ToDouble(elements[6])
                };
            List<Scholarship> scholarshipList = ScholarshipQuery.ToList();

            try
            {
                string searchID = Convert.ToInt32(SearchIdBox.Text).ToString();
                
                foreach (Athlete info in athleteList)
                {
                    if (info.ID_Number.ToString().Contains(searchID))
                    {
                        dataGrid1.Items.Add(new Athlete() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                    }
                }
                foreach (Worker info in workerList)
                {
                    if (info.ID_Number.ToString().Contains(searchID))
                    {
                        dataGrid1.Items.Add(new Worker() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                    }
                }
                foreach (Scholarship info in scholarshipList)
                {
                    if (info.ID_Number.ToString().Contains(searchID))
                    {
                        dataGrid1.Items.Add(new Scholarship() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                    }
                }
            }
            catch
            {
                MessageBox.Show("Please enter an ID number");
                dataGrid1.Items.Clear();
                foreach (Athlete info in athleteList)
                {
                    dataGrid1.Items.Add(new Athlete() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                }
                foreach (Worker info in workerList)
                {
                    dataGrid1.Items.Add(new Worker() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                }
                foreach (Scholarship info in scholarshipList)
                {
                    dataGrid1.Items.Add(new Scholarship() { ID_Number = info.ID_Number, firstName = info.firstName, lastName = info.lastName, studentType = info.studentType, floorNumber = info.floorNumber, roomNumber = info.roomNumber, rentFee = info.rentFee });
                }
            }
        }
    }
}
