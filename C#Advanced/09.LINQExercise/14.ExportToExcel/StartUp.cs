using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;

namespace _14.ExportToExcel
{
    public class StartUp
    {
        public static void Main()
        {
            var excelPackage = new ExcelPackage();
            excelPackage.Workbook.Worksheets.Add("Students");
            ExcelWorksheet ws = excelPackage.Workbook.Worksheets[1];
            var path = "../../StudentData.txt";

            ws.Cells[1, 1, 2, 11].Merge = true;
            ws.Cells[1, 1, 2, 11].Style.Font.Bold = true;
            ws.Cells[1, 1, 2, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            ws.Cells[1, 1, 2, 11].Value = "SoftUni OOP Course Result";
            ws.Cells[1, 1, 2, 11].Style.Font.Size = 22;

            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                var lineCounter = 3;
                while (line != null)
                {
                    var tokens = line.Split('\t');

                    for (int i = 0; i < tokens.Length; i++)
                    {
                        ws.Cells[lineCounter, i + 1].Value = tokens[i];
                    }

                    line = reader.ReadLine();
                    lineCounter++;
                }
            }

            var outputFilePath = "../../Students.xlsx";
            FileStream file = new FileStream(outputFilePath, FileMode.Create);
            excelPackage.SaveAs(file);
        }
    }
}