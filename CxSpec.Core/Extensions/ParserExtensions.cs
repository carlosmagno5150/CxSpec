//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace CxSpec.Core.Extensions
//{
//	public static class ParserExtensions
//	{
//		public static T ToEnum<T>(this string @this)
//		{
//			return (T)Enum.Parse(typeof(T), @this);
//		}
		
//		public static decimal ToPercent(this decimal @this)
//		{
//			try
//			{
//				var res = @this * 100;
//				return res;
//			}
//			catch
//			{
//				return -999999;
//			}
//		}

//		private static DateTime JoinDateAndTime(int[] data, int[] hora)
//		{
//			var dt = new DateTime(data[2], data[1], data[0], hora[0], hora[1], 0);
//			return dt;
//		}

//		public static DateTime ToDateAndTime(DateTime data, string hora)
//		{
//			var d1 = data.ToString().Split(' ')[0];
//			var h1 = hora.ToString().Split(' ')[1];

//			var res = JoinDateAndTime(
//				d1.Split('/').Select(x => Convert.ToInt32(x)).ToArray(),
//						h1.Split(':').Select(x => Convert.ToInt32(x)).ToArray());
//			return res;
//		}

//	}
//}
