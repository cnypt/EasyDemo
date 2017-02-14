using System;

namespace Return用法
{
    class Program
    {
        public static int result = 0;
        static void Main(string[] args)
        {
            Console.WriteLine(result);
            Submit(1);
            Console.WriteLine(result);
            Console.ReadKey();
        }

        public static void Submit(int i)
        {
            if (i == 1)
            {
                result = 10;
                return;
            }
            result = 20;
        }

    }
}
