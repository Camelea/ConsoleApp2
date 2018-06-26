using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class ContrainteDeVerification
	{
		public string nom;
		public string colonne;
		public string condition;


		public ContrainteDeVerification(string nom, string colonne, string condition)
		{
			this.nom = nom;
			this.colonne = colonne;
			this.condition = condition;
		}
		public override string ToString()// à corriger 
		{
			return (nom + "" + colonne + "" + condition);

		}

		/// <summary>
		/// Renvoie la liste des contraintes de verification associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ContrainteDeVerification> ListeAContraintesDeVerification(List<string> liste)
		{
			List<ContrainteDeVerification> ListeContraintesDeVerificationTables = new List<ContrainteDeVerification>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeContraintesDeVerificationTables.Add(new ContrainteDeVerification(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeContraintesDeVerificationTables;
		}


		public static List<List<ContrainteDeVerification>> GetClesEtrangeresTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeColonnesTables = new List<List<string>>();
			List<List<ContrainteDeVerification>> ListeColonnesTables2 = new List<List<ContrainteDeVerification>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 5;
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
				ListeColonnesTables2.Add(ListeAContraintesDeVerification(ListeColonnesTables[x]));
				n = n + 6;
				x++;
			}
			return ListeColonnesTables2;

		}
	}

}