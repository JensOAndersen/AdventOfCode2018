using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Utils;

namespace AdventOfCode2018
{
    class Program
    {
        static void Main(string[] args)
        {
            DayOne();

            Console.ReadKey();
        }

        static void DayOne()
        {
            AoCUtils utils = new AoCUtils();
            var input = utils.ReadFileAsIntArray("inputDayOne.txt");

            PartOne();
            PartTwo();

            //Iterate through the list infinitely until a frequency is seen again
            //This could probably need some optimization, i'm not sure how though - BUT IT WORKS!
            void PartTwo()
            {
                List<int> foundFrequencies = new List<int>() { 0 };

                int currentFrequency = 0;

                for (int i = 0; true ; i++)
                {
                    int index = i % input.Length;
                    currentFrequency += input[index];

                    if (foundFrequencies.Contains(currentFrequency))
                    {
                        Console.WriteLine($"The answer to part two is:{currentFrequency} in {i} iterations");
                        break;
                    }
                    else
                    {
                        foundFrequencies.Add(currentFrequency);
                    }
                }
            }

            //basically the sum of the array
            void PartOne()
            {
                var solution = input.Sum();
                Console.WriteLine(solution);
            }
        }
    }
}
