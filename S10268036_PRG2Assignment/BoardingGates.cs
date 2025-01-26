// Student Number	: S10268036
// Student Name	: Abin Aneesh
// Partner Name	: Louis Mosses

using System;

namespace S10268036_PRG2Assignment
{
    public class BoardingGate
    {
        public string GateName { get; set; }
        public bool SupportsCFFT { get; set; }
        public bool SupportsDDJB { get; set; }
        public bool SupportsLWTT { get; set; }
        public Flight Flight { get; set; }

        public BoardingGate(string gateName, bool supportsCFFT = false, bool supportsDDJB = false, bool supportsLWTT = false)
        {
            GateName = gateName;
            SupportsCFFT = supportsCFFT;
            SupportsDDJB = supportsDDJB;
            SupportsLWTT = supportsLWTT;
            Flight = null;
        }

        public bool IsAvailable => Flight == null;

        public double CalculateFees()
        {
            double baseFee = 100.0; // Example base fee
            if (SupportsCFFT) baseFee += 50.0;
            if (SupportsDDJB) baseFee += 75.0;
            if (SupportsLWTT) baseFee += 60.0;
            return baseFee;
        }

        public override string ToString()
        {
            return $"Gate: {GateName}, Available: {IsAvailable}, Assigned Flight: {(Flight != null ? Flight.FlightNumber : "None")}, Fee: {CalculateFees():C}";
        }
    }
}
