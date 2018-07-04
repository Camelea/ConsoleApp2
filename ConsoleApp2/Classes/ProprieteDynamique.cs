using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ProprieteDynamique
	{
		public string Nom;
		public List<TypeRetour> TypeRetour;
		public string Description;
		public string Algorithme;
	
/// <summary>
/// Constructeur pour une propriété dynamique
/// </summary>
/// <param name="nom"></param>
/// <param name="typesRetour"></param>
/// <param name="description"></param>
/// <param name="algorithme"></param>
	public ProprieteDynamique(string nom, List<TypeRetour> typesRetour, string description,string algorithme)
	{
		this.Nom = nom;
		this.TypeRetour = typesRetour;
		this.Description = description;
		this.Algorithme = algorithme;


	}

		/// <summary>
		/// Retourne la liste des noms des proprietes dynamiques des classes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsProprietesDynamiquesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeProprietesDynamiquesClasses = new List<List<string>>();
			var n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				List<string> ListeProprietesDynamiquesClasse = new List<string>();
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']] [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeProprietesDynamiquesClasse.Add(isbn2.InnerText);
				}
				ListeProprietesDynamiquesClasses.Add(ListeProprietesDynamiquesClasse);
				n++;
			}
			
			return ListeProprietesDynamiquesClasses;


		}


		/// <summary>
		/// Retourne le nombre de proprietes dynamiques dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreProprietesDynamiques(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsProprietesDynamiquesClasses(doc, nsmgr).Count;
			return res;
		}

		public static List<string> DescriptionsProprietesDynamiquesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeClassesTables = new List<string>();
			var n = 1;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++){

			var x = 1;
			for (int cmp = 1; cmp < NombreProprietesDynamiques(doc,nsmgr) + 1; cmp++)
				{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + x + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] / following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + x + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + n + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + x + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
					{
						ListeClassesTables.Add(isbn2.InnerText);
					}
				x++;
			}
				n++;
			}

			return ListeClassesTables;


		}




	}
}



