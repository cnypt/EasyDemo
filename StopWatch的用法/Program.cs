using System;
using System.Diagnostics;

namespace StopWatch的用法
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < 1000000000; i++)
            {

            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            long w = sw.ElapsedTicks;

            sw.Restart();
            Console.ReadKey();
        }
    }
}
