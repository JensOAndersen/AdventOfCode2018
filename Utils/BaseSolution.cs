using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public  class BaseSolution
    {
        protected readonly AoCUtils utils;
        private string name;

        protected BaseSolution(string fileName, string name)
        {
            this.utils = new AoCUtils(fileName);
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public virtual string PartOne()
        {
            return "Method not implemented";
        }
        public virtual string PartTwo()
        {
            return "Method not implemented";
        }
    }
}
