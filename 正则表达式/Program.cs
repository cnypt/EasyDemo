using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace 正则表达式
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalconsumption = 0.0M, notparticipate = 0.0M, fullreduce = 0.0M, actualpay = 0.0M;
            decimal.TryParse("sss", out fullreduce);
            decimal.TryParse("10.1", out totalconsumption);
            decimal.TryParse("0.2", out notparticipate);
            string remark = "当面付订单。消费总额:" + totalconsumption + "元。不参与优惠的金额:" + notparticipate + "元。当面付优惠金额:" + fullreduce + "元。实付金额:" + actualpay + "元。";
            Console.WriteLine(remark);
            // string remark = "当面付订单。消费总额:0.01元。不参与优惠的金额:0元。当面付优惠金额:10.4元。实付金额:120元。";
            #region 方法1
            Regex regex = new Regex(@"(\d+(\.\d+)?)", RegexOptions.ECMAScript);
            Match match = regex.Match(remark);

            if (match.Value.Length != 0)
            {
                Console.WriteLine(string.Format("消费总额为：{0}", match.Value));
            }

            List<string> list = new List<string>();

            while (match.Value.Length != 0)
            {
                list.Add(match.Value);
                Console.WriteLine(match.Value);
                match = regex.Match(remark, match.Index + match.Value.Length);
            }
            if (list.Count == 4)
            {
                decimal a = Convert.ToDecimal(list[0]);
                decimal b = Convert.ToDecimal(list[1]);
                decimal c = Convert.ToDecimal(list[2]);
                decimal d = Convert.ToDecimal(list[3]);
                Console.WriteLine(string.Format("{0},{1},{2},{3}", a, b, c, d));
            }


            #endregion

            Console.WriteLine();

            #region 方法2
            MatchCollection matches = Regex.Matches(remark, @"\d+", RegexOptions.ECMAScript);
            for (int i = 0; i < matches.Count; i++)
            {
                Console.WriteLine(matches[i].Value);
            }
            #endregion



            Console.ReadKey();
        }
    }
}
