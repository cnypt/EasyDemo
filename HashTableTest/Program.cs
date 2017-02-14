using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable(); //创建一个Hashtable实例
            ht.Add("E", "e");//添加key/value键值对
            ht.Add("A", "a");
            ht.Add("C", "c");
            ht.Add("B", "b");
            string s = (string)ht["A"];
            if (ht.Contains("E")) //判断哈希表是否包含特定键,其返回值为true或false
                Console.WriteLine("the E key:exist");
            ht.Remove("C");//移除一个key/value键值对
            Console.WriteLine(ht["A"]);//此处输出a
            ht.Clear();//移除所有元素
            Console.WriteLine(ht["A"]); //此处将不会有任何输出

            Console.ReadKey();
        }
    }
}
