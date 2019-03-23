using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI
{
    public class Student
    {
        public int ID_Number;
        public string firstName;
        public string lastName;
        public string studentType;
        public int floorNumber;
        public int roomNumber;
        public double rentFee;
        public Student(string csvLine)
        {
            string[] information = csvLine.Split(',');
            ID_Number = Convert.ToInt16(information[0]);
            firstName = information[1];
            lastName = information[2];
            studentType = information[3];
            floorNumber = Convert.ToInt32(information[4]);
            roomNumber = Convert.ToInt32(information[5]);
            rentFee = Convert.ToDouble(information[6]);
        }
    }
}
