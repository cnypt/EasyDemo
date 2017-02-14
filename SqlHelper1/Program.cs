using System;
using System.Collections;
using System.Configuration;
using System.Data;

namespace SqlHelper1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ss = ConfigurationManager.AppSettings["conStr"];

            string fa = ConfigurationManager.ConnectionStrings["conStr"].ToString();

            string sql = "", storedProcName = "";
            DateTime searchBeginDate = Convert.ToDateTime("2016-06-29");
            DateTime searchEndDate = Convert.ToDateTime("2016-06-30");
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            double days = 0.0;

            ArrayList myArray = new ArrayList();
            if ((startDate <= searchBeginDate && searchEndDate < endDate) || (searchBeginDate <= startDate && searchEndDate < endDate) || (startDate <= searchBeginDate && endDate <= searchEndDate) || (searchBeginDate <= startDate && endDate < searchEndDate))
            {

            }

            // string sql2 = string.Format("select TravelID,TravelTheme,ApplyUserID,ApplyUserName,ApplyDateNum,ApplyDate,StartDate,EndDate,ApprovalStatus from HR_AttenceBussinessTravel where IsDeleted <> 1 and (startDate <='{0}' and '{1}' < endDate) or ('{0}' <=startDate and '{1}' < endDate) or (startDate<='{0}' and endDate <='{1}') or ('{0}'<=startDate and endDate <'{1}')", searchBeginDate, searchEndDate);


            // sql = string.Format("select TravelID,TravelTheme,ApplyUserID,ApplyUserName,ApplyDateNum,ApplyDate,StartDate,EndDate,ApprovalStatus from HR_AttenceBussinessTravel where IsDeleted <> 1 and (StartDate >= '{0}' and StartDate < '{1}' or EndDate >= '{0}' and StartDate < '{1}' or '{0}' > StartDate and '{1}' < EndDate)", searchBeginDate, searchEndDate);
            sql = string.Format("select TravelID,TravelTheme,ApplyUserID,ApplyUserName,ApplyDateNum,ApplyDate,StartDate,EndDate,ApprovalStatus from HR_AttenceBussinessTravel where IsDeleted <> 1 and ((startDate <='{0}' and '{1}' <= endDate) or ('{0}' <=startDate and startDate <= '{1}') or (EndDate>='{0}' and  EndDate <= '{1}' ))", searchBeginDate, searchEndDate);


            DataSet ds = DBHelper.GetDS(sql, CommandType.Text);

            foreach (DataRow dRow in ds.Tables[0].Rows)
            {
                startDate = Convert.ToDateTime(dRow["StartDate"]);
                endDate = Convert.ToDateTime(dRow["EndDate"]);

                if (searchBeginDate > startDate)
                {
                    startDate = searchBeginDate;
                }
                if (searchEndDate <= endDate)
                {
                    endDate = searchEndDate;
                }

                TimeSpan tss = new TimeSpan(startDate.Ticks);
                TimeSpan tse = new TimeSpan(endDate.Ticks);
                TimeSpan ts = tss.Subtract(tse).Duration();
                days += (ts.TotalDays + 1);
            }





            Console.WriteLine("相 差 " + days.ToString("0.00") + " 天。");



            Console.WriteLine(storedProcName);
            Console.ReadKey();
        }
        /// <summary>
        /// 加班那计算加班时长
        /// </summary>
        private static void jiaban()
        {
            DateTime nowDate = DateTime.Now;
            DateTime start = Convert.ToDateTime("2016-06-29");
            decimal Day = Convert.ToDecimal((nowDate.Day - start.Day) * 24);
            decimal Hours = Convert.ToDecimal((nowDate.Hour - start.Hour));
            decimal minutes = Convert.ToDecimal((nowDate.Minute - start.Minute) / 60);
            decimal sum = Day + Hours + minutes + Hours;

        }
        /// <summary>  
        /// 取得某月的第一天  
        /// </summary>  
        /// <param name="datetime">要取得月份第一天的时间</param>  
        /// <returns></returns>  
        private DateTime FirstDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day);
        }
        /// <summary>  
        /// 取得某月的最后一天  
        /// </summary>  
        /// <param name="datetime">要取得月份最后一天的时间</param>  
        /// <returns></returns>  
        private DateTime LastDayOfMonth(DateTime datetime)
        {
            return datetime.AddDays(1 - datetime.Day).AddMonths(1).AddDays(-1);
        }
    }
}
