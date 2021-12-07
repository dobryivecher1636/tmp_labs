using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;


namespace lab5_threads
{
    class Program
    {
        static object block = new object();
        static string Generate_string(int m, string alphabet = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz")
        {
            char[] chars = new char[m];
            Random rand = new Random();
            for (int i = 0; i < m; i++)
            {
                chars[i] = alphabet[rand.Next(0, alphabet.Length)];
            }
            return new string(chars);
        }

        static void Write_file(object argument)
        {
            Console.WriteLine("Поток генерирования файла запущен");
            WriteClass wc = argument as WriteClass;
            lock (block)
            {
                Console.WriteLine($"Генерирование файла {wc.i}...");
                string path = $@"D:\Desktop\lab5_threads\{wc.i}.txt";
                StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default);
                for (int i = 0; i < 100000; i++)
                {
                    sw.WriteLine($"{wc.i} : {Generate_string(wc.m)}");
                }
                sw.Close();
                Console.WriteLine($"Файл {wc.i} сгенерирован");
            }
            wc.i++;
        }

        static void Write_to_res(object argument)
        {
            Console.WriteLine("Поток записи в итоговый файл запущен");
            WriteClass wc = argument as WriteClass;
            lock (block)
            {
                string path = $@"D:\Desktop\lab5_threads\{wc.i}.txt";
                Console.WriteLine($"Чтение файла {wc.i}...");
                StreamReader sr = new StreamReader(path, System.Text.Encoding.Default);
                StreamWriter sw1 = new StreamWriter(@"D:\Desktop\lab5_threads\result.txt", true, System.Text.Encoding.Default);
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    sw1.WriteLine(line);
                }
                sw1.Close();
                sr.Close();
                Console.WriteLine($"Файл {wc.i} записан в итоговый файл");
            }
            wc.i++;
        }
        static void Main(string[] args)
        {
            WriteClass writeclass1 = new WriteClass();
            writeclass1.m = 15;
            writeclass1.n = 10;
            writeclass1.i = 1;
            ParameterizedThreadStart write_file = new ParameterizedThreadStart(Write_file);
            for (int i = 0; i < writeclass1.n; i++)
                new Thread(write_file).Start(writeclass1);

            WriteClass writeclass2 = new WriteClass();
            writeclass2.i = 1;
            ParameterizedThreadStart write_to_res = new ParameterizedThreadStart(Write_to_res);
            for (int i = 0; i < writeclass1.n; i++)
                    new Thread(write_to_res).Start(writeclass2);
        }
    }
}