// Student Number	: S10268036
// Student Name	: Abin Aneesh
// Partner Name	: Louis Mosses
using System;
using System.Collections.Generic;

namespace S10268036_PRG2Assignment
{
    public class Airline
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public Dictionary<string, Flight> flights { get; private set; }

        public Airline(string code, string name)
        {
            Code = code;
            Name = name;
            flights = new Dictionary<string, Flight>();
        }

        public bool AddFlight(Flight flight)
        {
            if (!flights.ContainsKey(flight.flightNumber))
            {
                flights.Add(flight.flightNumber, flight);
                return true;
            }
            return false;  // Flight already exists
        }

        public bool RemoveFlight(string flightNumber)
        {
            return flights.Remove(flightNumber);
        }

        public double CalculateFees()
        {
            double total = 0;
            foreach (var flight in flights.Values)
            {
                total += flight.CalculateFees();
            }
            return total;
        }

        public override string ToString()
        {
            return $"Airline: {Name} ({Code}), Total Flights: {flights.Count}, Total Fees: {CalculateFees():C}";
        }
    }
}
