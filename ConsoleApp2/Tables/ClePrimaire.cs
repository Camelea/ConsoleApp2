using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class ClePrimaire 
	{

		public string nom;
		public string colonne;


		public ClePrimaire(string nom, string colonne) 
		{
			this.nom = nom;
			this.colonne = colonne;

		}
		public override string ToString()
		{
			return ("CONSTRAINT " + "\"" + this.nom + "\"" + "PIMARY KEY ( \" " + this.colonne + " \" REFERENCES \" "  + "(" + this.colonne + ")");
		}


		public static List<List<ClePrimaire>> GetClesPrimairesTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeColonnesTables = new List<List<string>>();
			List<List<ClePrimaire>> ListeColonnesTables2 = new List<List<ClePrimaire>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 2;
			int x = 0;
			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

			{

				ListeColonnesTables.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeColonnesTables[x].Add(isbn2.InnerText);

				}
				ListeColonnesTables2.Add(ListeAClesPrimaires(ListeColonnesTables[x]));
				n = n +6;
				x++;
			}
			return ListeColonnesTables2;

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de cles primaires
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ClePrimaire> ListeAClesPrimaires(List<string> liste)
		{
			List<ClePrimaire> ListeClesPrimaireTables = new List<ClePrimaire>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeClesPrimaireTables.Add(new ClePrimaire(liste[i], liste[i + 1]));
			}
			return ListeClesPrimaireTables;
		}




	}
}