using ConsoleApp2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.ClassesPresentation
{
	class ClassePresentation
	{
		#region Attributs
		public string Nom;
		public string Description;
		public List<Attribut> Attributs;
		#endregion

		#region Constructeur
		public ClassePresentation(string nom, string description, List<Attribut> attributs)
		{
			this.Nom = nom;
			this.Description = description;
			this.Attributs = attributs;
		}


		#endregion

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		#region Méthodes

		/// <summary>
		/// Retourne une liste de noms des classes de presentation dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsClassesPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNomsClassesPresentation = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNomsClassesPresentation.Add(isbn2.InnerText);
			}

			return ListeNomsClassesPresentation;


		}

		/// <summary>
		/// Retourne le nombre de classes de presentation dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreClassesPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsClassesPresentation(doc, nsmgr).Count;
			return res;
		}


		/// <summary>
		/// Fonction qui permet de recuperer la liste des descriptions des classes de presentation
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsClassesPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsClassesPresentation = new List<string>();

			for (int i = 1; i < NombreClassesPresentation(doc, nsmgr) + 1; i++)

			{
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				ListeDescriptionsClassesPresentation.Add(res);
			}
			return ListeDescriptionsClassesPresentation;
		}


		/// <summary>
		/// Fonction qui permet de retourner la liste des classes  de presentation du fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ClassePresentation> ClassesPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsClassesPresentation(doc, nsmgr);
			List<ClassePresentation> classesPresentation = new List<ClassePresentation>();
			List<string> descriptions = DescriptionsClassesPresentation(doc, nsmgr);
			List<List<Attribut>> attributs = Attribut.AttributsClassePresentation(doc, nsmgr);
			for (int i = 0; i < noms.Count; i++)
			{
				classesPresentation.Add(new ClassePresentation(noms[i], descriptions[i], attributs[i]));

			}
			return classesPresentation;

		}

		#endregion
	}
}
