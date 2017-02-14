using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.IO;
using System.Text;

namespace NPOIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
          //  new Program().CreateExcel1();
            new Program().InsertContext();
        }

        /// <summary>
        /// 创建一个Excel 1
        /// </summary>
        private void CreateExcel1()
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            FileStream filestream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls", FileMode.Create);

            //新增测试表
            workbook.CreateSheet("测试表A");
            workbook.CreateSheet("测试表B");
            workbook.CreateSheet("测试表C");

            workbook.Write(filestream);
            workbook.Close();

            filestream.Close();
            filestream.Dispose();
        }

        /// <summary>
        /// 往Excel中添加内容
        /// </summary>
        private void InsertContext()
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            FileStream filestream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + DateTime.Now.ToString("yyyyMMddHHmmss") + ".xls", FileMode.Create);

            //新增测试表
            ISheet sheet1 = workbook.CreateSheet("测试表A");
            ISheet sheet2 = workbook.CreateSheet("测试表B");
            ISheet sheet3 = workbook.CreateSheet("测试表C");

            //依次创建行和列
            for (int i = 0; i < 10; i++)
            {
                IRow row1 = sheet1.CreateRow(i);
                IRow row2 = sheet2.CreateRow(i);
                IRow row3 = sheet3.CreateRow(i);

                for (int j = 0; j < 10; j++)
                {
                    ICell cell1 = row1.CreateCell(j);
                    cell1.SetCellValue("Sheet1的第" + (i + 1) + "行，第" + (j + 1) + "列");

                    ICell cell2 = row2.CreateCell(j);
                    cell2.SetCellValue("Sheet2的第" + (i + 1) + "行，第" + (j + 1) + "列");

                    ICell cell3 = row3.CreateCell(j);
                    cell3.SetCellValue("Sheet3的第" + (i + 1) + "行，第" + (j + 1) + "列");
                }
            }

            workbook.Write(filestream);
            workbook.Close();

            filestream.Close();
            filestream.Dispose();
        }

        /// <summary>
        /// 创建简单的Excel
        /// </summary>
        private void CreateExcel2()
        {
            //创建工作薄
            HSSFWorkbook wk = new HSSFWorkbook();
            //创建一个名称为mySheet的表
            ISheet tb = wk.CreateSheet("mySheet");
            //创建一行，此行为第二行
            IRow row = tb.CreateRow(1);
            for (int i = 0; i < 20; i++)
            {
                ICell cell = row.CreateCell(i);  //在第二行中创建单元格
                cell.SetCellValue(i);  //循环往第二行的单元格中添加数据

            }
            using (FileStream fs = File.OpenWrite("D:\\DanMao\\ConsoleApplication\\NPOIFORXls\\myxls.xls"))
            {
                wk.Write(fs);   //向打开的这个xls文件中写入mySheet表并保存。
                Console.WriteLine("创建成功。");
            }
        }

        /// <summary>
        /// 创建简单的excel3
        /// </summary>
        private void CreateExcel3()
        {
            StringBuilder sbr = new StringBuilder();
            using (FileStream fs = File.OpenRead(@"D:/DanMao/ConsoleApplication/NPOIFORXls/myxls.xls"))   //打开myxls.xls文件
            {
                HSSFWorkbook wk = new HSSFWorkbook(fs);   //把xls文件中的数据写入wk中
                for (int i = 0; i < wk.NumberOfSheets; i++)  //NumberOfSheets是myxls.xls中总共的表数
                {
                    ISheet sheet = wk.GetSheetAt(i);   //读取当前表数据
                    for (int j = 0; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
                    {
                        IRow row = sheet.GetRow(j);  //读取当前行数据
                        if (row != null)
                        {
                            sbr.Append("-------------------------------------\r\n"); //读取行与行之间的提示界限
                            for (int k = 0; k <= row.LastCellNum; k++)  //LastCellNum 是当前行的总列数
                            {
                                ICell cell = row.GetCell(k);  //当前表格
                                if (cell != null)
                                {
                                    sbr.Append(cell.ToString());   //获取表格中的数据并转换为字符串类型
                                }
                            }
                        }
                    }
                }
            }
            sbr.ToString();
            using (StreamWriter wr = new StreamWriter(new FileStream(@"D:/DanMao/ConsoleApplication/NPOIFORXls/myxls.xls", FileMode.Append)))  //把读取xls文件的数据写入myText.txt文件中
            {
                wr.Write(sbr.ToString());
                wr.Flush();
            }
        }
    }
}
