using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tumakov_DZ;


namespace Tumakov_DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            //Task6();
            Task7();
        }
        static  void Task1()
        {
            Console.WriteLine("Задание 8.1");
      
            BankAccount account1 = new BankAccount("Иван Иванов", 5000);
            BankAccount account2 = new BankAccount("Мария Петрова", 3000);


            account1.DisplayInfo();
            account2.DisplayInfo();


            Console.WriteLine("\nПеревод 1500 со счета Иван Иванов на счет Мария Петрова:");
            account1.TransferTo(account2, 1500);

   
            Console.WriteLine("\nОбновленные счета:");
            account1.DisplayInfo();
            account2.DisplayInfo();
        }
        static void Task2()
        {
            Console.WriteLine("Задание 8.2");
            Console.WriteLine("Введите строку:");
            string input = Console.ReadLine();

            string reversedString = ReverseString(input);
            Console.WriteLine($"Измененная строка: {reversedString}");
        }
        static void Task3()
        {
            Console.WriteLine("Введите полный путь к входному файлу:");
        string inputFilePath = Console.ReadLine();

        Console.WriteLine("Введите имя выходного файла (полный путь или имя в текущем каталоге):");
        string outputFilePath = Console.ReadLine();

        try
        {

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine($"Файл {inputFilePath} не найден.");
                return;
            }

    
            string content = File.ReadAllText(inputFilePath);
            string uppercaseContent = content.ToUpper();
            File.WriteAllText(outputFilePath, uppercaseContent);

            Console.WriteLine($"Содержимое файла {inputFilePath} успешно записано в файл {outputFilePath} заглавными буквами.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
        }
        static void Task4()
        {
            Console.WriteLine("Введите значение для проверки на реализацию интерфейса IFormattable:");
            string input = Console.ReadLine();


            CheckIfIFormattable(input);

   
            double number = 123.45;
            CheckIfIFormattable(number);

  
            object obj = new object();
            CheckIfIFormattable(obj);
        }
        static void Task5()
        {
            Console.WriteLine("\nДомашнее задание 8.1");
            string projectPath = AppDomain.CurrentDomain.BaseDirectory;
            string resourcesPath = Path.Combine(projectPath, "resources");
            string inputFilePath = Path.Combine(resourcesPath, "input.txt");
            string outputFilePath = Path.Combine(resourcesPath, "emails.txt");

            // Проверяем наличие папки
            if (!Directory.Exists(resourcesPath))
            {
                Directory.CreateDirectory(resourcesPath);
                Console.WriteLine($"Папка 'resources' была создана. Поместите в неё файл 'input.txt' и запустите программу снова.");
                return;
            }



            try
            {
                string[] lines = File.ReadAllLines(inputFilePath);
                string[] emails = new string[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    string line = lines[i];
                    SearchMail(ref line);
                    emails[i] = line;
                }

                File.WriteAllLines(outputFilePath, emails);
                Console.WriteLine($"Список e-mail успешно записан в файл '{outputFilePath}'.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
        public static void SearchMail(ref string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                s = string.Empty;
                return;
            }

            int separatorIndex = s.IndexOf('#');
            if (separatorIndex != -1 && separatorIndex + 1 < s.Length)
            {
                s = s.Substring(separatorIndex + 1).Trim();
            }
            else
            {
                s = string.Empty; 
            }
        }
        static void Task6()
        {
            Console.WriteLine("\nДомашнее задание 8.2");

            List<Song> songs = new List<Song>
        {
            new Song(),
            new Song(),
            new Song(),
            new Song()
        };

    
            songs[0].SetName("Song 1");
            songs[0].SetAuthor("Author 1");
            songs[1].SetName("Song 2");
            songs[1].SetAuthor("Author 2");
            songs[2].SetName("Song 3");
            songs[2].SetAuthor("Author 3");
            songs[3].SetName("Song 4");
            songs[3].SetAuthor("Author 4");

            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].SetPrev(songs[i - 1]);
            }

     
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }

    
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Первая и вторая песня одинаковые.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песня разные.");
            }

        }
        static void Task7()
        {
            Queue<Resident> residentsQueue = new Queue<Resident>();
            Console.WriteLine("Сколько жителей в очереди к Зине?");

            int n;
            while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            {
                Console.WriteLine("Некорректный ввод. Введите положительное целое число:");
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Введите данные для жителя {i + 1} (Имя, Проблема, Степень скандальности, Ум):");
                Console.Write("Имя: ");
                string name = Console.ReadLine();

                Console.Write("Введите проблему (например: 'отопление не работает', 'задолженность', 'сломался кран'): ");
                string problemDescription = Console.ReadLine();

                Console.Write("Степень скандальности (0-10): ");
                int scandalLevel;
                while (!int.TryParse(Console.ReadLine(), out scandalLevel) || scandalLevel < 0 || scandalLevel > 10)
                {
                    Console.WriteLine("Некорректный ввод. Введите число от 0 до 10:");
                }

                Console.Write("Ум (1 - умный, 0 - тупой): ");
                int smartness;
                while (!int.TryParse(Console.ReadLine(), out smartness) || (smartness != 0 && smartness != 1))
                {
                    Console.WriteLine("Некорректный ввод. Введите 1 для умного или 0 для тупого:");
                }

                Problem problem = DefineProblem(problemDescription);
                Resident resident = new Resident(name, problem, scandalLevel, smartness);
                residentsQueue.Enqueue(resident);
            }

            // Обработка очереди
            List<Resident>[] windows = new List<Resident>[3]
            {
            new List<Resident>(),
            new List<Resident>(),
            new List<Resident>()
            };

            while (residentsQueue.Any())
            {
                Resident resident = residentsQueue.Dequeue();
                Console.WriteLine($"Обрабатываем жителя: {resident.Name} ({resident.PassportNumber})");
                int window = 2; // По умолчанию - третье окно

                if (resident.Smartness == 1)
                {
                    window = resident.Problem.Number;
                }
                else
                {
                    Random random = new Random();
                    window = random.Next(0, 3); // Случайный выбор окна
                }

                if (resident.ScandalLevel >= 5)
                {
                    Console.WriteLine($"{resident.Name} - скандалист. Сколько людей он хочет обогнать?");
                    int skip;
                    while (!int.TryParse(Console.ReadLine(), out skip) || skip < 0)
                    {
                        Console.WriteLine("Некорректный ввод. Введите неотрицательное число:");
                    }

                    int position = Math.Max(0, windows[window].Count - skip);
                    if (position > windows[window].Count)
                    {
                        position = windows[window].Count;
                    }
                    windows[window].Insert(position, resident);
                }
                else
                {
                    windows[window].Add(resident);
                }
            }

            // Вывод очередей по окнам
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Очередь в окно {i + 1}:");
                foreach (var r in windows[i])
                {
                    Console.WriteLine($"Имя: {r.Name}, Номер паспорта: {r.PassportNumber}, Проблема: {r.Problem.Description}, Степень скандальности: {r.ScandalLevel}, Ум: {r.Smartness}");
                }
            }
        }

        static Problem DefineProblem(string description)
        {
            if (description.ToLower().Contains("отопление"))
                return new Problem(0, description);
            if (description.ToLower().Contains("оплата"))
                return new Problem(1, description);
            return new Problem(2, description);
        }
        public static void CheckIfIFormattable(object value)
        {
            Console.WriteLine($"Проверяем значение: {value}");

      
            if (value is IFormattable)
            {
                Console.WriteLine("Значение реализует интерфейс IFormattable (проверено через 'is').");
            }
            else
            {
                Console.WriteLine("Значение НЕ реализует интерфейс IFormattable (проверено через 'is').");
            }

   
            var formattableValue = value as IFormattable;
            if (formattableValue != null)
            {
                Console.WriteLine("Значение реализует интерфейс IFormattable (проверено через 'as').");

        
                Console.WriteLine("Пример форматирования: " + formattableValue.ToString(null, System.Globalization.CultureInfo.InvariantCulture));
            }
            else
            {
                Console.WriteLine("Значение НЕ реализует интерфейс IFormattable (проверено через 'as').");
            }

            Console.WriteLine();
        }
        static string ReverseString(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "Введенная строка пуста или null.";
            }

            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray); 
            return new string(charArray);
        }
        
    }
}
