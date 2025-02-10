using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace _04._02._2025
{
    public class XlsxLogger : ILog
    {
        private List<string> logs = new List<string>();

        public void Log(string message)
        {
            logs.Add(message);
        }

        public void Save(string filePath)
        {
            var workbook = new XLWorkbook();

            using (workbook)
            {
                var worksheet = workbook.Worksheets.Add($"{logs[1]}");

                if (this.logs[0] == "Print")
                {
                    worksheet.Cell(1, 1).Value = "Player Name";
                    worksheet.Cell(1, 2).Value = "Player Position";

                    for (int i = 2; i < logs.Count; i++)
                    {
                        var logParts = logs[i].Split(" is at position ");
                        worksheet.Cell(i, 1).Value = logParts[0];
                        worksheet.Cell(i, 2).Value = logParts[1];
                    }
                }
                else
                {
                    worksheet.Cell(1, 1).Value = "Event";

                    for (int i = 1; i < logs.Count; i++)
                    {
                        worksheet.Cell(i + 1, 1).Value = logs[i];
                    }

                }

                workbook.SaveAs("../../../Output/" + filePath);
            }

            this.logs.Clear();
        }
    }
}
