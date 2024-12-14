using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_DZ
{
    public class Problem
    {
        public int Number { get; set; } // 0 - отопление, 1 - оплата, 2 - остальное
        public string Description { get; set; }

        public Problem(int number, string description)
        {
            Number = number;
            Description = description;
        }
    }
}