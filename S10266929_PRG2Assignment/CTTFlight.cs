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
    class CTTFlight : Flight
    {
        //Properties
        public double RequestFee { get; } = 150;

        //Constructors
        public CTTFlight() : base() { }
        public CTTFlight(string f, string r, string d, DateTime et)
            : base(f, r, d, et) { }
        //Methods
        public override double CalculateFees()
        {
            return base.CalculateFees() + RequestFee;
        }

        public override string ToString()
        {
            return base.ToString() + "Request Fee: " + RequestFee;
        }
    }
}