using System;
using System.Collections.Generic;

namespace 时间段转换成时间
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime currentTime = DateTime.Now;
            DateTime paytime = currentTime.AddHours(-1.5);

            TimeSpan ts = currentTime - paytime;

            int min = ts.Minutes;
            int hour = ts.Hours;

            string tt = "23:00";

            DateTime ss = Convert.ToDateTime(tt);

            #region 时间段转换成时间
            string Timeperiod = "19：00-19:30";
            Timeperiod = Timeperiod.Replace('：', ':');
            string[] arrTimePeriod = Timeperiod.Split('-');
            string ds = DateTime.Now.ToShortDateString();

            DateTime dts = Convert.ToDateTime(ds + " " + arrTimePeriod[0]);
            #endregion

            #region 时间段分隔
            //比如说 

            DateTime dt = DateTime.Parse("00:00:00");

            DateTime dt0 = dt.AddMinutes(10); //dt2即为00:10:00 

            //当然如果需要你也可以把所有的时间都存下来，比如 

            DateTime dt1 = DateTime.Parse("08:00:00");

            DateTime dt2 = DateTime.Parse("15:00:00");

            DateTime fafadf = Convert.ToDateTime("23:00:00");

            List<DateTime> list = new List<DateTime>();

            while (dt1 <= dt2)
            {

                list.Add(dt1);

                dt1 = dt1.AddMinutes(10);

            }
            List<string> ls = new List<string>();
            foreach (DateTime item in list)
            {
                //  Console.WriteLine(item);
                Console.WriteLine(item.ToString("HH:mm"));
                ls.Add(item.ToString("HH:mm"));
            }

            #endregion


            #region TimeSpan
            TimeSpan StartTime = TimeSpan.MinValue;
            TimeSpan.TryParse("07:30:00.0000000", out StartTime);

            TimeSpan EndTime = TimeSpan.MinValue;
            TimeSpan.TryParse("22:30:00.0000000", out EndTime);


            string sdt = StartTime.ToString();
            DateTime ddt = Convert.ToDateTime(sdt);
            #endregion
            string aa = "2010-09-02T10:00:00";
            object bb = toObject(aa);

            Console.ReadKey();
        }

        private static object toObject(object o)
        {
            if (o.GetType() == typeof(string))
            {
                //判断是否符合2010-09-02T10:00:00的格式
                string s = o.ToString();
                if (s.Length == 19 && s[10] == 'T' && s[4] == '-' && s[13] == ':')
                {
                    o = System.Convert.ToDateTime(o);
                }
            }
            return o;
        }
    }
}

