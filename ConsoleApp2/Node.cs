//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Xml;
//using System.Xml.Linq;
//using System.Xml.XPath;

//namespace ConsoleApp2.Tables
//{
//	internal static class Node
//	{



//		public static bool HasElement(this XElement xElement, EnumElements element)
//		{
//			return HasElement(xElement, StringEnum.GetStringValue(element));
//		}


//		public static bool HasElement(this XElement xElement, string element)
//		{
//			return xElement.Name.LocalName == element;
//		}


//		public static string GetValue(this XElement xElement, XmlNamespaceManager xmlNsMgr)
//		{
//			var elements = xElement.XPathSelectElements(" w:r / w:t ", xmlNsMgr);
//			StringBuilder sb = new StringBuilder();
//			foreach (var e in elements)
//			{
//				sb.Append(e.Value);
//			}
//			return sb.ToString();
//		}


//		public static bool HasFollowingStyle(this XElement xElement, EnumStyles value, XmlNamespaceManager xmlNsMgr)
//		{
//			return xElement.HasFollowingStyle(StringEnum.GetStringValue(value), xmlNsMgr);
//		}

//		public static bool HasFollowingStyle(this XElement xElement, string style, XmlNamespaceManager xmlNsMgr)
//		{
//			//  w:pPr / w:pStyle[@w:val = '{0}']
//			return xElement.XPathSelectElement(string.Format(" // w:pStyle[@w:val = '{0}']", style), xmlNsMgr) != null;
//		}


//		public static List<List<string>> ParseTable(this XElement xElement, XmlNamespaceManager xmlNsMgr)
//		{
//			List<List<string>> table = new List<List<string>>();

//			var rows = xElement.XPathSelectElements(" w:tr ", xmlNsMgr);
//			foreach (var row in rows)
//			{

//				List<string> tableRow = new List<string>();
//				var columnsName = new List<string>();
//				var columns = row.XPathSelectElements(" w:tc ", xmlNsMgr);
//				foreach (var column in columns)
//				{
//					var elmt = column.XPathSelectElement(" w:p / w:r / w:t ", xmlNsMgr);
//					if (elmt != null)
//					{

//						var field = elmt.Value;
//						tableRow.Add(field);

//					}
//				}
//				table.Add(tableRow);
//				Console.WriteLine();
//			}
//			return table;
//		}





//	}
//}
