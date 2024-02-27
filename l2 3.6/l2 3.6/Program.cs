using System;
using System.Threading;
namespace l1_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread myThread = new Thread(new ParameterizedThreadStart(Count!));
            myThread.Start(); // передаємо змінну у новий потік 

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("Потiк 1 \tTime: " + DateTime.Now);
                Thread.Sleep(300);
            }
            Console.ReadLine();
        }
        public static void Count(object x)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine("\tПотiк 2 \t Time:" + DateTime.Now);
                Thread.Sleep(400);
            }
        }
    }
}
