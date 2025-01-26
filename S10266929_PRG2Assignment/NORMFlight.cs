using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading.Tasks;
//==========================================================
// Student Number	: S10266929F
// Student Name	: Louis Vanhoucke
// Partner Name	: Abin Aneesh
//==========================================================

namespace FinalAssignment
{
    class NORMFlight : Flight
    {
        //Properties
        public NORMFlight() : base() { }
        public NORMFlight(string f, string r, string d, DateTime et)
            : base(f, r, d, et) { }
        //Constructors


        //Methods
        public override double CalculateFees()
        {
            return base.CalculateFees();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
