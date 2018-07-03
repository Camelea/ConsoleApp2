using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.Classes
{

	internal class Classe
	{
		public string Nom;
		public List<Attribut> Attributs;
		public List<Constructeur> Constructeurs;
		public List<ProprieteDynamique> ProprietesDynamiques;
		public List<Methode> Methodes;

		public Classe(string nom, List<Attribut> attributs, List<Constructeur> constructeurs, List<ProprieteDynamique> proprietesDynamiques, List<Methode> methodes)
		{
			this.Nom = nom;
			this.Attributs = attributs;
			this.Constructeurs = constructeurs;
			this.ProprietesDynamiques = proprietesDynamiques;
			this.Methodes = methodes;
		}

		/// <summary>
		/// Retourne une liste de noms des classes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeClassesTables = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeClassesTables.Add(isbn2.InnerText);
			}

			return ListeClassesTables;


		}

		/// <summary>
		/// Retourne le nombre de classes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsClasses(doc, nsmgr).Count;
			return res;
		}
	}
}

