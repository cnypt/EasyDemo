using System;
using System.Security.Cryptography;
using System.Text;

namespace MD5_生成签名
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp = "Do You Know?";
            string tt = MakeSign(temp);

            Console.ReadKey();
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="stringSignTemp"></param>
        /// <returns></returns>
        private static string MakeSign(string stringSignTemp)
        {
            //MD5加密
            var md5 = MD5.Create();
            var bs = md5.ComputeHash(Encoding.UTF8.GetBytes(stringSignTemp));
            var sb = new StringBuilder();
            foreach (byte b in bs)
            {
                sb.Append(b.ToString("x2"));
            }
            //转换为16进制时，左边补齐0的方法 
            //int i = 2; 
            //i.ToString("x2"); 02

            //所有字符转为大写
            return sb.ToString().ToUpper();
        }
    }
}
