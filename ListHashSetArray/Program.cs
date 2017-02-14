using System;
using System.Collections.Generic;
using System.Linq;

namespace ListHashSetArray
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> li1 = new List<string> { "8", "8", "9", "9", "0", "9" };
            List<string> li2 = new List<string> { "张三", "张三", "李四", "张三", "王五", "李四" };
            List<string> li3 = new List<string> { "A", "A", "C", "A", "C", "D" };
            List<string> li4 = new List<string> { "12", "18", "19", "19", "10", "19" };

            HashSet<string> hs = new HashSet<string>(li1); //此时已经去掉重复的数据保存在hashset中

            List<string> li5 = new List<string>(hs);

            int[] array1 = new int[] { 1, 3, 5, 7, 7, 1, 3, 9 };

            int[] array2 = array1.Distinct().ToArray();

            Console.ReadKey();
        }
    }
}
