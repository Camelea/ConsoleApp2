using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ConstructeurInitialisation
	{
		public string Description;
		public List<ParametreEntrant> ParametresEntrants;
		public string Algorithme;

		public ConstructeurInitialisation(string description, List<ParametreEntrant> parametresEntrants, string algorithme)
		{
			this.Description = description;
			this.ParametresEntrants = parametresEntrants;
			this.Algorithme = algorithme;

		}


		/// <summary>
		/// Fonction qui permet de recuperer la liste des descriptions des contraintes d'initialisation de toutes les classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> GetDescriptionContrainteInitialisation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeSequencesTables = new List<string>();


			int n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][5]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][5]/preceding-sibling::w:p)]";

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
		/// Fonction qui permet de recuperer la liste des algorithmes des contraintes d'initialisation de toutes les classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> GetAlgorithmeContrainteInitialisation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeSequencesTables = new List<string>();


			int n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][6]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/preceding-sibling::w:p)]";

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
		public static List<ConstructeurInitialisation> ConstructeursInitialisation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<ParametreEntrant>> parametresEntrants = ParametreEntrant.GetParametresEntrantsClasse(doc, nsmgr);
			List<ConstructeurInitialisation> constructeursInitialisation = new List<ConstructeurInitialisation>();
			List<string> descriptions = GetDescriptionContrainteInitialisation(doc, nsmgr);
			List<string> algorithmes = GetAlgorithmeContrainteInitialisation(doc, nsmgr);
			for (int i = 0; i < Classe.NombreClasses(doc, nsmgr); i++)
			{
				constructeursInitialisation.Add(new ConstructeurInitialisation(descriptions[i], parametresEntrants[i], algorithmes[i]));
			}
			return constructeursInitialisation;

		}




	}
}