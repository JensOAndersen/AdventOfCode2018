using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace Solutions
{
    public class Day1 : BaseSolution
    {
        int[] input;
        
        public Day1(string fileName, string name) : base(fileName, name)
        {
            input = utils.ReadFileAsIntArray();
        }

        public override string PartTwo() //Loop through the list and look for duplicates infinitely
        {
            List<int> foundFrequencies = new List<int>() { 0 };

            int currentFrequency = 0;

            for (int i = 0; true; i++)
            {
                int index = i % input.Length;
                currentFrequency += input[index];

                if (foundFrequencies.Contains(currentFrequency))
                {
                    return currentFrequency.ToString();
                }
                else
                {
                    foundFrequencies.Add(currentFrequency);
                }
            }
        }

        public override string PartOne()
        {
            //basically the sum of the list
            return input.Sum().ToString();
        }
    }
}
