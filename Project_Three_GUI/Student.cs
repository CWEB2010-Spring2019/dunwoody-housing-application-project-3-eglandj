﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Three_GUI
{
    //public class Student
    //{
    //    public string ID_Number { get; set; }
    //    public string firstName { get; set; }
    //    public string lastName { get; set; }
    //    public string studentType { get; set; }
    //    public int floorNumber { get; set; }
    //    public int roomNumber { get; set; }
    //    public double rentFee { get; set; }
    //    public Student(string csvLine)
    //    {
    //        string[] information = csvLine.Split(',');
    //        ID_Number = information[0];
    //        firstName = information[1];
    //        lastName = information[2];
    //        studentType = information[3];
    //        floorNumber = Convert.ToInt32(information[4]);
    //        roomNumber = Convert.ToInt32(information[5]);
    //        rentFee = Convert.ToDouble(information[6]);
    //    }
    //    public Student()
    //    {

    //    }
    //}
   
    abstract class Student
    {
        public string ID_Number { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string studentType { get; set; }
        public int floorNumber { get; set; }
        public int roomNumber { get; set; }
        public double rentFee { get; set; }

    }

    class Worker : Student
    {
        public Worker(string id, string first, string last, string type, int floor, int room, double monthHours)
        {
            ID_Number = id;
            firstName = first;
            lastName = last;
            studentType = type;
            floorNumber = floor;
            roomNumber = room;
            rentFee = 1245 - (0.5 * (monthHours * 14.00));
        }
        public Worker()
        {

        }
    }
    class Athlete : Student
    {
        public Athlete(string id, string first, string last, string type, int floor, int room)
        {
            ID_Number = id;
            firstName = first;
            lastName = last;
            studentType = type;
            floorNumber = floor;
            roomNumber = room;
            rentFee = 1200;
        }
        public Athlete()
        {

        }
    }
    class Scholarship : Student
    {
        public Scholarship(string id, string first, string last, string type, int floor, int room)
        {
            ID_Number = id;
            firstName = first;
            lastName = last;
            studentType = type;
            floorNumber = floor;
            roomNumber = room;
            rentFee = 100;
        }
        public Scholarship()
        {

        }
    }
}
