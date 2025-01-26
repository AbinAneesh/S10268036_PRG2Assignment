using System.Threading.Tasks;
//==========================================================
// Student Number	: S10266929F
// Student Name	: Louis Vanhoucke
// Partner Name	: Abin Aneesh
//==========================================================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment
{
    class DDJBFlight: Flight
    {
        //Properties
        public double RequestFee { get; set; }

        //Constructors
        public DDJBFlight() { }
        public DDJBFlight(string f, string r, string d, DateTime et, string s, double rf) : base(f, r, d, et, s)
        {
            RequestFee = rf;
        }

        //Methods
        public override double CalculateFees()
        {
            base.CalculateFees() + 300;
        }

        public override string ToString()
        {
            return base.ToString() + "Request Fee: " + RequestFee;
        }
    }
}

