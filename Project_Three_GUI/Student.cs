using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI
{
    public class Student
    {
        public int ID_Number { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string studentType { get; set; }
        public int floorNumber { get; set; }
        public int roomNumber { get; set; }
        public double rentFee { get; set; }
        public Student(string csvLine)
        {
            string[] information = csvLine.Split(',');
            ID_Number = Convert.ToInt32(information[0]);
            firstName = information[1];
            lastName = information[2];
            studentType = information[3];
            floorNumber = Convert.ToInt32(information[4]);
            roomNumber = Convert.ToInt32(information[5]);
            rentFee = Convert.ToDouble(information[6]);
        }
        public Student()
        {

        }
    }
}
