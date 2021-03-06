﻿using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class TypeRetour
	{
		#region Attributs 

		public string Type;
		public string Description;

		#endregion

		#region Constructeur 

		public TypeRetour(string type, string description)
		{
			this.Type = type;
			this.Description = description;
		}

		#endregion

		#region Méthodes

		public  override string ToString()
		{
			return (this.Type + " " + this.Description);
		}

		/// <summary>
		/// retourne la liste des type de retour des proprietes dynamiques des classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<TypeRetour>> TypeRetourProprietesDynamiquesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeTypesRetourClasses = new List<List<string>>();
			List<List<TypeRetour>> TypesRetourClasses = new List<List<TypeRetour>>();
			
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)
			{

				if (ProprieteDynamique.NombreProprietesDynamiques(doc, nsmgr)[i - 1] != 0)
				{
					
					for (int cmp = 0; cmp < ProprieteDynamique.NombreProprietesDynamiques(doc, nsmgr)[i-1]; cmp++)
				{

						ListeTypesRetourClasses.Add(new List<string>());
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / following-sibling::w:tbl / w:tr /w:tc   [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3] / preceding-sibling::w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3] / preceding-sibling::w:tbl / w:tr /w:tc )]";


					nodeList2 = root.SelectNodes(xpath, nsmgr);
						
						foreach (XmlNode isbn2 in nodeList2)
					{
							
						ListeTypesRetourClasses[cmp].Add(isbn2.InnerText);
					}
						TypesRetourClasses.Add(ListeATypeRetour(ListeTypesRetourClasses[cmp]));
						
					}

			}
		}
			return TypesRetourClasses;

		}


		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de " type de retour "
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<TypeRetour> ListeATypeRetour(List<string> liste)
		{
			List<TypeRetour> ListeClesPrimaireTables = new List<TypeRetour>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeClesPrimaireTables.Add(new TypeRetour(liste[i], liste[i + 1]));
			}
			return ListeClesPrimaireTables;
		}

		/// <summary>
		/// retourne la liste des type de retour des proprietes dynamiques des classes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<TypeRetour>> TypeRetourMethodesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeTypesRetourClasses = new List<List<string>>();
			List<List<TypeRetour>> TypesRetourClasses = new List<List<TypeRetour>>();

			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)
			{

				if (Methode.NombreMethodesClasse(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesClasse(doc, nsmgr)[i - 1]; cmp++)
					{

						ListeTypesRetourClasses.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3] / following-sibling:: w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4] / preceding-sibling::w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeTypesRetourClasses[cmp].Add(isbn2.InnerText);
						}
						TypesRetourClasses.Add(ListeATypeRetour(ListeTypesRetourClasses[cmp]));

					}

				}
			}
			return TypesRetourClasses;

		}
		#endregion




	}
}