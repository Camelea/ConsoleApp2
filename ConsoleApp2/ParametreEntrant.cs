using ConsoleApp2.WebMethodes;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ParametreEntrant
	{
		#region Aattributs
		public string Nom;
		public string Type;
		public string Description;
		public string Obligatoire;

		#endregion

		#region Constructeur 
		public ParametreEntrant(string nom, string type, string description)
	{
		this.Nom = nom;
		this.Type = type;
		this.Description = description;

	}

		#endregion

		#region Methodes

		public override string ToString()
		{
			return (Nom + " " + Type);

		}
		#region Constructeur Par Defaut Classe 
		/// <summary>
		/// Renvoie la liste des informations de parametres entrants du constructeurs par defaut de chaque classe
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreEntrant>> GetParametresEntrantsConstructeurParDeafutClasse(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeConstructeursParDeafutClasses = new List<List<string>>();
			List<List<ParametreEntrant>> ListeParametresEntrantsConstructeursParDefautClasse = new List<List<ParametreEntrant>>();
			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{

				ListeConstructeursParDeafutClasses.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeConstructeursParDeafutClasses[i-1].Add(isbn2.InnerText);

				}
				ListeParametresEntrantsConstructeursParDefautClasse.Add(ListeAParametresEntrants(ListeConstructeursParDeafutClasses[i-1]));

			}
			return ListeParametresEntrantsConstructeursParDefautClasse;

		}

		#endregion

		#region Constructeurs D'initialisation Classe
		/// <summary>
		/// Renvoie la liste des informations de parametres entrants du constructeurs par defaut de chaque classe
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreEntrant>> GetParametresEntrantsConstructeurInitialisationClasse(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeConstructeursInitialisationClasse = new List<List<string>>();
			List<List<ParametreEntrant>> ListeParametresEntrantsConstructeursInitialisation = new List<List<ParametreEntrant>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{

				ListeConstructeursInitialisationClasse.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][5]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][6]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][6]/preceding-sibling::w:tbl / w:tr /w:tc)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeConstructeursInitialisationClasse[i-1].Add(isbn2.InnerText);

				}
				ListeParametresEntrantsConstructeursInitialisation.Add(ListeAParametresEntrantsObligatoire(ListeConstructeursInitialisationClasse[i-1]));

			}
			return ListeParametresEntrantsConstructeursInitialisation;

		}
		#endregion

		#region Liste à Objet
		/// <summary>
		/// Renvoie la liste des parametres entrants associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreEntrant> ListeAParametresEntrants(List<string> liste)
		{
			List<ParametreEntrant> ListeParametresEntrantsClasses = new List<ParametreEntrant>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresEntrantsClasses.Add(new ParametreEntrant(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresEntrantsClasses;
		}

		/// <summary>
		/// Renvoie la liste des parametres entrants associés à une liste donnée avec mention Obligatoire
		/// </summary>
		/// <returns></returns>
		public static List<ParametreEntrant> ListeAParametresEntrantsObligatoire(List<string> liste)
		{
			List<ParametreEntrant> ListeParametresEntrantsClasses = new List<ParametreEntrant>();
			for (int i = 4; i < liste.Count; i = i + 3)
			{
				ListeParametresEntrantsClasses.Add(new ParametreEntrant(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresEntrantsClasses;
		}

		#endregion

		#region Web Methodes 
		/// <summary>
		/// Renvoie la liste des informations de parametres entrants des web methodes
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<ParametreEntrant>> GetParametresEntrantsWebMethode(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeWebMethodes = new List<List<string>>();
			List<List<ParametreEntrant>> ListeParametresEntrantsWebMethodes = new List<List<ParametreEntrant>>();

			for (int i = 1; i < WebMethode.NombreWebMethodes(doc, nsmgr) + 1; i++)
			{

				ListeWebMethodes.Add(new List<string>());
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					if (isbn2.InnerText != "")
					{
						ListeWebMethodes[i-1].Add(isbn2.InnerText.Trim());
					}
				}
				ListeParametresEntrantsWebMethodes.Add(ListeAParametresEntrantsObligatoire(ListeWebMethodes[i-1]));

			}
			return ListeParametresEntrantsWebMethodes;

		}
		#endregion

		#endregion

	}
}





