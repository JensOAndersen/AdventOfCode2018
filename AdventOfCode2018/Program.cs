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
            var dayOne = DayOne();

            Console.WriteLine(dayOne.partOne);
            Console.WriteLine(dayOne.partTwo);

            Console.ReadKey();
        }

        static (int partOne, int partTwo) DayOne()
        {
            AoCUtils utils = new AoCUtils();
            var input = utils.ReadFileAsIntArray("inputDayOne.txt");

            return (PartOne(), PartTwo());

            //Iterate through the list infinitely until a frequency is seen again
            //This could probably need some optimization, i'm not sure how though - BUT IT WORKS!
            int PartTwo()
            {
                List<int> foundFrequencies = new List<int>() { 0 };

                int currentFrequency = 0;

                for (int i = 0; true ; i++)
                {
                    int index = i % input.Length;
                    currentFrequency += input[index];

                    if (foundFrequencies.Contains(currentFrequency))
                    {
                        return currentFrequency;
                    }
                    else
                    {
                        foundFrequencies.Add(currentFrequency);
                    }
                }
            }

            //basically the sum of the array
            int PartOne()
            {
                return input.Sum();
            }
        }
    }
}
