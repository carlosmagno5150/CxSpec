using ClosedXML.Excel;
using CxSpec.Core;
using CxSpec.Core.Specs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CxSpec.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            var path = @"C:\Projects\teste.xlsx";
            var save = @"C:\Projects\testeSeave.xlsx";

            //Import
            var ret = new List<ArquivoExample>();
            using (var workbook = new XLWorkbook(path))
            {
                var sheet = workbook.Worksheet(1);
                var s = new CxSheetImport();
                ret = s.Import<ArquivoExample>(sheet);
            };

            //Export
            using (var wb = new XLWorkbook())
            {
                var sheet = wb.AddWorksheet("Sheet1");
                var exporter = new CxRowExport();                
                exporter.Export(sheet, ret);                
                wb.SaveAs(save);
            }


            Console.WriteLine("Hello World!");
        }
    }
}
