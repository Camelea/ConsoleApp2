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
		public List<MethodeServiceExterne> Methodes;

		#endregion

		#region Constructeur
		public ServiceExterne(string nom, List<MethodeServiceExterne> methodes)
		{
			this.Nom = nom;
			this.Methodes = methodes;

		}
		#endregion

		#region Méthodes

		public override string ToString()
		{
			var res = "";
			foreach (MethodeServiceExterne methode in this.Methodes)
			{
				res = res + "\n" + methode.ToString();
			}

			return (this.Nom + " " + res);
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

	

		#endregion
	}
}
