using ConsoleApp2.Tables;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2
{
	class Donnee
	{
		public string Nom;
		public string Valeur;


		public Donnee(string nom, string valeur)
		{
			this.Nom = nom;
			this.Valeur = valeur;

		}
		public override string ToString()
		{
			return (Nom + "" + Valeur);
		}



		/// <summary>
		/// Renvoie la liste des informaions de colonnes de chaque table
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Donnee>> GetDonneesTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeDonnesTables = new List<List<string>>();
			List<List<Donnee>> ListeDonnesTables2 = new List<List<Donnee>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 0;
			int x = 0;
			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

			{

				ListeDonnesTables.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+(n+1)+"]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDonnesTables[x].Add(isbn2.InnerText);

				}
				ListeDonnesTables2.Add(ListeADonnees(ListeDonnesTables[x]));
				n = n + 1;
				x++;
			}
			return ListeDonnesTables2;

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de donnes
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<Donnee> ListeADonnees(List<string> liste)
		{
			List<Donnee> ListeDonnesTables = new List<Donnee>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeDonnesTables.Add(new Donnee(liste[i], liste[i + 1]));
			}
			return ListeDonnesTables;
		}

	}
}
