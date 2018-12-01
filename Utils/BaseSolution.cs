using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public abstract class BaseSolution
    {
        protected readonly AoCUtils utils;
        private string name;

        public BaseSolution(string fileName, string name)
        {
            this.utils = new AoCUtils(fileName);
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public abstract string PartOne();
        public abstract string PartTwo();
    }
}
