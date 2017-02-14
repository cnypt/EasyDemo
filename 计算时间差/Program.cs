using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 计算时间差
{
    class Program
    {
        static void Main(string[] args)
        {
            string dateDiff = null;
            string s1 = "2016/5/22 10:22:38";
            string s2 = "2016/5/22 11:22:38";
            DateTime dt1 = Convert.ToDateTime(s1);
            DateTime dt2 = Convert.ToDateTime(s2);

            TimeSpan ts1 = new TimeSpan(dt1.Ticks);
            TimeSpan ts2 = new TimeSpan(dt2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();

            dateDiff = ts.Days.ToString() + "天" + ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";

            //相差的总秒数
            Console.WriteLine("相差的总秒数：" + ts.TotalSeconds.ToString());
            System.Console.WriteLine(ts.TotalMilliseconds);

            Console.WriteLine("相差的时间：" + dateDiff);

            Console.WriteLine("相差的分钟数为：" + ts.TotalMinutes);

            Console.WriteLine(DateTime.Now.ToString("yyyyMMdd"));

            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmss"));

            Console.WriteLine(DateTime.Now.ToString());

            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine(DateTime.Now.ToString("HHmmss"));

            #region 取1970年至今的秒数
            DateTime dtn = DateTime.UtcNow;
            int sss1 = (int)DateTime.UtcNow.Subtract(DateTime.Parse("1970-1-1")).TotalSeconds;


            DateTime dt = DateTime.Parse("01/01/1970 ");
            TimeSpan ts222 = dtn - dt;
            int sec = (int)ts222.TotalSeconds; // 秒数


            Console.WriteLine(string.Format("秒数1为{0}  秒数二为{1} ", sss1, sec));
            #endregion


            Console.ReadKey();
        }
    }
}
