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
    class NORMFlight: Flight
    {
        //Properties

        //Constructors


        //Methods
        public override double CalculateFees()
        {
            base.CalculateFees() + 500;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
