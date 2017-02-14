using System;
using System.Collections.Generic;
using System.Linq;        //需要借助Linq来实现

namespace List集合操作
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listA = new List<int> { 1, 2, 3, 5, 7, 9 };

            List<int> listB = new List<int> { 2, 4, 13, 17, 29 };

            List<int> Result_Intersect = listA.Intersect(listB).ToList();       //两个集合的交集

            List<int> Result_Union = listA.Union(listB).ToList<int>();          //两个集合的并集,删除重复项
            List<int> Result = listA.Concat(listB).ToList<int>();               //两个集合的并集,保留重复项
            listA.AddRange(listB);

            List<int> listnull = null;

            List<int> listA1 = new List<int> { };

            List<int> listB1 = new List<int> { 2, 4, 13, 17, 29 };

            List<int> Result_Concat1 = listA1.Intersect(listB1).ToList();       //两个集合的并集,保留重复项

            List<int> Result_Intersect1 = listA1.Intersect(listB1).ToList();       //两个集合的交集

            //求两个集合的交集时，首先要判断两个集合是否为null，如果不为null，则取交集。若为null，则不取交集。
            Result_Intersect1 = listnull.Intersect(listB1).ToList();       //两个集合的交集

            Console.WriteLine("按任意键继续.......");


            Console.ReadKey();
            var lst = new List<Stat> {
            new Stat{Id=1,Name="N1",Value=5},
            new Stat{Id=2,Name="N2",Value=2},
            new Stat{Id=3,Name="N3",Value=6},
            new Stat{Id=4,Name="N2",Value=15},
            new Stat{Id=5,Name="N1",Value=20},
            new Stat{Id=6,Name="N6",Value=3},
            new Stat{Id=7,Name="N5",Value=8},
            };
            Console.WriteLine("原始数据↓↓↓↓↓↓↓↓");
            foreach (var item in lst)
            {
                Console.WriteLine("Key:{0},Name:{1},Count:{2}", item.Id, item.Name, item.Value);
            }
            Console.WriteLine("新的集合↓↓↓↓↓↓↓↓");
            var g = lst.GroupBy(x => x.Name);
            var results = g.Select(x => new
            {
                Key = x.Key,
                Name = x.First().Name,
                Sum = x.Sum(s => s.Value),
                Count = x.Count()
            });
            foreach (var item in results)
            {
                Console.WriteLine("Key:{0},Name:{1},Sum:{2},Count:{3}", item.Key, item.Name, item.Sum, item.Count);
            }
            Console.ReadKey();
        }
    }
    class Stat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
