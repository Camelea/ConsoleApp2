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

		public Colonne(string nom , string type , string description)
		{
			this.nom = nom;
			this.type = type;
			this.description = description;

		}

		public override string ToString()
		{
			return (nom + " " + type );

		}
		/// <summary>
		/// Renvoie la liste des informaions de colonnes de chaque table
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Colonne>> GetColonnesTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeColonnesTables = new List<List<string>>();
			List<List<Colonne>> ListeColonnesTables2 = new List<List<Colonne>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 1;
			int x = 0;
			for (int i = 1; i < Table.NombreTables(doc,nsmgr) +1; i++)

			{
				ListeColonnesTables.Add(new List<string>());

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (n + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

				string xpath2 = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading2']]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']] ";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeColonnesTables[x].Add(isbn2.InnerText);

				}
				ListeColonnesTables2.Add(ListeAColonnes(ListeColonnesTables[x]));
				n = n + 3;
				x++;
			}
			return ListeColonnesTables2;
		
		}
				
		/// <summary>
		/// Renvoie la liste des colonnes associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<Colonne> ListeAColonnes(List<string> liste)
		{
			List<Colonne> ListeColonnesTables = new List<Colonne>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeColonnesTables.Add(new Colonne(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeColonnesTables;
		}

	}
}
	