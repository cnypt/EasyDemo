using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 随机验证码
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = GetNonce(4);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GetNonce(4));
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 生成i位的验证码
        /// </summary>
        /// <param name="len"></param>
        /// <returns></returns>
        private static string GetNonce(int len)
        {
            char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            System.Text.StringBuilder nonce_str_temp = new System.Text.StringBuilder(32);
            Random rd = new Random();
            for (int i = 0; i < len; i++)
            {
                nonce_str_temp.Append(arr[rd.Next(10)]);
            }
            return nonce_str_temp.ToString();
        }
    }
}
