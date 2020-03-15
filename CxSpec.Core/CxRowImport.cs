using ClosedXML.Excel;
using CxSpec.Core.Specs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CxSpec.Core
{
    public class CxRowImport
    {
        private List<string> _parseErrors;
        public CxRowImport()
        {
            _parseErrors = new List<string>();
        }
        public bool ParseRow<T>(IXLRangeRow row, int lineNumber, T model) where T : CxFile
        {
            var props = model.GetType().GetProperties();

            try
            {
                for (int i = 0; i < props.Count(); i++)
                {
                    var spec = (CxColSpec)props[i].GetCustomAttributes(true).Where(x => x is CxColSpec)?.FirstOrDefault();
                    if (spec == null)
                    {
                        if (props[i].Name == "LineNumber")
                        {
                            model.GetType()
                                 .GetProperty(props[i].Name)
                                 .SetValue(model, lineNumber, null);
                        }
                        continue;
                    }

                    var val = row.Cell(spec.Col).GetString();
                    if (val == "")
                        continue;

                    if (props[i].PropertyType == typeof(bool))
                    {
                        if (val == "S" || val == "Y" || val == "1")
                        {
                            val = "true";
                        }
                        else
                        {
                            val = "false";
                        }
                    }

                    var obj = Convert.ChangeType(val, props[i].PropertyType);

                    model.GetType()
                        .GetProperty(props[i].Name)
                        .SetValue(model, obj, null);
                }
            }
            catch (Exception ex)
            {
                _parseErrors.Add($"Error parsing excel - ParseRow : line {lineNumber} {ex.Message}");
                return false;
            }
            return true;
        }
        
    }
}