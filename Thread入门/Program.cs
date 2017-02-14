using System;
using System.Threading;

namespace Thread入门
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();
            order.BusinessID = 1;
            order.BusinessName = "我不知道";

            #region 含有参数
            Thread newThread = new Thread(new ParameterizedThreadStart(UpdateOrderSumDay));
            newThread.Start(order);
            #endregion

            #region 不含有参数
            Thread newThread2 = new Thread(new ThreadStart(UpdateOrderSumDaybbb));
            newThread2.Start();
            #endregion


            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("主线程---" + i);
            }


            Console.ReadKey();
        }

        private static void UpdateOrderSumDaybbb()
        {
            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine("我知道----" + i);
            }
        }

        private static void UpdateOrderSumDay(object obj)
        {
            Order order = obj as Order;
            if (order.BusinessName == "我不知道")
            {
                for (int i = 0; i < 50; i++)
                {
                    Console.WriteLine("我不知道---" + i);
                }

            }
            else
            {
                Console.WriteLine("我知道");
            }
        }

        private class Order
        {
            public int BusinessID { get; set; }
            public string BusinessName { get; set; }
        }
    }
}
