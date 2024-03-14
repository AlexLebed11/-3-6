using System;
using System.Diagnostics;
using System.Threading;


//namespace l_3_1
//{

//    class Program
//    {
//        static object lockOn = new object();
//        static public void Run()
//        {
//            Console.WriteLine("Новий потiк запущено.");

//            lock (lockOn)
//            {
//                Console.Write("Пiдрахунок: ");
//                for (int i = 0; i <= 10; i++)
//                {
//                    Console.Write(i + " ");
//                    Thread.Sleep(200);
//                }
//                Console.WriteLine();
//            }
//        }
//        static void Main(string[] args)
//        {
//            Thread newThrd = new Thread(Run);
//            Thread newThrd1 = new Thread(Run);
//            newThrd.Start();
//            newThrd1.Start();
//            newThrd.Join();
//            newThrd1.Join();
//            Console.ReadKey();
//        }
//    }
//}



//namespace l_3_2
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Дочiрнiй процес.");
//            for (int j = 10; j <= 20; j++)
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Console.Write(j + " ");
//                    Thread.Sleep(100);
//                }
//                Console.WriteLine();
//            }
//            Console.ReadKey();
//        }
//    }
//}

//namespace l_3_2_p
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Батькiвський процес.");
//            string appName =
//           @"C:\Users\root\source\repos\csstation\csstation\bin\Debug\net6.0\csstation.exe";
//            Process newProc = new Process();
//            newProc.StartInfo.FileName = appName;
//            newProc.Start();
//            for (int j = 0; j < 10; ++j)
//            {
//                for (int i = 0; i < 10; i++)
//                {
//                    Console.Write(j + " ");
//                    Thread.Sleep(100);
//                }
//                Console.WriteLine();
//            }
//            Console.ReadKey();
//        }
//    }
//}


//namespace l_3_2_1
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Дочiрнiй процес.");
//            if (args.Length < 1)
//            {
//                Console.WriteLine("No arguments.");
//                Console.ReadKey();
//                return;
//            }
//            string mtxName = args[0];
//            bool init = false;
//            Mutex newMutex = new Mutex(init, mtxName);
//            for (int j = 10; j <= 20; j++)
//            {
//                newMutex.WaitOne();
//                for (int i = 0; i < 10; i++)
//                {
//                    Console.Write(j + " ");
//                    Thread.Sleep(100);
//                }
//                Console.WriteLine();
//                newMutex.ReleaseMutex();
//                Thread.Sleep(10);
//            }
//            Console.ReadKey();
//        }
//    }
//}


//namespace l_3_2_1_p
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Батькiвський процес.");
//            bool initOwn = false;
//            string mtxName = "MyMutex";
//            string appName = @"C:\Users\root\source\repos\csstation\csstation\bin\Debug\net6.0\csstation.exe";
//            Mutex newMutex = new Mutex(initOwn, mtxName);
//            Process newProc = new Process();
//            newProc.StartInfo.FileName = appName;
//            newProc.StartInfo.Arguments = mtxName;
//            newProc.Start();
//            for (int j = 0; j < 10; ++j)
//            {
//                newMutex.WaitOne();
//                for (int i = 0; i < 10; i++)
//                {
//                    Console.Write(j + " ");
//                    Thread.Sleep(100);
//                }
//                Console.WriteLine();
//                newMutex.ReleaseMutex();
//                Thread.Sleep(10);
//            }
//            Console.ReadKey();
//        }
//    }
//}



//namespace l_3_3
//{
//    class Program
//    {
//        static AutoResetEvent newEvnt = new AutoResetEvent(false);
//        static void Run()
//        {
//            Console.WriteLine("Дочiрний потiк з використанням подiй з автоматичним скиданням.");
//        for (int i = 0; i <= 10; i++)
//            {
//                Console.Write(i + " ");
//                if (i == 4)
//                {
//                    newEvnt.Set();
//                    Thread.Sleep(100);
//                    newEvnt.WaitOne();
//                    Console.WriteLine();
//                }
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Головний потiк.");

//            Thread newThrd = new Thread(Run);
//            newThrd.Start();
//            newEvnt.WaitOne();
//            Console.WriteLine("\nПоловина роботi виконана.");

//            Console.WriteLine("Натиснiть будь-яку клавiшу, щоб продовжити.");
//            Console.ReadKey();

//            newEvnt.Set();
//            newThrd.Join();
//            Console.ReadKey();
//        }
//    }
//}

//namespace l_3_4
//{
//    class Program
//    {
//        static ManualResetEvent newEvnt = new ManualResetEvent(false);
//        static void Run()
//        {
//            Console.WriteLine("Дочiрний потiк з використанням подiй з ручним скиданням.");
//            for (int i = 0; i <= 10; i++)
//            {
//                Console.Write(i + " ");
//                if (i == 4)
//                {
//                    newEvnt.Set();
//                    Thread.Sleep(100);
//                    newEvnt.WaitOne();
//                    Console.WriteLine();
//                }
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Головний потiк.");

//            Thread newThrd = new Thread(Run);
//            newThrd.Start();
//            newEvnt.WaitOne();
//            newEvnt.Reset();
//            Console.WriteLine("\nПоловина роботi виконана.");
//            Console.WriteLine("Натиснiть будь-яку клавiшу, щоб продовжити.");

//            Console.ReadKey();

//            newEvnt.Set();

//            newThrd.Join();
//            Console.ReadKey();
//        }
//    }
//}

//namespace l_3_5
//{
//    class Program
//    {
//        static int[] arr = new int[10];
//        static void Run()
//        {
//            for (int i = 0; i < 10; i++)
//            {
//                arr[i] = i + 1;
//                Thread.Sleep(70);
//            }
//        }
//        static void Main(string[] args)
//        {
//            Console.Write("An initial state of the array: ");
//            for (int i = 0; i < 10; i++)
//                Console.Write(arr[i] + " ");
//            Console.WriteLine();
//            Thread newThrd = new Thread(Run);
//            newThrd.Start();
//            Console.Write("A modified state of the array: ");
//            for (int i = 0; i < 10; i++)
//            {
//                Console.Write(arr[i] + " ");
//                Thread.Sleep(70);
//            }
//            Console.WriteLine();
//            newThrd.Join();
//            Console.ReadKey();
//        }
//    }
//}



namespace l_3_5_1
{
    class Program
    {
        static Semaphore newSem = new Semaphore(0, 1);
        static int[] arr = new int[10];
        static void Run()
        {
            for (int i = 0; i < 10; i++)
            {
                arr[i] = i + 1;
                newSem.Release();
                Thread.Sleep(500);
            }
        }
        static void Main(string[] args)
        {
            Console.Write("An initial state of the array: ");
            for (int i = 0; i < 10; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
            Thread newThrd = new Thread(Run);
            newThrd.Start();
            Console.Write("A modified state of the array: ");
            for (int i = 0; i < 10; i++)
            {
                newSem.WaitOne();
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
            newThrd.Join();
            Console.ReadKey();
        }
    }
}