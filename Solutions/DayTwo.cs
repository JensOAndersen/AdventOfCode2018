using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Solutions
{
    public class DayTwo : BaseSolution
    {
        string[] input;
        public DayTwo(string fileName, string name) : base(fileName, name)
        {
            input = utils.ReadFileAsStringArray();

            //input = new string[] {
            //    "abcdef",
            //    "bababc",
            //    "abbcde",
            //    "abcccd",
            //    "aabcdd",
            //    "abcdee",
            //    "ababab"
            //};
        }

        public override string PartOne()
        {
            int twos = 0;
            int threes = 0;
            foreach (string s in input)
            {
                Dictionary<char, int> charCounts = new Dictionary<char, int>();

                //loop through the string and assign values to the chars, counting how many times we've seen each char;
                foreach (char c in s)
                {
                    if (charCounts.ContainsKey(c))
                    {
                        charCounts[c]++;
                    }
                    else
                    {
                        charCounts.Add(c, 1);
                    }
                }

                //add to either twos and threes
                if (charCounts.ContainsValue(2)) twos++;
                if (charCounts.ContainsValue(3)) threes++;
            }

            return (twos * threes).ToString();
        }

        public override string PartTwo()
        {
            return "method not implemented";
        }
    }
}
