using ClosedXML.Excel;
using CxSpec.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CxSpec.Core
{
    public class CxSheetImport
    {
        public List<T> Import<T>(IXLWorksheet sheet) where T : CxFile
        {
            var ret = new List<T>();

            var import = new CxRowImport();
            var rows = sheet.RangeUsed().RowsUsed().Skip(1); // Skip header row
            foreach (var row in rows)
            {
                var rowNumber = row.RowNumber() - 1;
                var instance = (T)Activator.CreateInstance(typeof(T));
                import.ParseRow(row, rowNumber, instance);
                ret.Add(instance);
            }
            return ret;
        }
    }
}