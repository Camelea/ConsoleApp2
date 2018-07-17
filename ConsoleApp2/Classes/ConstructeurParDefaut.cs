using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ConstructeurParDefaut
	{
		#region Attributs

		public string Description;
		public List<ParametreEntrant> ParametresEntrants;
		public string Algorithme;

		#endregion

		#region Constructeur 

		public ConstructeurParDefaut(string description, List<ParametreEntrant> parametresEntrants, string algorithme)
		{
			this.Description = description;
			this.ParametresEntrants = parametresEntrants;
			this.Algorithme = algorithme;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			return ("description" + "\n" + this.Description + "\n" + "Algo" + "\n" + this.Algorithme);
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
			List<string> ListeDescriptionsContraintesParDefautClasse = new List<string>();


			int n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsContraintesParDefautClasse.Add(isbn2.InnerText);
				}
				if (ListeDescriptionsContraintesParDefautClasse.Count < i)
				{
					ListeDescriptionsContraintesParDefautClasse.Add("none");
				}
				n = n + 1;
			}
			while (ListeDescriptionsContraintesParDefautClasse.Count < Classe.NombreClasses(doc, nsmgr))
			{
				ListeDescriptionsContraintesParDefautClasse.Add("none");
			}

			return ListeDescriptionsContraintesParDefautClasse;
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
			List<string> ListeAlgorithmesContraintesParDefautClasse = new List<string>();


			int n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] / following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] /preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				string xpath2 = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] / following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (n + 1) + "] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (n + 1) + "] /preceding-sibling::w:p)]";

				string xpath3 = xpath + "[count(. |" + xpath2 + ")" + "= count(" + xpath2 + ")]";
				var res = "";
				
				nodeList2 = root.SelectNodes(xpath3, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					res=res + (isbn2.InnerText);
				}
				if (res != " ")
				{
					ListeAlgorithmesContraintesParDefautClasse.Add(res);
				}
				if (res == " ")
				{
					ListeAlgorithmesContraintesParDefautClasse.Add("none");
				}

				n = n + 1;
			}
			while (ListeAlgorithmesContraintesParDefautClasse.Count < Classe.NombreClasses(doc, nsmgr))
			{
				ListeAlgorithmesContraintesParDefautClasse.Add("none");
			}

			return ListeAlgorithmesContraintesParDefautClasse;
		}


		/// <summary>
		/// Permet de retourner une liste des constructeurs par defaut des classes presentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ConstructeurParDefaut> ConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<ParametreEntrant>> parametresEntrants = ParametreEntrant.GetParametresEntrantsConstructeurParDefautClasse(doc, nsmgr);
			List<ConstructeurParDefaut> constructeursParDefaut = new List<ConstructeurParDefaut>();
			List<string> descriptions =GetDescriptionContrainteParDefaut(doc, nsmgr);
			List<string> algorithmes = GetAlgorithmeContrainteParDefaut(doc, nsmgr);
			for (int i = 0; i < Classe.NombreClasses(doc,nsmgr); i++)
			{
				constructeursParDefaut.Add( new ConstructeurParDefaut(descriptions[i], parametresEntrants[i], algorithmes[i]));
			}
			return constructeursParDefaut;

		}

		#endregion





	}
}