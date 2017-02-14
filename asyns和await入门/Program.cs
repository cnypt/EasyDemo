using System;
using System.Threading;
using System.Threading.Tasks;

namespace asyns和await入门
{
    class Program
    { // ---------------规范说明-----------------------------
        //1.用async标识的方法即为异步方法，异步方法的返回值只能是void或者Task<object>或者Task。,---返回值是void的方法，不能使用await调用。注意你的返回类型。
        //2.在其他方法中调用异步方法时，可以加await，表示等待这个异步方法结束。 异步的关键点就在这个await
        //3.await标签只能写在异步方法中
        //4.await标识并调用的方法中，也必须要有await才行
        static void Main(string[] args)
        {
            //第一步，写了一个  “1”
            Console.WriteLine("1");

            Paint();
            //第三步----2，写了一个  “5”
            Console.WriteLine("5");

            Console.ReadLine();
        }
        //此方法是已经标明是异步方法
        private async static void Paint()
        {
            //第二步，写了一个“2”
            Console.WriteLine("2");

            //第三步--1，代码发现await字段，整个方法将直接返回， 并在这个await这里加个标签，所以第三步输出的是“5”
            //等到 RequestBody方法返回值时，再次进入Paint方法中，并且直接从这个await字段处运行，

            //-----------------------------等待两秒---------这时候，已经输出了“5”

            //一秒后RequestBody方法返回值了，RequestBody的返回类型应该是Task<string>，
            //但是，用了await之后，返回值直接就是string
            //并且，输出“4”的操作被await阻塞
            Console.WriteLine(await RequestBody());

            Console.WriteLine("4");
        }

        async private static Task<string> RequestBody()
        {
            return await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return "3";
            }
             );
        }
    }
}
