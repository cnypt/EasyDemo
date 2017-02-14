using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string操作
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 字符串补0操作。
            //string te = "0010010";
            //int i = 10;

            //Console.WriteLine(te.Substring(te.Length - 3, 3));

            //Console.WriteLine(Convert.ToInt32(te));

            ////补0操作
            //Console.WriteLine(i.ToString().PadLeft(5, '0'));//推荐
            #endregion

            #region 字符串截取操作。
            List<int> result = new List<int>();
            //string success_details = "001^18560530895^杨鹏涛^0.10^S^^201608260112884932^20160826113334|001^18560530895^杨鹏涛^0.10^S^^201608260112884932^20160826113334|001^18560530895^杨鹏涛^0.10^S^^201608260112884932^20160826113334|001^18560530895^杨鹏涛^0.10^S^^201608260112884932^20160826113334|";
            string success_details = "";

            string[] sArrayDetails = success_details.Split('|');
            foreach (string item in sArrayDetails)
            {
                string id = item.Split('^')[0];
                if (!string.IsNullOrEmpty(id))
                {
                    result.Add(int.Parse(id));
                }
            }

            foreach (int item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Result的长度" + result.Count + "到此为止。");

            #endregion

            Console.ReadKey();
        }
    }
}
