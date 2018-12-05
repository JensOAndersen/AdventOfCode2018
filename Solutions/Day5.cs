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
            Stack<char> unparsedInput = new Stack<char>(input.ToCharArray());
            Stack<char> parsedInput = new Stack<char>();

            parsedInput.Push(unparsedInput.Pop());
            while(unparsedInput.Count > 0)
            {
                Compare(parsedInput, unparsedInput);
            }

            void Compare(Stack<char> parsed, Stack<char> unparsed)
            {
                bool notDoneP = parsed.TryPop(out char p);
                bool notDoneUnP = unparsed.TryPop(out char unP);
                if (notDoneP && notDoneUnP)
                {
                    if (char.IsLower(unP) && char.IsUpper(p) && char.ToLower(p) == unP)
                    {
                        Compare(parsed, unparsed);
                    }
                    else if (char.IsLower(p) && char.IsUpper(unP) && char.ToLower(unP) == p)
                    {
                        Compare(parsed, unparsed);
                    } else
                    {
                        parsedInput.Push(p);
                        parsedInput.Push(unP);
                    }

                }
            }

            return parsedInput.Count.ToString();
        }
    }
}
