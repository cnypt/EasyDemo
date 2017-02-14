using System;

namespace Get周月日的第一天
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;  //当前时间  

            DateTime dtt = Convert.ToDateTime(dt.ToShortDateString());

            DateTime startWeek = dtt.AddDays(1 - Convert.ToInt32(dtt.DayOfWeek.ToString("d")));  //本周周一  
            DateTime endWeek = startWeek.AddDays(6);  //本周周日  
            DateTime lastEndWeek = dtt.AddDays(0 - Convert.ToInt32(dtt.DayOfWeek.ToString("d"))); //上周周末
            DateTime nextStartWeek = endWeek.AddDays(1);         //下周周一

            DateTime startMonth = dtt.AddDays(1 - dtt.Day);  //本月月初  
            DateTime endMonth = startMonth.AddMonths(1).AddDays(-1);  //本月月末  
            //DateTime endMonth = startMonth.AddDays((dtt.AddMonths(1) - dtt).Days - 1);  //本月月末  

            DateTime startQuarter = dtt.AddMonths(0 - (dtt.Month - 1) % 3).AddDays(1 - dtt.Day);  //本季度初  
            DateTime endQuarter = startQuarter.AddMonths(3).AddDays(-1);  //本季度末  

            DateTime startYear = new DateTime(dtt.Year, 1, 1);  //本年年初  
            DateTime endYear = new DateTime(dtt.Year, 12, 31);  //本年年末  


            Console.WriteLine("当前时间为：" + dtt.ToString());
            Console.WriteLine(dtt.DayOfWeek);
            Console.WriteLine(dtt.AddDays(1 - Convert.ToInt32(dtt.DayOfWeek.ToString("d"))));


            int year = 2016;
            int month = 12;

            DateTime sssss = Convert.ToDateTime(year + "-" + month);
            DateTime xxxx = sssss.AddMonths(1);

            Console.ReadKey();
        }
    }
}
