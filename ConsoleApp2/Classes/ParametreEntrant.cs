using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ParametreEntrant
	{
		public string Nom;
		public string Type;
		public string Description;
		public string Obligatoire;



		public ParametreEntrant(string nom, string type, string description)
	{
		this.Nom = nom;
		this.Type = type;
		this.Description = description;

	}


		public override string ToString()
		{
			return (Nom + " " + Type);

		}

		/// <summary>
		/// Renvoie la liste des informations de parametres entrants du constructeurs par defaut de chaque classe
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreEntrant>> GetParametresEntrantsClasse(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresEntrantsClasses = new List<List<string>>();
			List<List<ParametreEntrant>> ListeColonnesTables2 = new List<List<ParametreEntrant>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 1 ;
			int x = 0;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{

				ListeParametresEntrantsClasses.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+n+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+n+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+n+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeParametresEntrantsClasses[x].Add(isbn2.InnerText);

				}
				ListeColonnesTables2.Add(ListeAParametresEntrants(ListeParametresEntrantsClasses[x]));
				n++;
				x++;
			}
			return ListeColonnesTables2;

		}

		/// <summary>
		/// Renvoie la liste des informations de parametres entrants du constructeurs par defaut de chaque classe
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreEntrant>> GetParametresEntrantsConstructeurInitialisationClasse(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresEntrantsClasses = new List<List<string>>();
			List<List<ParametreEntrant>> ListeColonnesTables2 = new List<List<ParametreEntrant>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 1;
			int x = 0;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{

				ListeParametresEntrantsClasses.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][5]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][6]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][6]/preceding-sibling::w:tbl / w:tr /w:tc)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeParametresEntrantsClasses[x].Add(isbn2.InnerText);

				}
				ListeColonnesTables2.Add(ListeAParametresEntrantsConstructeurInitialisation(ListeParametresEntrantsClasses[x]));
				n++;
				x++;
			}
			return ListeColonnesTables2;

		}

		/// <summary>
		/// Renvoie la liste des parametres entrants associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreEntrant> ListeAParametresEntrants(List<string> liste)
		{
			List<ParametreEntrant> ListeParametresEntrantsClasses = new List<ParametreEntrant>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresEntrantsClasses.Add(new ParametreEntrant(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresEntrantsClasses;
		}

		/// <summary>
		/// Renvoie la liste des parametres entrants associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreEntrant> ListeAParametresEntrantsConstructeurInitialisation(List<string> liste)
		{
			List<ParametreEntrant> ListeParametresEntrantsClasses = new List<ParametreEntrant>();
			for (int i = 4; i < liste.Count; i = i + 3)
			{
				ListeParametresEntrantsClasses.Add(new ParametreEntrant(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresEntrantsClasses;
		}


	}
}





