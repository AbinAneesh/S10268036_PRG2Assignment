namespace S10268036_PRG2Assignment
{
    public class Terminal
    {
        public Dictionary<string, Airline> Airlines { get; set; }
        public Dictionary<string, BoardingGate> BoardingGates { get; set; }
        public Dictionary<string, Flight> Flights { get; set; }
        public Dictionary<string, double> GateFees { get; set; }
        public string TerminalName { get; set; }

        public Terminal(string terminalName)
        {
            TerminalName = terminalName;
            Airlines = new Dictionary<string, Airline>();
            BoardingGates = new Dictionary<string, BoardingGate>();
            Flights = new Dictionary<string, Flight>();
            GateFees = new Dictionary<string, double>();
        }

        public bool AddAirline(Airline airline)
        {
            if (!Airlines.ContainsKey(airline.Code))
            {
                Airlines.Add(airline.Code, airline);
                return true;
            }
            return false; // Airline already exists
        }

        public bool AddBoardingGate(BoardingGate gate)
        {
            if (!BoardingGates.ContainsKey(gate.GateName))
            {
                BoardingGates.Add(gate.GateName, gate);
                return true;
            }
            return false; // Gate already exists
        }

        public Airline GetAirlineFromFlight(string flightNumber)
        {
            if (Flights.ContainsKey(flightNumber))
            {
                foreach (var airline in Airlines.Values)
                {
                    if (airline.Flights.ContainsKey(flightNumber))
                    {
                        return airline;
                    }
                }
            }
            return null; // Flight not found
        }

        public void PrintAirlineFees()
        {
            foreach (var airline in Airlines.Values)
            {
                Console.WriteLine($"Airline: {airline.Name}, Total Fees: {airline.CalculateFees():C}");
            }
        }

        public override string ToString()
        {
            return $"Terminal: {TerminalName}, Airlines: {Airlines.Count}, Gates: {BoardingGates.Count}, Flights: {Flights.Count}";
        }
    }
}
