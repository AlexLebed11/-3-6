using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;
using System.Collections.Generic;

namespace l_3_2_1_p
{
    class Program
    {

        static object lockOn = new object(); 
        static public void Run()
        {
            //lock (lockOn)
            //{
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Дочiрнiй процес.");
                for (int j = 10; j <= 12; j++)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(j + " ");
                        Thread.Sleep(100);
                    }
                    Console.WriteLine();
                }
            //}
        }

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();
            int num = 0;

            num = Int32.Parse(Console.ReadLine()!);


            for (int i = 0; i < num; i++)
            {
                Thread thread = new Thread(new ThreadStart(() => Run())) ;

                threads.Add(thread);
            }

            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }
        }
    }
}