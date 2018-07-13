using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class Methode
	{
		#region Attributs

		public string Description;
		public List<ParametreEntrant> ParametresEntrants;
		public string Algorithme;
		public List<TypeRetour> TypesRetour;

		#endregion

		#region Constructeur 

		public Methode(string description, List<ParametreEntrant> parametresEntrants, string algorithme,List<TypeRetour> typesRetour)
		{
			this.Description = description;
			this.ParametresEntrants = parametresEntrants;
			this.Algorithme = algorithme;
			this.TypesRetour = typesRetour;

		}
		#endregion

		#region Méthodes
		/// <summary>
		/// Retourne la liste des noms des méthodes des classes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeMethodesClasses = new List<List<string>>();

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				List<string> ListeMethodesClasse = new List<string>();
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']] [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i +1) +"] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" +( i +1)+ "] /preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";


				string xpath2 = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following :: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']] [count(. |  // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + 1 + "]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + 1 + "] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";

				string xpath3 = xpath + "[count(. |" + xpath2 + ")" + "= count(" + xpath2 + ")]";
				nodeList2 = root.SelectNodes(xpath3, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeMethodesClasse.Add(isbn2.InnerText);
				}
				ListeMethodesClasses.Add(ListeMethodesClasse);

			}

			return ListeMethodesClasses;


		}


		/// <summary>
		/// Retourne le nombre de methodes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesClasse(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesClasses = new List<int>();
			foreach (List<string> liste in Methode.NomsMethodesClasses(doc, nsmgr))
			{
				NombreMethodesClasses.Add(liste.Count);

			}
			return NombreMethodesClasses;
		}

		/// <summary>
		/// retourne les descriptions des proprietes dynamiques des classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsMethodesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsMethodesClasse = new List<string>();

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)
			{

				if (NombreMethodesClasse(doc, nsmgr)[i - 1] == 0)
				{

					ListeDescriptionsMethodesClasse.Add("None");


				}

				else
				{

					for (int cmp = 0; cmp < (NombreMethodesClasse(doc, nsmgr)[i - 1]); cmp++)
					{
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] / following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeDescriptionsMethodesClasse.Add(isbn2.InnerText);
						}


					}
				}

			}

			return ListeDescriptionsMethodesClasse;


		}



		/// <summary>
		/// retourne les algorithmes des proprietes dynamiques des classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> AlgorithmesMethodesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsMethodesClasse = new List<string>();

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)
			{

				if (NombreMethodesClasse(doc, nsmgr)[i - 1] == 0)
				{

					ListeDescriptionsMethodesClasse.Add("None");


				}

				else
				{

					for (int cmp = 0; cmp < NombreMethodesClasse(doc, nsmgr)[i - 1]; cmp++)
					{
						if (i < Classe.NombreClasses(doc, nsmgr) + 1 && cmp < NombreMethodesClasse(doc, nsmgr)[i - 1]-1) 
						{

							string xpath2 = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following :: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4] /following-sibling:: w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "] / preceding-sibling::w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "] / preceding-sibling::w:p)]";

							var res = "";


							nodeList2 = root.SelectNodes(xpath2, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{
								res = res + (isbn2.InnerText);


							}
							ListeDescriptionsMethodesClasse.Add(res);



						}

						if (i < Classe.NombreClasses(doc, nsmgr) + 1 && cmp == NombreMethodesClasse(doc, nsmgr)[i - 1]-1)
						{


							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/following :: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + cmp + 1 + "] /following :: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4] / following-sibling:: w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/ preceding-sibling::w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] / preceding-sibling::w:p)]";
							var res = "";
							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								res = res + (isbn2.InnerText);
							}

							ListeDescriptionsMethodesClasse.Add(res);
						}



						if (i == Classe.NombreClasses(doc, nsmgr) && cmp == NombreMethodesClasse(doc, nsmgr)[i - 1]-1)
						{

							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4] / following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] / preceding-sibling::w:p)]";

							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeDescriptionsMethodesClasse.Add(isbn2.InnerText);
							}

						}

					}
				}

			}

			return ListeDescriptionsMethodesClasse;


		}





		#endregion
	}
}