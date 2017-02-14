using System;

namespace string数组到int数组
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = { };
            int[] output = Array.ConvertAll<string, int>(input, delegate (string s) { return int.Parse(s); });

            foreach (var item in input)
            {
                Console.WriteLine(item);
            }


            foreach (var item in output)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
