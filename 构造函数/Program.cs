using System;

namespace 构造函数
{
    class Program
    {
        static void Main(string[] args)
        {
            Taxi t = new Taxi();
            Console.WriteLine(t.isInitialized);
            Console.ReadKey();
        }
    }

    public class Taxi
    {
        public bool isInitialized;
        public Taxi()
        {
            isInitialized = true;
        }
    }
}
