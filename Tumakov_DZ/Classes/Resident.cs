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
        private string Name;
        private Guid PassportNumber;
        private Problem Problem;
        private int ScandalLevel;
        private bool IsSmart;

        //public string Name
        //{
        //    get => name;
        //    set => name = value;
        //}

        //public Guid PassportNumber
        //{
        //    get => passportNumber;
        //    set => passportNumber = value;
        //}

        //public Problem Problem
        //{
        //    get => problem;
        //    set => problem = value;
        //}

        //public int ScandalLevel
        //{
        //    get => scandalLevel;
        //    set
        //    {
        //        if (value < 0 || value > 10)
        //            throw new ArgumentException("Уровень скандальности должен быть от 0 до 10.");
        //        scandalLevel = value;
        //    }
        //}

        //public bool IsSmart
        //{
        //    get => isSmart;
        //    set => isSmart = value;
        //}

        //public Resident(string name, Guid passportNumber, Problem problem, int scandalLevel, bool isSmart)
        //{
        //    Name = name;
        //    PassportNumber = passportNumber;
        //    Problem = problem;
        //    ScandalLevel = scandalLevel;
        //    IsSmart = isSmart;
        //}

        //public void DisplayInfo()
        //{
        //    Console.WriteLine($"Имя: {Name}\nПаспорт: {PassportNumber}\nПроблема: {Problem.Description}\nУровень скандальности: {ScandalLevel}\nУмный: {(IsSmart ? "Да" : "Нет")}");
        //}
    }
}
