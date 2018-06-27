using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class CleEtrangere 
	{
		public string nom;
		public string colonne;
		public string table;


		public CleEtrangere(string nom, string colonne, string table) 
		{
			this.nom = nom;
			this.colonne = colonne;
			this.table = table;
		}
		public override string ToString()// à corriger 
		{
			return ("CONSTRAINT" + "\"" + this.nom + "\"" + "FOREIGN KEY ( \" " + this.colonne + " \" REFERENCES \" " + this.table + "(" + this.colonne + ")"); 

		}

		/// <summary>
		/// Renvoie les colonnes de cles etrangeres associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<CleEtrangere> ListeAClesEtrangeres(List<string> liste)
		{
			List<CleEtrangere> ListeClesEtrangeresTables = new List<CleEtrangere>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeClesEtrangeresTables.Add(new CleEtrangere(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeClesEtrangeresTables;
		}

		/// <summary>
		/// Methode qui permet de recuperer la liste des colonnes des tables 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<CleEtrangere>> GetClesEtrangeresTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeClesEtrangeresTables = new List<List<string>>();
			List<List<CleEtrangere>> ListeClesEtrangeresTables2 = new List<List<CleEtrangere>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 3;
			int x = 0;
			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

			{

				ListeClesEtrangeresTables.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeClesEtrangeresTables[x].Add(isbn2.InnerText);

				}
				ListeClesEtrangeresTables2.Add(ListeAClesEtrangeres(ListeClesEtrangeresTables[x]));
				n = n + 6;
				x++;
			}
			return ListeClesEtrangeresTables2;

		}
	}

}