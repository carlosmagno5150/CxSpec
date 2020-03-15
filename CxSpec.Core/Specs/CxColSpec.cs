using System;

namespace CxSpec.Core.Specs
{
	public class CxColSpec : Attribute
	{
		public CxColSpec(string col)
		{
			Col = col;
			Nullable = false;
			Title = "";
			TipoColumn = CxTipoCol.General;
		}		
		public CxColSpec(string col, string title = "", bool nullable = false, CxTipoCol tipoCol = CxTipoCol.General)
		{
			Col = col;
			Nullable = nullable;
			Title = title;
			TipoColumn = tipoCol;
		}

		public string Col { get; }
		public int ColAsInt { get; }
		public bool Nullable { get; set; }		
		public CxTipoCol TipoColumn { get; set; }
		public string Title { get; set; }

	}
}