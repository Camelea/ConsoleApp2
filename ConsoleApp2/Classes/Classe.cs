using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.Classes
{

		internal class Classe
		{
			public String Nom { get; set; }


			public Classe(string Nom)
			{
				this.Nom = Nom;


			}

			/// <summary>
			/// 
			/// </summary>
			/// <param name="doc"></param>
			/// <param name="nsmgr"></param>
			/// <returns></returns>
			public static List<Classe> GetClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
			{

				XmlNodeList nodeList2;
				XmlElement root = doc.DocumentElement;
				List<string> ListeTables = new List<string>();
				List<Classe> ListeTables2 = new List<Classe>();
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeTables2.Add(new Classe(isbn2.InnerText));
				}

				return ListeTables2;


			}
			/// <summary>
			/// Retourne le nombre de tables dans la classe 
			/// </summary>
			/// <param name="doc"></param>
			/// <param name="nsmgr"></param>
			/// <returns></returns>
			public static int NombreTables(XmlDocument doc, XmlNamespaceManager nsmgr)
			{
				int res = GetClasses(doc, nsmgr).Count();
				return res;
			}

		internal static object GetTClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			throw new NotImplementedException();
		}
	}
	}
