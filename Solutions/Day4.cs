using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace Solutions
{
    public class Day4 : BaseSolution
    {
        string[] input;
        public Day4(string fileName, string name) : base(fileName, name)
        {
            input = utils.ReadFileAsStringArray();
        }
    }
}
