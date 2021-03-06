﻿using System;
using System.Collections.Generic;
using HelperClass;

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

            #region woqun
            //int i = 4;

            //string str = "123456";

            //string strL = str.Substring(i);

            ////从左边截取 i 个字符
            //string strLeft = str.Substring(0, i);
            ////从右边截取 i 个字符
            //string strRight = str.Substring(str.Length - i, i);

            //for (int a = 522; a < 524; a++)
            //{
            //    Random rd = new Random();
            //    int num = rd.Next(100000, 1000000);
            //    int num2 = rd.Next(100000, 1000000);
            //    string dnum = num.ToString() + num2.ToString() + a.ToString();
            //    Console.WriteLine(dnum.Remove(0, dnum.Length - 12));
            //}
            #endregion

            #region 生成随机数
            //char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            //System.Text.StringBuilder nonce_str_temp = new System.Text.StringBuilder(32);

            //Random rd = new Random();
            //for (int i = 0; i < 9; i++)
            //{
            //    nonce_str_temp.Append(arr[rd.Next(10)]);
            //}

            //Console.WriteLine(nonce_str_temp.ToString());
            #endregion

            #region 将字符串转换成int数组的格式。
            string serviceids = "1,232,3231,214";

            int[] arrIds = Array.ConvertAll<string, int>(serviceids.Split(','), delegate (string s) { return int.Parse(s); });

            for (int i = 0; i < arrIds.Length; i++)
            {
                Console.WriteLine(arrIds[i]);
            }
            #endregion

            #region 人民币转换
            string inputnum = Console.ReadLine();

            Console.WriteLine(inputnum + "  转换成汉字后  " + Helper.RMBConvert(inputnum));
            #endregion


            Console.ReadKey();
        }
    }
}
