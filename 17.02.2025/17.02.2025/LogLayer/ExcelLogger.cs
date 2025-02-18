using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;

namespace LogLayer
{
    public class ExcelLogger : ILogger
    {
        public void Log(List<string> logMessages, string filePath)
        {
            if (!File.Exists(filePath))
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.AddWorksheet("Logs");
                worksheet.Cell(1, 1).Value = "Timestamp";
                worksheet.Cell(1, 2).Value = "Log Message";
                workbook.SaveAs(filePath); 
            }

            try
            {
                var existingWorkbook = new XLWorkbook(filePath);
                var worksheet = existingWorkbook.Worksheet("Logs");

                var nextRow = worksheet.LastRowUsed()?.RowNumber() + 1 ?? 1;

                foreach (var message in logMessages)
                {
                    worksheet.Cell(nextRow, 1).Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    worksheet.Cell(nextRow, 2).Value = message;
                    nextRow++;
                }

                existingWorkbook.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while saving to Excel: {ex.Message}");
            }
        }
    }
}
