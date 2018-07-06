using ConsoleApp2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.WebMethodes
{
	class WebMethode
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<ParametreEntrant> parametreEntrant;
		public List<ParametreSortant> parametreSortant;
		public string Algorithme;

		#endregion

		#region Constructeur
		public WebMethode(string nom, string description, List<ParametreEntrant> parametreEntrant, List<ParametreSortant> parametreSortant, string algorithme)
		{
			this.Nom = nom;
			this.Description = description;
			this.parametreEntrant = parametreEntrant;
			this.parametreSortant = parametreSortant;
			this.Algorithme = algorithme;

		}

		#endregion

#region Méthodes

		/// <summary>
		/// Retourne une liste de noms des web méthodes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsWebMethodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNomsWebMethodes = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNomsWebMethodes.Add(isbn2.InnerText);
			}

			return ListeNomsWebMethodes;


		}

		/// <summary>
		/// Fonction qui permet de recuperer la liste des descriptions des web methodes
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsWebMethodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsWebMethodes = new List<string>();

			for (int i = 1; i < NombreWebMethodes(doc, nsmgr) + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsWebMethodes.Add(isbn2.InnerText);
				}
				
			}

			return ListeDescriptionsWebMethodes;
		}

		/// <summary>
		/// Retourne le nombre de web methodes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreWebMethodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsWebMethodes(doc, nsmgr).Count;
			return res;
		}

		/// <summary>
		/// Fonction qui permet de recuperer la liste des descriptions des web methodes
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> AlgorithmesWebMethodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeAlgorithmesWebMethodes = new List<string>();

			for (int i = 1; i < NombreWebMethodes(doc, nsmgr) + 1; i++)

			{	if (i < NombreWebMethodes(doc, nsmgr))
				{
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/preceding-sibling::w:p)]";


					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeAlgorithmesWebMethodes.Add(isbn2.InnerText);
					}
				}
				else
				{

					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/preceding-sibling::w:p)]";


					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeAlgorithmesWebMethodes.Add(isbn2.InnerText);
					}
				}
				

			}

			return ListeAlgorithmesWebMethodes;
		}

		/// <summary>
		/// Fonction qui permet de construire une web méthode
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<WebMethode> WebMethodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsWebMethodes(doc, nsmgr);
			List<WebMethode> webMethodes = new List<WebMethode>();
			List<string> descriptions = DescriptionsWebMethodes(doc, nsmgr);
			List<string> algorithmes = AlgorithmesWebMethodes(doc, nsmgr);
			List<List<ParametreEntrant>> parametresEntrants = ParametreEntrant.GetParametresEntrantsWebMethode(doc, nsmgr);
			List<List<ParametreSortant>> parametresSortants = ParametreSortant.GetParametresSortantsWebMethode(doc, nsmgr);
			for (int i = 0; i < noms.Count; i++)
			{
				webMethodes.Add(new WebMethode(noms[i], descriptions[i], parametresEntrants[i], parametresSortants[i], algorithmes[i]));

			}
			return webMethodes;

		}

		#endregion
	}
}
