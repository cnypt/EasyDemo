using System;
using System.Data.SqlClient;

namespace AdoDoNet事务
{
    class Program
    {
        static void Main(string[] args)
        {
            string connection = "data source=.;Initial Catalog=OumindBlog;Integrated Security=SSPI";

            ExecuteSql(connection);

            ExecuteSqlTranscation(connection);

            Console.ReadKey();
        }

        /// <summary>
        /// 执行插入语句，不带事务的。
        /// </summary>
        /// <param name="connection">连接字符串</param>
        private static void ExecuteSql(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;

                try
                {
                    command.CommandText = "insert into test3(name) values('345')";
                    int i = command.ExecuteNonQuery();

                    command.CommandText = "select @@IDENTITY";
                    object ob = command.ExecuteScalar();

                    Console.WriteLine("Both Records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Execption Type:{0}", ex.GetType());
                    Console.WriteLine("  Message:{0}", ex.Message);
                }
            }
        }

        /// <summary>
        /// 执行插入语句，通过事务的处理机制
        /// </summary>
        /// <param name="connection"></param>
        private static void ExecuteSqlTranscation(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                transaction = connection.BeginTransaction("SampleTranscation");

                command.Connection = connection;
                command.Transaction = transaction;

                try
                {
                    command.CommandText = "insert into test3(name) values('789')";
                    command.ExecuteNonQuery();

                    command.CommandText = "select @@IDENTITY";
                    object ob = command.ExecuteScalar();

                    //第二句的插入语句插入的内容为上一个插入语句插入后的主键值
                    command.CommandText = "insert into test3(name) values('" + ob.ToString() + "')";
                    command.ExecuteNonQuery();

                    transaction.Commit();
                    Console.WriteLine("Both Records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Execption Type:{0}", ex.GetType());
                    Console.WriteLine("  Message:{0}", ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception Type:{0}", ex2.GetType());
                        Console.WriteLine(" Message:{0}", ex2.Message);
                    }
                }
            }
        }

    }
}
