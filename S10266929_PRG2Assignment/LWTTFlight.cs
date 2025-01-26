using System.Threading.Tasks;
//==========================================================
// Student Number	: S10266929F
// Student Name	: Louis Vanhoucke
// Partner Name	: Abin Aneesh
//==========================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssignment
{
    class LWTTFlight: Flight
    {
        //Properties
        public double RequestFee { get; set; }

        //Constructors
        public LWTTFlight() { }
        public LWTTFlight(string f, string r, string d, DateTime et, string s, double rf) : base(f, r, d, et, s)
        {
            RequestFee = rf;
        }

        //Methods
        public override double CalculateFees()
        {
            double fee = 300 + 500;
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
            return base.ToString() + "Request Fee: " + RequestFee;
        }
    }
}
