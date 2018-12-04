using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Utils;
using Solutions;
namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            SolutionHandler solutions = new SolutionHandler();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Advent of Code 2018!");

                Console.WriteLine("You have the following options: ");
                Console.WriteLine("1. Write a number to see the solutions for a day");
                Console.WriteLine("2. List all solutions");
                Console.WriteLine("3. Exit");

                ConsoleKey key = Console.ReadKey(true).Key;

                switch (key)
                {
                    //see the solution for a specific day
                    case ConsoleKey.D1:
                        Console.WriteLine($"Please Choose a number between {0} and {solutions.Solutions.Count() -1} and press Return");

                        int input;
                        while (!int.TryParse(Console.ReadLine(), out input))
                        {
                            Console.WriteLine($"Please choose a valid number between {0} and {solutions.Solutions.Count() -1}");
                        }

                        Console.WriteLine(solutions.Solutions[input].PartOne());
                        Console.WriteLine(solutions.Solutions[input].PartTwo());

                        break;

                    //Listing all registered solutions
                    case ConsoleKey.D2:
                        Console.WriteLine("Following days have been tried for completion: ");
                        foreach (var item in solutions.Solutions)
                        {
                            Console.WriteLine($"{item}");
                        }
                        break;

                    //exit the program
                    case ConsoleKey.D3:
                        Environment.Exit(0);
                        break;

                    //invalid option
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
