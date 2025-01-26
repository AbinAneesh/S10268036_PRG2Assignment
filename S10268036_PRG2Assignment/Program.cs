using System;
using System.Collections.Generic;
using System.IO;

namespace S10268036_PRG2Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dictionaries to store airlines and boarding gates
            Dictionary<string, Airline> airlines = new Dictionary<string, Airline>();
            Dictionary<string, BoardingGate> boardingGates = new Dictionary<string, BoardingGate>();

            // Load data from files
            LoadAirlines("airlines.csv", airlines);
            LoadBoardingGates("boardinggates.csv", boardingGates);

            // Display loaded data
            Console.WriteLine("\nLoaded Airlines:");
            foreach (var airline in airlines.Values)
            {
                Console.WriteLine(airline.ToString());
            }

            Console.WriteLine("\nLoaded Boarding Gates:");
            foreach (var gate in boardingGates.Values)
            {
                Console.WriteLine(gate.ToString());
            }

            Console.WriteLine("\nData loading complete. Press any key to exit.");
            Console.ReadKey();
        }

        static void LoadAirlines(string filePath, Dictionary<string, Airline> airlines)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length >= 2)
                        {
                            string code = parts[0].Trim();
                            string name = parts[1].Trim();

                            if (!airlines.ContainsKey(code))
                            {
                                Airline airline = new Airline(code, name);
                                airlines.Add(code, airline);
                            }
                        }
                    }
                    Console.WriteLine("Airlines loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading airlines file: {ex.Message}");
            }
        }

        static void LoadBoardingGates(string filePath, Dictionary<string, BoardingGate> boardingGates)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');

                        if (parts.Length >= 4)
                        {
                            string gateName = parts[0].Trim();
                            bool supportsCFFT = parts[1].Trim().ToLower() == "true";
                            bool supportsDDJB = parts[2].Trim().ToLower() == "true";
                            bool supportsLWTT = parts[3].Trim().ToLower() == "true";

                            if (!boardingGates.ContainsKey(gateName))
                            {
                                BoardingGate gate = new BoardingGate(gateName, supportsCFFT, supportsDDJB, supportsLWTT);
                                boardingGates.Add(gateName, gate);
                            }
                        }
                    }
                    Console.WriteLine("Boarding gates loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading boarding gates file: {ex.Message}");
            }
        }
    }
}
