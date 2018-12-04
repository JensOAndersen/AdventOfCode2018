using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Solutions
{
    public class Day2 : BaseSolution
    {
        string[] input;
        public Day2(string fileName, string name) : base(fileName, name)
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
                        //i wanted to use linq to compare the strings, but intersect and except arent working as i expected them to
                        //so i had to do it the hard way. It works though

                        //another idea for a solution would be to build strings that is the result of the comparison of the two strings
                        //and then take the longest string there, as that string would have the most chars

                        //alternally the two foreach loops needs to be optimized, as some sets are being checked multiple times.
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
                            //result is: i o s n x m f k p a b c j p d y w v r t a h l u y
                            string res = "";
                            for (int i = 0; i < setOne.Count(); i++)
                            {
                                if (setOne.ElementAt(i) == setTwo.ElementAt(i))
                                {
                                    res += setOne.ElementAt(i);
                                }
                            }

                            return res;
                        }
                    }
                }
            }

            return "There was no string with a difference of one";
        }
    }
}
