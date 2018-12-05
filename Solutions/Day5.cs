using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace Solutions
{
    public class Day5 : BaseSolution
    {
        string input;
        public Day5(string fileName, string name) : base(fileName, name)
        {
            input = utils.ReadFileAsStringArray()[0];
        }

        public override string PartOne()
        {
            bool noMatches = true;
            while (noMatches)
            {
                int index = 0;
                while (index + 1 < input.Length)
                {
                    char thisChar = input[index];
                    char nextChar = input[index + 1];

                    if (char.IsLower(thisChar) && char.IsUpper(nextChar) && char.ToLower(nextChar) == thisChar)
                    {
                        input = input.Remove(index, 2);
                        break;
                    }
                    else if (char.IsLower(nextChar) && char.IsUpper(thisChar) && char.ToLower(thisChar) == nextChar)
                    {
                        input = input.Remove(index, 2);
                        break;
                    }
                    
                    index++;
                }
                if (index + 1 == input.Length) noMatches = false;
            }


            return input.Length.ToString();
        }
    }
}
