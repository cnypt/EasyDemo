using System;
using System.Collections.Generic;

namespace 根据营业时间计算配送时间
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = Convert.ToDateTime("13:00:00").AddMinutes(30);  //营业开始时间         12:30
            DateTime endTime = Convert.ToDateTime("19:30:00");                //营业结束时间         14:00

            DateTime immediatelyTime = DateTime.Now.AddMinutes(30);   //立即送达时间                12:33

            List<string> sr = GetTimeList(startTime, endTime, immediatelyTime);

            foreach (string item in sr)
            {
                if (sr[0] == item)
                {

                }
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 根据营业开始时间，结束时间，立即送达时间。返回配送时间段
        /// </summary>
        /// <param name="startTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="immediatelyTime">立即送达时间</param>
        /// <returns>配送时间集合</returns>
        static private List<string> GetTimeList(DateTime startTime, DateTime endTime, DateTime immediatelyTime)
        {
            List<string> lsResult = new List<string>();
            List<DateTime> list = new List<DateTime>();
            int imH = immediatelyTime.Hour;                        //立即送达小时数
            int imM = immediatelyTime.Minute;                      //立即送达的分钟数

            //如果立即送达时间在开始时间跟结束时间之内
            if (startTime <= immediatelyTime && immediatelyTime <= endTime)
            {
                int iH = immediatelyTime.Hour;
                int iM = immediatelyTime.Minute;
                if (0 < iM && iM < 30)
                {
                    startTime = Convert.ToDateTime(iH + ":30");
                }
                else if (30 < iM && iM <= 59)
                {
                    startTime = Convert.ToDateTime(iH + 1 + ":00");
                }
                list.Add(immediatelyTime);
                while (startTime <= endTime)
                {
                    list.Add(startTime);
                    startTime = startTime.AddMinutes(30);
                }
            }
            //如果立即送达时间小于开始时间
            else if (immediatelyTime < startTime)
            {

                int iH = startTime.Hour;
                int iM = startTime.Minute;
                if (0 < iM && iM < 30)
                {
                    startTime = Convert.ToDateTime(iH + ":30");
                }
                else if (30 < iM && iM <= 59)
                {
                    startTime = Convert.ToDateTime(iH + 1 + ":00");
                }

                while (startTime <= endTime)
                {
                    list.Add(startTime);
                    startTime = startTime.AddMinutes(30);
                }
            }
            //如果立即送达时间大于结束时间
            else if (immediatelyTime > endTime)
            {

            }
            if (list.Count > 0)
            {
                foreach (DateTime item in list)
                {
                    lsResult.Add(item.ToString("HH:mm"));
                }
            }
            return lsResult;
        }
    }
}
