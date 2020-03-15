using ClosedXML.Excel;
using CxSpec.Core.Specs;
using System;

namespace CxSpec.Core.Extensions
{
    public static class ClosedXmlCustomExtensions
    {
        public static T CLParseToEnum<T>(this string @this)
        {
            return (T)Enum.Parse(typeof(T), @this);
        }

        public static string CLGetStringUpper(this IXLCell @this)
        {
            return @this.GetString().ToUpper();
        }

        public static decimal HandleDecimal(this IXLCell @this)
        {
            try
            {
                var res = @this.GetValue<decimal>();
                return res;
            }
            catch
            {
                return -999999;
            }
        }

        public static decimal HandlePercentage(this IXLCell @this)
        {
            try
            {
                var res = @this.GetValue<decimal>() * 100;
                return res;
            }
            catch
            {
                return -999999;
            }
        }

        public static IXLCell CLSetColHeader(this IXLCell @this, string name, int width = 10,
            CxTipoCol TipoCol = CxTipoCol.General)
        {
            @this.Value = name;
            @this.Style.Font.Bold = true;
            @this.Style.Border.BottomBorder = XLBorderStyleValues.Thick;
            @this.Style.Alignment.SetVertical(XLAlignmentVerticalValues.Center);
            @this.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            @this.Style.Fill.BackgroundColor = XLColor.DarkCerulean;
            @this.Style.Font.FontColor = XLColor.White;
            return @this;
        }

        public static IXLCell CLSetBackColor(this IXLCell @this, XLColor color)
        {
            @this.Style.Fill.BackgroundColor = color;
            @this.Style.Font.FontColor = XLColor.White;
            return @this;
        }

        public static IXLCell CLSetForeColor(this IXLCell @this, XLColor color)
        {
            @this.Style.Font.FontColor = color;
            return @this;
        }

        public static IXLCell CLSetFormula(this IXLCell @this, string formula)
        {
            @this.FormulaA1 = formula;
            return @this;
        }

        public static IXLCell CLSetColHeader(this IXLWorksheet @this, int row, int col, string name, int width = 10,
            CxTipoCol TipoCol = CxTipoCol.General)
        {
            @this.Column(col).Width = width;
            @this.Column(col).Style.NumberFormat.NumberFormatId = (int)TipoCol;
            return @this.Cell(row, col).CLSetColHeader(name, width, TipoCol);
        }

        public static IXLCell CLSetColHeader(this IXLWorksheet @this, string colRow, string name, int width = 10, CxTipoCol TipoCol = CxTipoCol.General)
        {
            var col = colRow.Substring(0, 1);
            @this.Column(col).Width = width;
            @this.Column(col).Style.NumberFormat.NumberFormatId = (int)TipoCol;
            return @this.Cell(colRow).CLSetColHeader(name, width, TipoCol);
        }

        public static IXLCell CLSetComment(this IXLCell @this, string comment)
        {
            @this.Comment.AddText(comment);
            @this.Comment.Style.Alignment.SetAutomaticSize();
            return @this;
        }

        public static IXLCell CLSetContent(this IXLWorksheet @this, int row, int col, object content, XLColor back = null,
            XLColor front = null)
        {
            @this.Cell(row, col).Value = content;
            @this.Cell(row, col).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            if (back != null) { @this.Cell(row, col).Style.Fill.BackgroundColor = back; }
            if (front != null) { @this.Cell(row, col).Style.Font.FontColor = front; }
            return @this.Cell(row, col);
        }

        public static IXLCell CLSetContent(this IXLWorksheet @this, string colRow, object content, XLColor back = null,
            XLColor front = null)
        {
            @this.Cell(colRow).Value = content;
            @this.Cell(colRow).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
            if (back != null) { @this.Cell(colRow).Style.Fill.BackgroundColor = back; }
            if (front != null) { @this.Cell(colRow).Style.Font.FontColor = front; }
            return @this.Cell(colRow);
        }

        public static void CLSetDefaultHeight(this IXLWorksheet @this, int headerHeight = 30, int rowsHeight = 20, XLColor back = null)
        {
            @this.Rows().Height = rowsHeight;
            @this.Row(1).Height = headerHeight;
        }
    }
}