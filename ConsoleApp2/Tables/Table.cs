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

		public Table()
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
			// nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading1']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);

			// w:p / w:pPr [preceding - sibling::b / @property = 'p1' and following - sibling::b / @property = 'p2']

			//w:p[preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading1']]][(| //tr[following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading1']])]



			nodeList2 = root.SelectNodes("//w:p[ w:pPr / w:pStyle [@w:val='Heading2']][1]/preceding-sibling::*", nsmgr);
			 


			foreach (XmlNode isbn2 in nodeList2)
			{

				ListeTables.Add(isbn2.InnerText);
			}

			foreach (string elem in ListeTables)
			{

				int i = ListeTables.IndexOf("Description des classes métier");
				int i2 = ListeTables.IndexOf("Description des tables");
				for (int n = i2 + 1; n < i; n++)
				{
					ListeTables2.Add(new Table()
					{
						Nom = ListeTables[n]
					});

				}



			}
			return ListeTables2;
		}

	}
}