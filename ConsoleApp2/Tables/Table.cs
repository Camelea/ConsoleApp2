using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Table
	{
		public String Nom { get; set; }
		public List<Colonne> Colonnes { get; set; }
		//public List<Contrainte> Contraintes { get; set; }

		public Table(string Nom)
		{
			this.Nom = Nom;
			this.Colonnes = Colonnes;
			//this.Contraintes = Contraintes;

		}


		public static List<Table> GetTables(XmlDocument doc, XmlNamespaceManager nsmgr)
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