using System;
using System.Collections.Generic;
using System.IO;
using System.Security;

namespace 获取某个文件夹下的所有文件名
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\yhsy_yht\Desktop\头像";

            //var files = Directory.GetFiles(path, "*.jpg");
            //foreach (var file in files)
            //{
            //    Console.WriteLine(file.);
            //}
            //Console.WriteLine(files.Count());
            //Console.ReadKey();

            List<string> files = null;
            string getFilesFilter = "*.jpg;*.jpeg;*.jpe;*.gif;*.bmp;*.png;";
            string[] arrFilter = getFilesFilter.Split(';');
            if (!string.IsNullOrEmpty(path))
            {
                files = new List<string>();
                try
                {
                    //DirectoryInfo di = new DirectoryInfo("Images");  
                    DirectoryInfo di = new DirectoryInfo(path);
                    for (int i = 0; i < arrFilter.Length; i++)
                    {
                        if (di.Exists)
                        {
                            foreach (FileInfo fileInfo in di.GetFiles(arrFilter[i]))
                            {
                                //  files.Add(fileInfo.FullName);
                                files.Add(fileInfo.Name);
                                if (files.Count > 50)
                                    break;
                            }
                        }
                    }
                }
                catch (IOException) { }
                catch (ArgumentException) { }
                catch (SecurityException) { }
            }
            foreach (string filename in files)
            {
                Console.WriteLine(filename);
            }
            Console.WriteLine(files.Count);
            Console.ReadKey();
        }
    }
}
