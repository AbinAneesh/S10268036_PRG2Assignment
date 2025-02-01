using System;
using System.Collections.Generic;
using System.IO;
using S10268036_PRG2Assignment;
using S10286036_PRG2Assignment;

namespace AirportManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Flight> flights = new Dictionary<string, Flight>();
            Dictionary<string, BoardingGate> gates = new Dictionary<string, BoardingGate>();
            Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
            LoadFlights("flights.csv", flights);
            LoadGates(gates);

            Console.WriteLine("\nLoaded Flights:");
            ListAllFlights(flights);



            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=============================================\r\n\r\nWelcome to Changi Airport Terminal 5\r\n\r\n=============================================");
                Console.WriteLine("1. List All Flights");
                Console.WriteLine("2. List all boarding gates");
                Console.WriteLine("3. Assign a boarding gate to a flight");
                Console.WriteLine("4. Create a new flight");
                Console.WriteLine("5. Display Airline Flights");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option (1-5): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListAllFlights(flights);
                        break;
                    case "2":
                        ListAllBoardingGates(gates);
                        break;
                    case "3":
                        AssignBoardingGate(flights, gates);
                        break;
                    case "4":
                        CreateNewFlight(flights);
                        break;
                    case "5":
                        DisplayAirlineFlights(airlines, flights);
                        break;
                    case "6":

                        break;
                    case "0":
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please select a number between 1 and 5.");
                        break;
                }
            }
        }

        static void AssignBoardingGate(Dictionary<string, Flight> flights, Dictionary<string, BoardingGate> gates)
        {
            Console.Write("Enter flight number: ");
            string flightNumber = Console.ReadLine();

            if (!flights.ContainsKey(flightNumber))
            {
                Console.WriteLine("Flight not found.");
                return;
            }

            Console.Write("Enter boarding gate: ");
            string gateName = Console.ReadLine();

            if (!gates.ContainsKey(gateName))
            {
                Console.WriteLine("Gate not found.");
                return;
            }

            BoardingGate gate = gates[gateName];
            if (!gate.IsAvailable)
            {
                Console.WriteLine("Gate is already assigned to another flight.");
                return;
            }

            Console.WriteLine("Error: Cannot assign abstract Flight type to BoardingGate.");
            // flights[flightNumber].BoardingGate = gateName; // Removed due to Flight class constraints
            Console.WriteLine($"Boarding gate {gateName} assigned to flight {flightNumber}.");
        }

        static void CreateNewFlight(Dictionary<string, Flight> flights)
        {
            Console.Write("Enter flight number: ");
            string flightNumber = Console.ReadLine();
            Console.Write("Enter origin: ");
            string origin = Console.ReadLine();
            Console.Write("Enter destination: ");
            string destination = Console.ReadLine();
            Console.Write("Enter expected departure time (yyyy-MM-dd HH:mm): ");

            if (!DateTime.TryParse(Console.ReadLine(), out DateTime expectedTime))
            {
                Console.WriteLine("Invalid date format. Flight not created.");
                return;
            }

            Console.Write("Enter special request code (DDJB, CFFT, LWTT, or leave empty for normal flight): ");
            string requestCode = Console.ReadLine().Trim().ToUpper();

            Flight newFlight;
            switch (requestCode)
            {
                case "DDJB":
                    newFlight = new DDJBFlight(flightNumber, origin, destination, expectedTime);
                    break;
                case "CTTF":
                    newFlight = new CTTFlight(flightNumber, origin, destination, expectedTime);
                    break;
                case "LWTT":
                    newFlight = new LWTTFlight(flightNumber, origin, destination, expectedTime);
                    break;
                default:
                    newFlight = new NORMFlight(flightNumber, origin, destination, expectedTime);
                    break;
            }

            flights.Add(flightNumber, newFlight);
            Console.WriteLine("Flight created successfully.");
        }


        static void LoadFlights(string filePath, Dictionary<string, Flight> flights)
        {
            try
            {
                // Read all lines from the file
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1)) // Skip header
                {
                    // Split the line into fields
                    var fields = line.Split(',');

                    // Extract flight details
                    string flightNumber = fields[0].Trim();
                    string origin = fields[1].Trim();
                    string destination = fields[2].Trim();
                    DateTime expectedTime = DateTime.Parse(fields[3].Trim());
                    string requestCode = fields.Length > 4 ? fields[4].Trim() : string.Empty;

                    // Create the flight object based on the request code
                    Flight flight;
                    if (requestCode == "DDJB")
                    {
                        flight = new DDJBFlight(flightNumber, origin, destination, expectedTime);
                    }
                    else if (requestCode == "CTTF")
                    {
                        flight = new CTTFlight(flightNumber, origin, destination, expectedTime);
                    }
                    else if (requestCode == "LWTT")
                    {
                        flight = new LWTTFlight(flightNumber, origin, destination, expectedTime);
                    }
                    else
                    {
                        flight = new NORMFlight(flightNumber, origin, destination, expectedTime);
                    }

                    // Add the flight to the dictionary
                    flights[flightNumber] = flight;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading flights: {ex.Message}");
            }
        }

        static void LoadGates(Dictionary<string, BoardingGate> gates)
        {
            gates.Add("A1", new BoardingGate("A1", true, false, false));
            gates.Add("B2", new BoardingGate("B2", false, true, false));
            gates.Add("C3", new BoardingGate("C3", false, false, true));
        }

        static void ListAllFlights(Dictionary<string, Flight> flights)
        {
            Console.WriteLine("\n===== List of All Flights =====");
            foreach (var flight in flights.Values)
            {
                Console.WriteLine(flight.ToString());
                Console.WriteLine("-----------------------------------");
            }
        }

        static void ListAllBoardingGates(Dictionary<string, BoardingGate> gates)
        {
            Console.WriteLine("\n===== List of All Boarding Gates =====");
            foreach (var gate in gates.Values)
            {
                Console.WriteLine(gate.ToString());
                Console.WriteLine("-----------------------------------");
            }
        }
        static void DisplayAirlineFlights(Dictionary<string, Airline> airlines, Dictionary<string, Flight> flights)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("\nList of Airlines for Changi Airport Terminal 5\n");
            Console.WriteLine("=============================================");
            Console.WriteLine("Airline Code\tAirline Name");

            foreach (var airline in airlines.Values)
            {
                Console.WriteLine($"{airline.Code}\t{airline.Name}");
            }

            Console.Write("\nEnter Airline Code: ");
            string airlineCode = Console.ReadLine().ToUpper();

            if (!airlines.ContainsKey(airlineCode))
            {
                Console.WriteLine("Invalid airline code.");
                return;
            }
        }
                static void ModifyFlightDetails(Dictionary<string, Airline> airlines, Dictionary<string, Flight> flights)
        {
            Console.WriteLine("\n===== List of Airlines =====");
            foreach (var airline in airlines.Values)
            {
                Console.WriteLine($"{airline.Code} - {airline.Name}");
            }
            
            Console.Write("Enter the 2-letter Airline Code: ");
            string airlineCode = Console.ReadLine().ToUpper();
            
            if (!airlines.ContainsKey(airlineCode))
            {
                Console.WriteLine("Invalid airline code.");
                return;
            }
            
            Airline selectedAirline = airlines[airlineCode];
            var airlineFlights = flights.Values.Where(f => f.AirlineCode == airlineCode).ToList();
            
            if (airlineFlights.Count == 0)
            {
                Console.WriteLine("No flights found for this airline.");
                return;
            }
            
            Console.WriteLine("\nFlights for this airline:");
            foreach (var flight in airlineFlights)
            {
                Console.WriteLine(flight.ToString());
            }
            
            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Modify an existing flight");
            Console.WriteLine("2. Delete an existing flight");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.Write("Enter Flight Number to modify: ");
                string flightNumber = Console.ReadLine();
                
                if (!flights.ContainsKey(flightNumber))
                {
                    Console.WriteLine("Flight not found.");
                    return;
                }
                
                Flight flightToModify = flights[flightNumber];
                Console.WriteLine("\nSelect the detail to modify:");
                Console.WriteLine("1. Origin");
                Console.WriteLine("2. Destination");
                Console.WriteLine("3. Expected Departure Time");
                Console.WriteLine("4. Status");
                Console.WriteLine("5. Special Request Code");
                Console.WriteLine("6. Boarding Gate");
                Console.Write("Enter choice: ");
                string modifyChoice = Console.ReadLine();
                
                switch (modifyChoice)
                {
                    case "1":
                        Console.Write("Enter new Origin: ");
                        flightToModify.Origin = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Enter new Destination: ");
                        flightToModify.Destination = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Enter new Expected Departure Time (yyyy-MM-dd HH:mm): ");
                        if (DateTime.TryParse(Console.ReadLine(), out DateTime newTime))
                            flightToModify.ExpectedDeparture = newTime;
                        else
                            Console.WriteLine("Invalid date format.");
                        break;
                    case "4":
                        Console.Write("Enter new Status: ");
                        flightToModify.Status = Console.ReadLine();
                        break;
                    case "5":
                        Console.Write("Enter new Special Request Code (or leave empty for none): ");
                        flightToModify.SpecialRequest = Console.ReadLine();
                        break;
                    case "6":
                        Console.Write("Enter new Boarding Gate: ");
                        flightToModify.BoardingGate = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        return;
                }
                
                Console.WriteLine("Flight details updated successfully.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter Flight Number to delete: ");
                string flightNumber = Console.ReadLine();
                
                if (!flights.ContainsKey(flightNumber))
                {
                    Console.WriteLine("Flight not found.");
                    return;
                }
                
                Console.Write("Are you sure you want to delete this flight? (Y/N): ");
                string confirm = Console.ReadLine().ToUpper();
                
                if (confirm == "Y")
                {
                    flights.Remove(flightNumber);
                    Console.WriteLine("Flight deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Deletion cancelled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
            
            Console.WriteLine("\nUpdated Flight Details:");
            foreach (var flight in flights.Values)
            {
                Console.WriteLine(flight.ToString());
            }
        }

    }
}
