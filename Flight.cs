using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//==========================================================
// Student Number	: S10266929F
// Student Name	: Louis Vanhoucke
// Partner Name	: Abin Aneesh
//==========================================================



namespace FinalAssignment
{
    abstract class Flight
    {
        //Properties
        public string  FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime ExpectedTime { get; set; }
        public  string Status { get; set; }

        //Constructors
        public Flight() { }
        public Flight(string f, string r, string d, DateTime et, string s)
        {
            FlightNumber = f;
            Origin = r;
            Destination = d;
            ExpectedTime = et;
            Status = s;
        }

        //Methods
        public abstract double CalculateFees();

        public override string ToString()
        {
            return "Flight Number: " + FlightNumber + "\tOrigin: " + Origin + "Destination: " + Destination + 
                "Expected Time: " + ExpectedTime + "Status: " + Status;
        }
    }
}
