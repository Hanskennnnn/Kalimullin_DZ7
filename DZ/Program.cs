using System;
using System.Collections.Generic;


namespace DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }
        static void Task1()
        {
   
            Employee timur = new Employee("Тимур", "Генеральный директор");
            Employee rashid = new Employee("Рашид", "Финансовый директор");
            Employee ilham = new Employee("О Ильхам", "Директор по автоматизации");
            Employee lukas = new Employee("Лукас", "Главный бухгалтер");
            Employee orkadiy = new Employee("Оркадий", "Начальник инф систем");
            Employee volodia = new Employee("Володя", "Зам. начальника");
            Employee ilshat = new Employee("Ильшат", "Главный системщик");
            Employee ivanych = new Employee("Иваныч", "Зам. системщика");
            Employee sergey = new Employee("Сергей", "Главный разработчик");
            Employee lyaisan = new Employee("Ляйсан", "Зам. разработчика");


            timur.Subordinates.AddRange(new[] { rashid, ilham });
            rashid.Subordinates.Add(lukas);
            ilham.Subordinates.AddRange(new[] { orkadiy, volodia });
            orkadiy.Subordinates.AddRange(new[] { ilshat, ivanych });
            volodia.Subordinates.AddRange(new[] { sergey, lyaisan });
            ilshat.Subordinates.AddRange(new[] { new Employee("Илья", "Системщик"), new Employee("Витя", "Системщик"), new Employee("Женя", "Системщик") });
            sergey.Subordinates.AddRange(new[] { new Employee("Марат", "Разработчик"), new Employee("Дина", "Разработчик"), new Employee("Ильдар", "Разработчик"), new Employee("Антон", "Разработчик") });



      
            List<Tuple<Employee, string, Employee>> tasks = new List<Tuple<Employee, string, Employee>>()
            {
                new Tuple<Employee, string, Employee>(lukas, "Автоматизировать отчетность", ilham),
                new Tuple<Employee, string, Employee>(orkadiy, "Настроить сеть", ilshat),
                new Tuple<Employee, string, Employee>(volodia, "Разработать новый модуль", sergey)
            };

     
            foreach (var task in tasks)
            {
                bool accepted = task.Item3.AcceptsTaskFrom(task.Item1);
                string message = accepted ?
                    $"От {task.Item1} даётся задача \"{task.Item2}\" {task.Item3}. Задача принята." :
                    $"От {task.Item1} даётся задача \"{task.Item2}\" {task.Item3}. Задача отклонена.";
                Console.WriteLine(message);
            }
            Console.ReadKey();
        }

    }
}
