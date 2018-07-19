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
	class MethodeServiceExterne
	{
		#region Attributs

		public string Description;
		public List<ParametreEntrant> parametreEntrant;
		public List<ParametreSortant> parametreSortant;
		public string Algorithme;

		#endregion

		#region Constructeur 
		public MethodeServiceExterne(string description, List<ParametreEntrant> parametreEntrant, List<ParametreSortant> parametreSortant, string algorithme)
		{
			this.Description = description;
			this.parametreEntrant = parametreEntrant;
			this.parametreSortant = parametreSortant;
			this.Algorithme = algorithme;

		}



		#endregion

		#region Méthodes

		public override string ToString()
		{
			return ( this.Algorithme);
		}

		/// <summary>
		/// Retourne la liste des noms des proprietes dynamiques des classes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeProprietesDynamiquesClasses = new List<List<string>>();

			for (int i = 2; i < ServiceExterne.NombreServicesExternes(doc, nsmgr) + 2; i++)

			{
				if (i < ServiceExterne.NombreServicesExternes(doc, nsmgr) + 1)
				{
					List<string> ListeProprietesDynamiquesClasse = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']] [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] /preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeProprietesDynamiquesClasse.Add(isbn2.InnerText);
					}
					ListeProprietesDynamiquesClasses.Add(ListeProprietesDynamiquesClasse);

				}

				if (i == ServiceExterne.NombreServicesExternes(doc, nsmgr) + 1)
				{
					List<string> ListeProprietesDynamiquesClasse = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']] [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8]  / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8]  /preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeProprietesDynamiquesClasse.Add(isbn2.InnerText);
					}
					ListeProprietesDynamiquesClasses.Add(ListeProprietesDynamiquesClasse);

				}
			}

			return ListeProprietesDynamiquesClasses;


		}

		/// <summary>
		/// retourne les descriptions des proprietes dynamiques des classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsProprietesDynamiquesClasse = new List<string>();

			for (int i = 2; i < ServiceExterne.NombreServicesExternes(doc, nsmgr) + 2; i++)
			{

				if (NombreMethodesServicesExternes(doc, nsmgr)[i - 2] == 0)
				{

					ListeDescriptionsProprietesDynamiquesClasse.Add("None");


				}

				else
				{

					for (int cmp = 0; cmp < (NombreMethodesServicesExternes(doc, nsmgr)[i - 2]); cmp++)
					{
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2] / preceding-sibling::w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeDescriptionsProprietesDynamiquesClasse.Add(isbn2.InnerText);
						}


					}
				}

			}

			return ListeDescriptionsProprietesDynamiquesClasse;


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

			for (int i = 2; i < ServiceExterne.NombreServicesExternes(doc, nsmgr) + 2; i++)

			{
				if (NombreMethodesServicesExternes(doc, nsmgr)[i - 2] == 0)
				{

					ListeAlgorithmesServicesExternes.Add("None");


				}
				else
				{

					for (int cmp = 0; cmp < (NombreMethodesServicesExternes(doc, nsmgr)[i - 2]); cmp++)

						if (i < ServiceExterne.NombreServicesExternes(doc, nsmgr))
						{
							var res = "";
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/preceding-sibling::w:p)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{
								res = res + (isbn2.InnerText);
							}
							ListeAlgorithmesServicesExternes.Add(res);
						}
						else
						{
							var res = "";
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][8]/preceding-sibling::w:p)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{
								res = res + (isbn2.InnerText);
							}
							ListeAlgorithmesServicesExternes.Add(res);
						}


				}
			}
				return ListeAlgorithmesServicesExternes;
			
		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque service externe 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesServicesExternes = new List<int>();
			foreach (List<string> liste in NomsMethodesServicesExternes(doc, nsmgr))
			{
				NombreMethodesServicesExternes.Add(liste.Count);

			}
			return NombreMethodesServicesExternes;
		}


		/// <summary>
		/// Fonction qui retourne la liste des services externes presents dans le fichier
		/// </summary>
		/// <param name = "doc" ></ param >
		/// < param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<MethodeServiceExterne>> MethodesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			List<List<MethodeServiceExterne>> servicesExternes = new List<List<MethodeServiceExterne>>();
			List<string> descriptions = DescriptionsServicesExternes(doc, nsmgr);
			List<string> algorithmes = AlgorithmesServicesExternes(doc, nsmgr);
			List<List<ParametreEntrant>> parametresEntrants = ParametreEntrant.GetParametresEntrantsServiceExterne(doc, nsmgr);
			List<List<ParametreSortant>> parametresSortants = ParametreSortant.GetParametresSortantsServiceExterne(doc, nsmgr);
			for (int i = 2; i < ServiceExterne.NombreServicesExternes(doc, nsmgr) + 2; i++)
			{
				if (NombreMethodesServicesExternes(doc, nsmgr)[i - 2] != 0)
				{
					List<MethodeServiceExterne> MethodesServiceExterne = new List<MethodeServiceExterne>();

					for (int cmp = 0; cmp < NombreMethodesServicesExternes(doc, nsmgr)[i - 2]; cmp++)
					{

						MethodesServiceExterne.Add(new MethodeServiceExterne( descriptions[cmp], parametresEntrants[cmp], parametresSortants[cmp],algorithmes[cmp]));

					}
					servicesExternes.Add(MethodesServiceExterne);
				}




			}
			return servicesExternes;
		}


		#endregion


	}
}