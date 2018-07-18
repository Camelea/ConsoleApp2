using ConsoleApp2.Classes;
using ConsoleApp2.WebMethodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.ServicesExternes
{
	class ServiceExterne
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<ParametreEntrant> parametreEntrant;
		public List<ParametreSortant> parametreSortant;
		public string Algorithme;

		#endregion

		#region Constructeur
		public ServiceExterne(string nom, string description, List<ParametreEntrant> parametreEntrant, List<ParametreSortant> parametreSortant, string algorithme)
		{
			this.Nom = nom;
			this.Description = description;
			this.parametreEntrant = parametreEntrant;
			this.parametreSortant = parametreSortant;
			this.Algorithme = algorithme;

		}
		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (this.Nom + " " + this.Description + " " + this.Algorithme);
		}
		/// <summary>
		/// Retourne une liste de noms des services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNomsServicesExternes = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNomsServicesExternes.Add(isbn2.InnerText);
			}

			ListeNomsServicesExternes.RemoveAt(0);

			return ListeNomsServicesExternes;

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

			for (int i = 2; i < NombreServicesExternes(doc, nsmgr) + 2; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsWebMethodes.Add(isbn2.InnerText);
				}

			}

			return ListeDescriptionsWebMethodes;
		}

		/// <summary>
		/// Retourne le nombre de services externes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsServicesExternes(doc, nsmgr).Count;
			return res;
		}

		/// <summary>
		/// Fonction qui permet de recuperer la liste des descriptions des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> AlgorithmesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeAlgorithmesServicesExternes = new List<string>();

			for (int i = 2; i < NombreServicesExternes(doc, nsmgr) + 2; i++)

			{
				if (i < NombreServicesExternes(doc, nsmgr))
				{
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/preceding-sibling::w:p)]";


					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeAlgorithmesServicesExternes.Add(isbn2.InnerText);
					}
				}
				else
				{

					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8]/preceding-sibling::w:p)]";


					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeAlgorithmesServicesExternes.Add(isbn2.InnerText);
					}
				}


			}

			return ListeAlgorithmesServicesExternes;
		}

		/// <summary>
		/// Fonction qui retourne la liste des services externes presents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ServiceExterne> ServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsServicesExternes(doc, nsmgr);
			List<ServiceExterne> servicesExternes = new List<ServiceExterne>();
			List<string> descriptions = DescriptionsWebMethodes(doc, nsmgr);
			List<string> algorithmes = AlgorithmesServicesExternes(doc, nsmgr);
			List<List<ParametreEntrant>> parametresEntrants = ParametreEntrant.GetParametresEntrantsServiceExterne(doc, nsmgr);
			List<List<ParametreSortant>> parametresSortants = ParametreSortant.GetParametresSortantsServiceExterne(doc, nsmgr);
			for (int i = 0; i < noms.Count; i++)
			{
				servicesExternes.Add(new ServiceExterne(noms[i], descriptions[i], parametresEntrants[i], parametresSortants[i], algorithmes[i]));

			}
			return servicesExternes;

		}

		#endregion
	}
}
