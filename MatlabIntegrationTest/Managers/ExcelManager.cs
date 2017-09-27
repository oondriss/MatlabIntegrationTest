using MatlabIntegrationTest.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatlabIntegrationTest.Managers
{
    class ExcelManager
    {
        string _fileName;
        //double[][] input;
        //double[][] output;

        public ExcelManager(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentException("param cannot be empty string", nameof(fileName));
            }

            _fileName = fileName;
        }

        public void ParseSourceData()
        {
            using (ExcelPackage sourceFile = new ExcelPackage(new FileInfo(_fileName)))
            {
                var myWorksheet = sourceFile.Workbook.Worksheets.First(); //select sheet here
                var totalRows = myWorksheet.Dimension.End.Row;
                var totalColumns = myWorksheet.Dimension.End.Column;

                for (int rowNum = 2; rowNum <= totalRows; rowNum++) //select starting row here
                {
                    var row = myWorksheet.Cells[rowNum, 1, rowNum, totalColumns];

                    NeuronData.AddExcelRowData(row);
                    Console.WriteLine($"parsing: - {rowNum}/{totalRows}");
                }
            }
        }
    }
}