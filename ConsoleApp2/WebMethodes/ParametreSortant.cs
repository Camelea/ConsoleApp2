using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.WebMethodes
{
	/// <summary>
	/// Classe qui permet de crée et récupérér les Paraletres Sortants d'une web méthode
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