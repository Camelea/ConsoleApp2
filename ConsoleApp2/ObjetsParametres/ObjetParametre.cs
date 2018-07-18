using ConsoleApp2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.Objets_Parametres
{
	class ObjetParametre
	{
		#region Attributs
		public string Nom;
		public string Description;
		public List<Attribut> Attributs;
		#endregion

		#region Constructeur
		public ObjetParametre(string nom, string description, List<Attribut> attributs)
		{
			this.Nom = nom;
			this.Description = description;
			this.Attributs = attributs;
		}


		#endregion

		#region Méthodes

		/// <summary>
		/// Retourne une liste de noms des objets de presentation dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsObjetsParametre (XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNomsObjetsParametre = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNomsObjetsParametre.Add(isbn2.InnerText);
			}

			return ListeNomsObjetsParametre;


		}

		/// <summary>
		/// Retourne le nombre de objets parametre dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreObjetsParametre(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsObjetsParametre(doc, nsmgr).Count;
			return res;
		}


		/// <summary>
		/// Fonction qui permet de recuperer la liste des descriptions des objets parametre
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsObjetsParametre(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsObjetsParametres = new List<string>();

			for (int i = 1; i < NombreObjetsParametre(doc, nsmgr) + 1; i++)

			{
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][1]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				ListeDescriptionsObjetsParametres.Add(res);
			}
			return ListeDescriptionsObjetsParametres;
		}




		#endregion



	}
}
