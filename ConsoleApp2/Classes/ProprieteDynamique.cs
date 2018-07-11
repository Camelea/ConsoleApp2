using System;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ProprieteDynamique
	{
		#region Attributs 

		public string Nom;
		public List<TypeRetour> TypeRetour;
		public string Description;
		public string Algorithme;

		#endregion

		#region Constructeur

		/// <summary>
		/// Constructeur pour une propriété dynamique
		/// </summary>
		/// <param name="nom"></param>
		/// <param name="typesRetour"></param>
		/// <param name="description"></param>
		/// <param name="algorithme"></param>
		public ProprieteDynamique(string nom, List<TypeRetour> typesRetour, string description, string algorithme)
		{
			this.Nom = nom;
			this.TypeRetour = typesRetour;
			this.Description = description;
			this.Algorithme = algorithme;


		}
		#endregion

		#region Méthodes

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

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{
				List<string> ListeProprietesDynamiquesClasse = new List<string>();
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']] [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";


				string xpath2 = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/following :: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']] [count(. |  // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + 1 + "]/preceding::w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + 1 + "] /preceding::w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";

				string xpath3 = xpath + "[count(. |" + xpath2 + ")" + "= count(" + xpath2 + ")]";
				nodeList2 = root.SelectNodes(xpath3, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeProprietesDynamiquesClasse.Add(isbn2.InnerText);
				}
				ListeProprietesDynamiquesClasses.Add(ListeProprietesDynamiquesClasse);

			}

			return ListeProprietesDynamiquesClasses;


		}


		/// <summary>
		/// Retourne le nombre de proprietes dynamiques dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreProprietesDynamiques(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreProprietesDynamiquesClasses = new List<int>();
			foreach (List<string> liste in NomsProprietesDynamiquesClasses(doc, nsmgr))
			{
				NombreProprietesDynamiquesClasses.Add(liste.Count);

			}
			return NombreProprietesDynamiquesClasses;
		}


		/// <summary>
		/// retourne les descriptions des proprietes dynamiques des classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsProprietesDynamiquesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsProprietesDynamiquesClasse = new List<string>();
			
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)
			{

				if (NombreProprietesDynamiques(doc, nsmgr)[i-1] == 0)
				{

					ListeDescriptionsProprietesDynamiquesClasse.Add("None");


				}

				else
				{

					for (int cmp = 0; cmp < (NombreProprietesDynamiques(doc, nsmgr)[i-1] ); cmp++)
					{
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp +1) +"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] / following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp +1)+ "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeDescriptionsProprietesDynamiquesClasse.Add(isbn2.InnerText);
						}
						

					}
				}
				
			}

			return ListeDescriptionsProprietesDynamiquesClasse;


		}


		/// <summary>
		/// retourne les descriptions des proprietes dynamiques des classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> AlgorithmesProprietesDynamiquesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsProprietesDynamiquesClasse = new List<string>();
			
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)
			{

				if (NombreProprietesDynamiques(doc, nsmgr)[i - 1] == 0)
				{

					ListeDescriptionsProprietesDynamiquesClasse.Add("None");


				}

				else
				{

					for ( int cmp = 0; cmp < NombreProprietesDynamiques(doc, nsmgr)[i-1] ; cmp++)
					{
						if ((i < Classe.NombreClasses(doc, nsmgr) + 1 && cmp < NombreProprietesDynamiques(doc, nsmgr)[i-1]) || (i == Classe.NombreClasses(doc, nsmgr) + 1 && cmp < NombreProprietesDynamiques(doc, nsmgr)[i-1]))
						{
							
							string xpath2 = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1) + "]/following :: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3] /following-sibling:: w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+2)+"] / preceding-sibling::w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+2)+"] / preceding-sibling::w:p)]";

							var res = "";
							

							nodeList2 = root.SelectNodes(xpath2, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{
								res=res + (isbn2.InnerText);

								
							}
							ListeDescriptionsProprietesDynamiquesClasse.Add(res);
							


						}

						if (i < Classe.NombreClasses(doc, nsmgr) + 1 && cmp == NombreProprietesDynamiques(doc, nsmgr)[i-1])
						{


							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following :: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+cmp+1+"] /following :: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3] / following-sibling:: w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+(cmp+1)+"]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] / preceding-sibling::w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following::w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+(cmp+1)+"]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] / preceding-sibling::w:p)]";
							var res = "";
							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								res=res+ (isbn2.InnerText);
							}

							ListeDescriptionsProprietesDynamiquesClasse.Add(res);
						}



						if (i == Classe.NombreClasses(doc, nsmgr)  && cmp == NombreProprietesDynamiques(doc, nsmgr)[i - 1])
						{

							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3] / following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] / preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] / preceding-sibling::w:p)]";

							nodeList2 = root.SelectNodes(xpath, nsmgr);

							  foreach (XmlNode isbn2 in nodeList2)
							{

								ListeDescriptionsProprietesDynamiquesClasse.Add(isbn2.InnerText);
							}

						}

					}
				}
				
			}

			return ListeDescriptionsProprietesDynamiquesClasse;


		}
		#endregion


	}
}
