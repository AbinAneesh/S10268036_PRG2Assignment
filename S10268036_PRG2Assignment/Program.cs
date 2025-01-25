using S10268036_PRG2Assignment.S10268036_PRG2Assignment;
using S10268036_PRG2Assignment;
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Terminal terminal = new Terminal();

        terminal.AddAirline(new Airline("SQ", "Singapore Airlines"));
        terminal.AddAirline(new Airline("MH", "Malaysia Airlines"));

        terminal.AddBoardingGate(new BoardingGate("A1"));
        terminal.AddBoardingGate(new BoardingGate("B2", "CFFT"));

        Console.WriteLine("Welcome to Terminal 5 Flight Information System");

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Display Boarding Gates");
            Console.WriteLine("2. Assign Flight to Gate");
            Console.WriteLine("3. Display Airlines");
            Console.WriteLine("4. Exit");
            Console.Write("Enter choice: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    terminal.DisplayAllGates();
                    break;
                case "2":
                    Console.Write("Enter Flight Number: ");
                    string flightNumber = Console.ReadLine();
                    Console.Write("Enter Boarding Gate: ");
                    string gateName = Console.ReadLine();
                    if (terminal.AssignFlightToGate(flightNumber, gateName))
                    {
                        Console.WriteLine("Flight assigned successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to assign flight. Gate may be occupied.");
                    }
                    break;
                case "3":
                    DisplayAirlines(terminal);
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void DisplayAirlines(Terminal terminal)
    {
        Console.WriteLine("\nList of Airlines:");
        foreach (var airline in terminal.Airlines.Values)
        {
            Console.WriteLine($"Code: {airline.Code}, Name: {airline.Name}");
        }
    }
}