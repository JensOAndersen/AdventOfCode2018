using System;
using System.Collections.Generic;
using System.Linq;
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
            List<IEnumerable<char>> myInput = new List<IEnumerable<char>>();
            foreach (string s in input)
            {
                myInput.Add(s.ToCharArray());
            }


            foreach (var setOne in myInput)
            {
                foreach (var setTwo in myInput)
                {
                    if(setOne != setTwo)
                    {
                        int diff = 0;

                        for (int i = 0; i < setOne.Count(); i++)
                        {
                            if (setOne.ElementAt(i) != setTwo.ElementAt(i))
                            {
                                diff++;
                            }
                        }
                        if (diff == 1)
                        {
                            string one = string.Join(" ", setOne);
                            string two = string.Join(" ", setTwo);
                            return string.Join("",setOne.Intersect(setTwo).ToList());
                        }
                    }
                }
            }

            return "There was no string with a difference of one";
        }
    }
}
