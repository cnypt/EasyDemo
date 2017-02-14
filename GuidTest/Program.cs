using System;
using System.Collections.Generic;
using System.Linq;

namespace GuidTest
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Guid UserID = new Guid();
            Guid UserID = new Guid();
            if (UserID.ToString() == "00000000-0000-0000-0000-000000000000")
            {

                UserID = Guid.NewGuid();
                Console.WriteLine("为空");
            }
            else
            {
                Console.WriteLine("不为空");
            }
            #endregion

            #region Guid字符串转换成一个个的Guid
            //Guid univer = new Guid();
            //string guids = "7B8110CC-2447-45BA-9583-22D9D70D827F,B4E012C2-28E8-4ABD-8EBA-0A7E98E0E5B9,3D637FC4-97E3-4D9E-9BC5-A69A2588AB7C";

            //string[] guidArr = guids.Split(',');
            //for (int i = 0; i < guidArr.Length; i++)
            //{
            //    univer = new Guid(guidArr[i]);
            //    Console.WriteLine(univer);
            //}
            #endregion

            #region List〈string〉和string[]数组之间的相互转换
            string guids = "7B8110CC-2447-45BA-9583-22D9D70D827F,B4E012C2-28E8-4ABD-8EBA-0A7E98E0E5B9,3D637FC4-97E3-4D9E-9BC5-A69A2588AB7C";
            string[] guidArr = guids.Split(',');
            List<string> guidList = new List<string>(guidArr);
            foreach (string item in guidList)
            {
                Console.WriteLine(item);
            }

            //将string字符串转换成 Guid[] 的数组
            //方法1.
            var listGuid = guidArr.Select(g => Guid.Parse(g)).ToArray();
            foreach (Guid item in listGuid)
            {
                Console.WriteLine(item);
            }
            //方法2.
            var guidArray = Array.ConvertAll(guidArr, (string x) => { return new Guid(x); });
            foreach (Guid item in guidArray)
            {
                Console.WriteLine(item);
            }

            List<string> listS = new List<String>();
            listS.Add("str");
            listS.Add("hello");
            string[] str = listS.ToArray();
            #endregion



            Console.ReadKey();
        }
    }
}
