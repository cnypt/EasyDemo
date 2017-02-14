using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.IO;

namespace NPOIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().CreateExcel();
            new Program().InsertContext();
        }

        /// <summary>
        /// 创建Excel
        /// </summary>
        private void CreateExcel()
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
    }
}
