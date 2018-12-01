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
        List<BaseSolution> solutions = new List<BaseSolution>();
        static void Main(string[] args)
        {
            Console.WriteLine("Here is my Advent Of Code 2018 Solutions: ");

            DayOne dayOne = new DayOne("inputDayOne.txt");

            Console.WriteLine(dayOne.PartOne());
            Console.WriteLine(dayOne.PartTwo());
        }
    }
}
