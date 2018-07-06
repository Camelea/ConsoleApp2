using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ConstructeurParDefaut
	{
		public string Description;
		public List<ParametreEntrant> ParametresEntrants;
		public string Algorithme;

		public ConstructeurParDefaut(string description, List<ParametreEntrant> parametresEntrants, string algorithme)
		{
			this.Description = description;
			this.ParametresEntrants = parametresEntrants;
			this.Algorithme = algorithme;

		}


		/// <summary>
		/// Fonction qui permet de recuperer la liste des descriptions des contraintes par defaut de toutes les classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> GetDescriptionContrainteParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeSequencesTables = new List<string>();


			int n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeSequencesTables.Add(isbn2.InnerText);
				}
				n = n + 1;
			}

			return ListeSequencesTables;
		}
		/// <summary>
		/// Fonction qui permet de recuperer la liste des algorithmes des contraintes par defaut de toutes les classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> GetAlgorithmeContrainteParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeSequencesTables = new List<string>();


			int n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeSequencesTables.Add(isbn2.InnerText);
				}
				n = n + 1;
			}

			return ListeSequencesTables;
		}
		/// <summary>
		/// Permet de retourner une liste des constructeurs par defaut des classes presentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ConstructeurParDefaut> ConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<ParametreEntrant>> parametresEntrants = ParametreEntrant.GetParametresEntrantsConstructeurParDeafutClasse(doc, nsmgr);
			List<ConstructeurParDefaut> constructeursParDefaut = new List<ConstructeurParDefaut>();
			List<string> descriptions =GetDescriptionContrainteParDefaut(doc, nsmgr);
			List<string> algorithmes = GetAlgorithmeContrainteParDefaut(doc, nsmgr);
			for (int i = 0; i < Classe.NombreClasses(doc,nsmgr); i++)
			{
				constructeursParDefaut.Add( new ConstructeurParDefaut(descriptions[i], parametresEntrants[i], algorithmes[i]));
			}
			return constructeursParDefaut;

		}






	}
}