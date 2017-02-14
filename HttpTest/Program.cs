using System;
using System.Collections.Generic;
using System.Web;  //默认是需要添加引用的


namespace HttpTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string body = "互联盛业订单";
            
            string body2 = HttpUtility.UrlEncode(body);


            string body3 = HttpUtility.UrlDecode(body2);


            List<int> payTyps1 = new List<int> { 0, 1, 2, 5 };


            Console.ReadKey();
        }
    }
}
