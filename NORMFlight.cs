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
            double fee = 300;
            if (Destination == "Singapore (SIN)")
            {
                fee += 500;
            }
            else if (Destination != "Singapore (SIN)" && Origin == "Singapore (SIN)")
            {
                fee += 800;
            }
            return fee;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
