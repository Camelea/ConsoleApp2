using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Colonne
	{
		List<Colonne> colonnes;
		public string type;
		public string description;
		public string nom;

		public Colonne()
		{
			this.nom = nom;
			this.type = type;
			this.description = description;

		}

		public string colonne()
		{
			return (nom + type );

		}

		public static List<Colonne> GetTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeTables = new List<string>();
			List<Table> ListeTables2 = new List<Table>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeTables2.Add(new Table(isbn2.InnerText));
			}

			return ListeTables2;


		}
	}
	
}