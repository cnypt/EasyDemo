using System;
using System.Linq;
using System.Transactions;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Select();

            Program pr = new EFDemo.Program();

            pr.AddEasy("Ths");

            pr.AddTrans("YouAndMe");

            Console.ReadKey();
        }

        /// <summary>
        /// 借助TransactionScope类来实现插入    需要添加System.Transactions引用
        /// </summary>
        /// <param name="name"></param>
        private void AddTrans(string name)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                using (var db = new OumindBlogEntities())
                {
                    try
                    {
                        test3 t3 = AddMain(name, db);

                        AddDetails(db, t3);

                        ts.Complete();  //只有执行了Complete方法，AddMain跟AddDetails方法才会产生影响
                        Console.WriteLine("执行成功");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }

        }

        /// <summary>
        /// 添加主表信息
        /// </summary>
        /// <param name="name">主表内容</param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static test3 AddMain(string name, OumindBlogEntities db)
        {
            test3 t3 = new test3();
            t3.name = name;
            db.test3.Add(t3);
            db.SaveChanges();
            return t3;
        }

        /// <summary>
        /// 添加明细表信息
        /// </summary>
        /// <param name="db"></param>
        /// <param name="t3"></param>
        private static void AddDetails(OumindBlogEntities db, test3 t3)
        {
            test4 t4 = new test4();
            t4.name = t3.ID.ToString() + "成功了";
            db.test4.Add(t4);
            db.SaveChanges();
        }


        /// <summary>
        /// 往两张表中分别添加一条数据，如果有一条插入语句执行出错。则两条插入语句都不会执行
        /// </summary>
        /// <param name="name"></param>
        void AddEasy(string name)
        {
            using (var db = new OumindBlogEntities())
            {

                try
                {
                    test3 t3 = new test3();
                    t3.name = name;
                    db.test3.Add(t3);

                    test4 t4 = new test4();
                    t4.name = name;
                    db.test4.Add(t4);

                    object i = db.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        /// <summary>
        /// 查询方法
        /// </summary>
        private static void Select()
        {
            //实例化数据库上下文
            using (OumindBlogEntities _context = new OumindBlogEntities())
            {
                //使用Lambda表达式查询数据
                var user = _context.test3.Where(u => u.name.Contains("7")).ToList();

                //Linq语句查询
                var user1 = from t in _context.test3
                            where t.name.Contains("8")
                            select t;

                //打印结果
                if (user.Any())
                {
                    Console.WriteLine("Lambda方式：" + user.First().name);
                }
                if (user1.Any())
                {
                    Console.WriteLine("Linq方式：" + user1.FirstOrDefault().name);
                }
            }
        }
    }
}
