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
                Console.WriteLine();
                switch (key)
                {
                    //see the solution for a specific day
                    case ConsoleKey.D1:
                        Console.Write($"Please Choose a number between {1} and {solutions.Solutions.Count()} and press Return :");
                        int input;
                        while (!int.TryParse(Console.ReadLine(), out input))
                        {
                            Console.Write($"Please choose a valid number between {1} and {solutions.Solutions.Count()}: ");
                        }

                        input--;

                        Console.WriteLine("Writing out solutions...");
                        Console.WriteLine();
                        if (input < solutions.Solutions.Count())
                        {
                            DateTime startOne = DateTime.Now;

                            Console.WriteLine(solutions.Solutions[input].PartOne());

                            DateTime endOne = DateTime.Now;
                            TimeSpan pOneSpan = endOne - startOne;
                            Console.WriteLine($"part one in: {pOneSpan.Minutes}:{pOneSpan.Seconds}s:{pOneSpan.Milliseconds}ms");

                            Console.WriteLine();

                            DateTime startTwo = DateTime.Now;

                            Console.WriteLine(solutions.Solutions[input].PartTwo());

                            DateTime endTwo = DateTime.Now;
                            TimeSpan pTwoSpan = endTwo - startTwo;
                            Console.WriteLine($"part two in: {pTwoSpan.Minutes}:{pTwoSpan.Seconds}s:{pTwoSpan.Milliseconds}ms");
                        } else
                        {
                            Console.WriteLine("Your input was outside the range of the solved problems, going back to the menu...");
                        }

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
                Console.WriteLine();
                Console.WriteLine("Push any button to go back to the menu");
                Console.ReadKey();
            }
        }
    }
}
