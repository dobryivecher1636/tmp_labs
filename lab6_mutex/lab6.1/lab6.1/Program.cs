using System.Runtime.InteropServices;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace lab6._1
{
    class Program
    {
        static void Main(string[] args)
        {
            _Mutex mutex = new _Mutex(); //создаем объект мьютекса
            int n = 11; //кол-во процессов (11-1)
            Process[] proccess = new Process[n]; 
            for (int i = 1; i < n; i++)
                proccess[i] = Process.Start(@"D:\Desktop\lab6_mutex\lab6_mutex\bin\Debug\netcoreapp3.1\lab6_mutex.exe", Convert.ToString(i)); //создаем процесс приложения с мьютексом и передаем туда название файла
            for (int i = 1; i < n; i++)
                proccess[i].WaitForExit(); //блокируем выполнение процесса до того, как выполнится предыдущий
            mutex.Release(); //освобождаем мьютекс
        }
    }
}
