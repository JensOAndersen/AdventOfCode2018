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
            solutions.Add(new DayOne("inputDayOne.txt", "Day one"));
            solutions.Add(new DayTwo("inputDayTwo.txt", "Day two"));
            solutions.Add(new DayThree("inputDayThree.txt", "Day Three"));
        }
    }
}
