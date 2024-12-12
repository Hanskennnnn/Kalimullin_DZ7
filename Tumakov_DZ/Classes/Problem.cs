using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_DZ
{
    internal class Problem
    {
        public int Number { get; set; }
        public string Description { get; set; }

        public Problem(int number, string description)
        {
            Number = number;
            Description = description;
        }
    }
}