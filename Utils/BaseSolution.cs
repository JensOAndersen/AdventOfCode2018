using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    public class BaseSolution
    {
        protected readonly AoCUtils utils;

        public BaseSolution(string fileName)
        {
            this.utils = new AoCUtils(fileName);
        }
    }
}
