using ClosedXML.Excel;
using CxSpec.Core.Extensions;
using CxSpec.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CxSpec.Core
{
    public class CxRowExport
    {
        public IXLWorksheet Export<T>(IXLWorksheet sheet, List<T> list) where T : CxFile
        {
            ExportTemplate(sheet, list.First());

            var props = list.First().GetType().GetProperties();
            var rownum = 2;
            foreach (var model in list)
            {
                for (int i = 0; i < props.Count(); i++)
                {
                    var spec = (CxColSpec)props[i].GetCustomAttributes(true)
                        .Where(x => x is CxColSpec)?.FirstOrDefault();

                    if (spec == null)
                    {
                        continue;
                    }
                    
                    var colrow = spec.Col + rownum;
                    sheet.CLSetContent(colrow, model.GetType().GetProperty(props[i].Name).GetValue(model, null));                    
                }
                rownum++;
            }
            sheet.CLSetDefaultHeight();
            return sheet;
        }
        private void ExportTemplate<T>(IXLWorksheet sheet, T model) where T : CxFile
        {
            var props = model.GetType().GetProperties();
            for (int i = 0; i < props.Count(); i++)
            {
                var spec = (CxColSpec)props[i].GetCustomAttributes(true)
                    .Where(x => x is CxColSpec)?.FirstOrDefault();

                if (spec == null)
                {
                    continue;
                }

                var rownum = 1;
                var colrow = spec.Col + rownum;
                var title = spec.Title == "" ? props[i].Name : spec.Title;
                var size = GetSizeFromPropValue(model, props[i].Name, title);
                sheet.CLSetColHeader(colrow, title, size, spec.TipoColumn);
            }
            
        }
        private static int GetSizeFromPropValue(object src, string propName, string title)
        {
            var obj = src.GetType().GetProperty(propName).GetValue(src, null);
            if (obj != null)
            {
                if (obj is DateTime)
                    return 24;
                
                if (obj is int)
                {
                    return title.Length+5;
                }

                string teste = Convert.ToString(obj);

                return teste.Length <10 ? 10 : teste.Length+10;

            }
            return 10;
        }
    }
    
}