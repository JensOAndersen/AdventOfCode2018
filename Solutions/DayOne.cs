using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Solutions
{
    public class DayOne : BaseSolution
    {
        int[] input;

        public DayOne(string fileName) : base(fileName)
        {
            input = utils.ReadFileAsIntArray();
        }

        public int PartTwo() //Loop through the list and look for duplicates infinitely
        {
            List<int> foundFrequencies = new List<int>() { 0 };

            int currentFrequency = 0;

            for (int i = 0; true; i++)
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

        public int PartOne()
        {
            //basically the sum of the list
            return input.Sum();
        }
    }
}
