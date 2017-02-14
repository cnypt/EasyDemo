using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 判空与TryParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "1";
            string s1 = null;
            int isUsedcoupon = 0;

            if (!string.IsNullOrEmpty(s1))
            {
                Console.WriteLine(s1.ToString());
            }
            int.TryParse(s, out isUsedcoupon);

            Console.WriteLine(isUsedcoupon);


            int isUsedcoupon2 = 0;
            int.TryParse(s1.ToString(), out isUsedcoupon2);

            Console.WriteLine(isUsedcoupon2);


            int? temp = null;
            if (temp == 0 || temp == 1)
            {
                Console.WriteLine("temp不为空");
            }
            else
            {
                Console.WriteLine("temp为空。");
            }

            Console.ReadKey();
        }
    }
}
