using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections.Generic;

namespace lab6_mutex
{
    class Program
    {
        static string Generate_string(int m, string alphabet = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz") //функция генерирования случайной строки
        {
            char[] chars = new char[m];
            Random rand = new Random();
            for (int i = 0; i < m; i++)
            {
                chars[i] = alphabet[rand.Next(0, alphabet.Length)];
            }
            return new string(chars);
        }

        static void Write_file(Object x) //функция создания файла и записи в него строк
        {
            Console.WriteLine($"Генерирование файла {x}...");
            string path = $@"D:\Desktop\lab6_mutex\{x}.txt";
            StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default);
            for (int i = 0; i < 100000; i++)
            {
                sw.WriteLine($"{x} : {Generate_string(15)}");
            }
            sw.Close();
            Console.WriteLine($"Файл {x} сгенерирован");
        }

        static void Write_to_res(Object x) //функция записи в итоговый файл
        {
            string path = $@"D:\Desktop\lab6_mutex\{x}.txt";
            Console.WriteLine($"Чтение файла {x}...");
            StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
            StreamWriter sw1 = new StreamWriter(@"D:\Desktop\lab6_mutex\result.txt", true, System.Text.Encoding.Default);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                sw1.WriteLine(line);
            }
            sw1.Close();
            sr.Close();
            Console.WriteLine($"Файл {x} записан в итоговый файл");
        }

        static void Main(string[] args)
        {
            int x = Convert.ToInt32(args[0]); //при вызове приложения передаем в него имя файла (порядковый номер) в качестве аргумента
            _Mutex mutex = new _Mutex(); //создаем объект мьютекса
            if (mutex.Wait()) //если мьютекс "занят"
            {
                try
                {
                    Write_file(x); //создаем файлы и записываем в них строки
                    Write_to_res(x); //записываем содержимое всех файлов в итоговый
                }
                finally
                {
                    mutex.Release(); //освобождаем мьютекс
                }
            }
        }
    }
}