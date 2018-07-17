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
		#region Attributs

		public string Nom;
		public List<Attribut> Attributs;
		public Constructeur Constructeurs;
		public List<ProprieteDynamique> ProprietesDynamiques;
		public List<Methode> Methodes;

		#endregion

		#region Constructeur 

		public Classe(string nom, List<Attribut> attributs, Constructeur constructeurs, List<ProprieteDynamique> proprietesDynamiques, List<Methode> methodes)
		{
			this.Nom = nom;
			this.Attributs = attributs;
			this.Constructeurs = constructeurs;
			this.ProprietesDynamiques = proprietesDynamiques;
			this.Methodes = methodes;
		}
		public Classe(string nom, List<Attribut> attributs, Constructeur constructeurs)
		{
			this.Nom = nom;
			this.Attributs = attributs;
			this.Constructeurs = constructeurs;

		}

		public Classe(string nom, List<Attribut> attributs, Constructeur constructeurs, List<ProprieteDynamique> proprietesDynamiques)
		{
			this.Nom = nom;
			this.Attributs = attributs;
			this.Constructeurs = constructeurs;
			this.ProprietesDynamiques = proprietesDynamiques;
		}

		public Classe(string nom, List<Attribut> attributs, Constructeur constructeurs,  List<Methode> methodes)
		{
			this.Nom = nom;
			this.Attributs = attributs;
			this.Constructeurs = constructeurs;
			this.Methodes = methodes;
		}




		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (Nom );
		}

		/// <summary>
		/// Retourne la liste de noms des classes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeClasses = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeClasses.Add(isbn2.InnerText);
			}

			return ListeClasses;


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

		public static List<Classe> Classes (XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Classe> classes = new List<Classe>();
			List<string> noms = NomsClasses(doc, nsmgr);
			List<List<Attribut>> attributs = Attribut.GetAttributsClasses(doc, nsmgr);
			List<Constructeur> constructeurs = Constructeur.Constructeurs(doc, nsmgr);
			List<List<Methode>> methodes = Methode.Methodes(doc, nsmgr);
			List<List<ProprieteDynamique>> proprietesDynamiques = ProprieteDynamique.ProprietesDynamiques(doc, nsmgr);

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)
			{
				 if (ProprieteDynamique.NombreProprietesDynamiques(doc, nsmgr)[i - 1] == 0 && Methode.NombreMethodesClasse(doc, nsmgr)[i - 1] == 0)
				{
				classes.Add(new Classe(noms[i - 1], attributs[i - 1], constructeurs[i - 1]));

				}

				if (ProprieteDynamique.NombreProprietesDynamiques(doc, nsmgr)[i - 1] != 0 && Methode.NombreMethodesClasse(doc, nsmgr)[i - 1] != 0)
				{

					classes.Add(new Classe(noms[i - 1], attributs[i - 1], constructeurs[i - 1], proprietesDynamiques[i - 1], methodes[i - 1]));
				}

				if (ProprieteDynamique.NombreProprietesDynamiques(doc, nsmgr)[i - 1] != 0 && Methode.NombreMethodesClasse(doc, nsmgr)[i - 1] == 0)
				{

					classes.Add(new Classe(noms[i - 1], attributs[i - 1], constructeurs[i - 1], proprietesDynamiques[i - 1]));
				}

				 if (ProprieteDynamique.NombreProprietesDynamiques(doc, nsmgr)[i - 1] == 0 && Methode.NombreMethodesClasse(doc, nsmgr)[i - 1] != 0)
				{

					classes.Add(new Classe(noms[i - 1], attributs[i - 1], constructeurs[i - 1], methodes[i - 1]));
				}


			}
			return classes;

		}
		#endregion
	}
}

