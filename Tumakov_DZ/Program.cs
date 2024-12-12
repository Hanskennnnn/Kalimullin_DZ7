﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;


namespace Tumakov_DZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task3();
            //Task4();
            //Task5();
            //Task6();
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
            Console.WriteLine("\nУпражнение 8.3\n");

            Console.WriteLine("Введите название файла (1.txt умолчанию)");
            string name = Console.ReadLine();
            if (String.IsNullOrEmpty(name))
            {
                name = "1.txt";
            }
            string filePath = $"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\{name}";
            if (File.Exists(filePath))
            {
                string readContent = File.ReadAllText(filePath);

                File.WriteAllText($"{Directory.GetCurrentDirectory()}..\\..\\..\\..\\resourses\\2.txt", GetUpper(readContent));

                Console.WriteLine("Выходные данные записаны в файл resourses/2.txt");
            }
            else
            {
                Console.WriteLine("Файла с таким именем нет");
            }
        }

        /// <summary>
        /// Переводит строку в uppercase и возвращает её.
        /// </summary>
        /// <returns>Строка string</returns>
        static string GetUpper(string str)
        {
            string retStr = String.Empty;
            foreach (char c in str)
            {
                retStr += c.ToString().ToUpper();
            }
            return retStr;
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
            // Создаем список песен
            List<Song> songs = new List<Song>
        {
            new Song(),
            new Song(),
            new Song(),
            new Song()
        };

            // Заполняем информацию о песнях
            songs[0].SetName("Song 1");
            songs[0].SetAuthor("Author 1");
            songs[1].SetName("Song 2");
            songs[1].SetAuthor("Author 2");
            songs[2].SetName("Song 3");
            songs[2].SetAuthor("Author 3");
            songs[3].SetName("Song 4");
            songs[3].SetAuthor("Author 4");

            // Создаем связи prev между песнями
            for (int i = 1; i < songs.Count; i++)
            {
                songs[i].SetPrev(songs[i - 1]);
            }

            // Выводим информацию о песнях
            foreach (var song in songs)
            {
                Console.WriteLine(song.Title());
            }

            // Сравниваем первую и вторую песню
            if (songs[0].Equals(songs[1]))
            {
                Console.WriteLine("Первая и вторая песня одинаковые.");
            }
            else
            {
                Console.WriteLine("Первая и вторая песня разные.");
            }

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
