using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Tumakov_DZ
{
    public class Resident
    {
        public string Name { get; set; }
        public Guid PassportNumber { get; set; }
        public Problem Problem { get; set; }
        public int ScandalLevel { get; set; }
        public int Smartness { get; set; }

        public Resident(string name, Problem problem, int scandalLevel, int smartness)
        {
            Name = name;
            PassportNumber = Guid.NewGuid();
            Problem = problem;
            ScandalLevel = scandalLevel;
            Smartness = smartness;
        }
    }
}
