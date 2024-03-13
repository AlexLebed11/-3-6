using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Channels;

class Program 
{

    static void Main(string[] args)
    {
        int num = 0;

        num = Int32.Parse(Console.ReadLine()!);

        Process newProc = new Process();
        newProc.StartInfo.FileName =
       @"C:\Users\root\source\repos\l_2_2\l_2_2\bin\Debug\net6.0\l_2_2.exe";
        
        newProc.StartInfo.UseShellExecute = true;

        while (num != 0)
        {
            newProc.Start();
            Console.WriteLine("Новий процес створений.\n");
            newProc.Close();
            Console.WriteLine("Новий процес закiнчений.\n");

            num--;
        }
    }

}
