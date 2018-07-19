using ConsoleApp2.ServicesExternes;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.WebMethodes
{
	/// <summary>
	/// Classe qui permet de crée et récupérér les Parametres Sortants
	/// </summary>
	public class ParametreSortant
	{
		#region Attributs
		public string Type;
		public string Description;
		#endregion

		#region Constructeur

		public ParametreSortant(string type, string description)
		{
			this.Type = type;
			this.Description = description;

		}
		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Type + " " + this.Description);

		}
		#region Web Methodes
		/// <summary>
		/// Renvoie la liste des informations de parametres sortants des web methodes
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreSortant>> GetParametresSortantsWebMethode(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeWebMethodes = new List<List<string>>();
			List<List<ParametreSortant>> ListeParametresSortantsWebMethodes = new List<List<ParametreSortant>>();

			for (int i = 1; i < WebMethode.NombreWebMethodes(doc, nsmgr) + 1; i++)
			{

				ListeWebMethodes.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{

						ListeWebMethodes[(i-1)].Add(isbn2.InnerText.Trim());
					
				}
				ListeParametresSortantsWebMethodes.Add(ListeAParametresSortants(ListeWebMethodes[(i-1)]));

			}
			return ListeParametresSortantsWebMethodes;

		}
		#endregion

		#region Services Externes 

		/// <summary>
		/// Renvoie la liste des informations de parametres sortants des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreSortant>> GetParametresSortantsServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeServicesExternes = new List<List<string>>();
			List<List<ParametreSortant>> ListeParametresSortantsServicesExternes = new List<List<ParametreSortant>>();
			var x = 0;
			for (int i = 2; i < ServiceExterne.NombreServicesExternes(doc, nsmgr) + 2; i++)
			{
				
					for (int cmp = 0; cmp < MethodeServiceExterne.NombreMethodesServicesExternes(doc, nsmgr)[i-2]; cmp++)
					{

						ListeServicesExternes.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3] / following-sibling::w:tbl/w:tr/w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4] / preceding-sibling::w:tbl/w:tr/w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (cmp + 1) + "]  /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][4] / preceding-sibling::w:tbl/w:tr/w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);


					foreach (XmlNode isbn2 in nodeList2)
					{

						ListeServicesExternes[x].Add(isbn2.InnerText);

						}
						ListeParametresSortantsServicesExternes.Add(ListeAParametresSortants(ListeServicesExternes[x]));
					x++;
					}
					

				

					
				}
			
					return ListeParametresSortantsServicesExternes;

				}
			


		#endregion

		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de parametres sortants
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ParametreSortant> ListeAParametresSortants(List<string> liste)
		{
			List<ParametreSortant> ListeParametresSortantsWebMethode = new List<ParametreSortant>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeParametresSortantsWebMethode.Add(new ParametreSortant(liste[i], liste[i + 1]));
			}
			return ListeParametresSortantsWebMethode;
		}






		#endregion


	}
}