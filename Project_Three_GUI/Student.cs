using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI
{
    abstract class Student
    {
        protected int ID_Number;
        protected string firstName;
        protected string lastName;
        protected int floorNumber;
        protected int roomNumber;
        protected double rentFee;
    }
    class Scholarship : Student
    {
        public static int[] floorOptions = { 1, 2, 3 };
        Dictionary<int, Scholarship> roomOccupied = new Dictionary<int, Scholarship>();
        public int[] roomOptions = new int[20];

        public Scholarship(int id, string fname, string lname, int floor, int room)
        {
            ID_Number = id;
            firstName = fname;
            lastName = lname;
            floorNumber = floor;
            roomNumber = room;
            rentFee = 100;
        }
    }
    class Athlete : Student
    {
        public static int[] floorOptions = { 4, 5, 6 };
        public Athlete(int id, string fname, string lname, int floor, int room)
        {
            ID_Number = id;
            firstName = fname;
            lastName = lname;
            floorNumber = floor;
            roomNumber = room;
            rentFee = 1200;
        }
    }
    class Worker : Student
    {
        public static int[] floorOptions = { 7, 8 };
        private double hourlyPay;
        private double monthlyHours;
        public Worker(int id, string fname, string lname, int floor, int room, int monthHours)
        {
            ID_Number = id;
            firstName = fname;
            lastName = lname;
            floorNumber = floor;
            roomNumber = room;
            monthlyHours = monthHours;
            hourlyPay = 14.00;
            double monthlyPay = hourlyPay * monthlyHours;
            rentFee = 1245 - (0.5 * monthlyPay);
        }
    }
}
