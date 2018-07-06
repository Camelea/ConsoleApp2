using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class ContrainteNonNulle
	{
		#region Attributs
		public string Nom;
		public string Colonne;
		#endregion

		#region Constructeur
		public ContrainteNonNulle(string nom, string colonne) 
		{
			this.Nom = nom;
			this.Colonne = colonne;

		}
		#endregion

		public override string ToString()
		{
			return (Nom + " NOT NULL"); //temporaire à regler plus tard 
		}

		public static List<List<ContrainteNonNulle>> GetContraintesNonNullesTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeContraintesNonNullesTables = new List<List<string>>();
			List<List<ContrainteNonNulle>> ListeContraintesNonNullesTables2 = new List<List<ContrainteNonNulle>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 4;
			int x = 0;
			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

			{

				ListeContraintesNonNullesTables.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeContraintesNonNullesTables[x].Add(isbn2.InnerText);

				}
				ListeContraintesNonNullesTables2.Add(ListeAContraintesNonNulles(ListeContraintesNonNullesTables[x]));
				n = n + 6;
				x++;
			}
			return ListeContraintesNonNullesTables2;

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de contraintes non nulles
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ContrainteNonNulle> ListeAContraintesNonNulles(List<string> liste)
		{
			List<ContrainteNonNulle> ListeContraintesNonNullesTables = new List<ContrainteNonNulle>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeContraintesNonNullesTables.Add(new ContrainteNonNulle(liste[i], liste[i + 1]));
			}
			return ListeContraintesNonNullesTables;
		}
	}
}