using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Solutions
{
    public class SolutionHandler
    {
        private List<BaseSolution> solutions = new List<BaseSolution>();

        public BaseSolution[] Solutions
        {
            get { return solutions.ToArray(); }
        }

        public SolutionHandler()
        {
            solutions.Add(new Day1("inputDayOne.txt", "Day one"));
            solutions.Add(new Day2("inputDayTwo.txt", "Day two"));
            solutions.Add(new Day3("inputDayThree.txt", "Day Three"));
            solutions.Add(new Day4("inputDayFour.txt", "Day Four"));
        }
    }
}
