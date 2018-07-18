using ConsoleApp2.ClassesPresentation;
using ConsoleApp2.Objets_Parametres;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class Attribut
	{
		#region Attributs
		public string Nom;
		public string Type;
		public string Description
		{
			get;
			set;
		}
		#endregion

		#region Constructeur
		public Attribut(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;

		}
		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (Nom + " " + Type);

		}
		#region Classe

		/// <summary>
		/// Renvoie la liste des informaions de colonnes de chaque table
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Attribut>> GetAttributsClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeinformationsAttributsClasses = new List<List<string>>();
			List<List<Attribut>> ListeAttributsClasses = new List<List<Attribut>>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 1;
			int x = 0;
			for (int i = 1; i < Classe.NombreClasses(doc, nsmgr) + 1; i++)

			{

				ListeinformationsAttributsClasses.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (n + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
			{
					ListeinformationsAttributsClasses[x].Add(isbn2.InnerText);

				}
				ListeAttributsClasses.Add(ListeAAttributs(ListeinformationsAttributsClasses[x]));
				n = n + 4;
				x++;
			}
			return ListeAttributsClasses;

		}

		/// <summary>
		/// Renvoie la liste des attributs associés à une classe donnée
		/// </summary>
		/// <returns></returns>
		public static List<Attribut> ListeAAttributs(List<string> liste)
		{
			List<Attribut> ListeAttributsTable = new List<Attribut>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeAttributsTable.Add(new Attribut(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeAttributsTable;
		}
		#endregion

		#region Objets Parametre 

		/// <summary>
		/// Renvoie la liste des attributs de tous les objets parametre du fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Attribut>> AttributsObjetsParametres(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeinformationsAttributsObjetsParametres = new List<List<string>>();
			List<List<Attribut>> ListeAttributsClasses = new List<List<Attribut>>();


			for (int i = 1; i < ObjetParametre.NombreClassesPresentation(doc, nsmgr) + 1; i++)

			{

				ListeinformationsAttributsObjetsParametres.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeinformationsAttributsObjetsParametres[i-1].Add(isbn2.InnerText);

				}
				ListeAttributsClasses.Add(ListeAAttributs(ListeinformationsAttributsObjetsParametres[i-1]));

			}
			return ListeAttributsClasses;

		}






		#endregion


		#region ClassePresentation

		/// <summary>
		/// Renvoie la liste des attributs de tous les objets parametre du fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Attribut>> AttributsClassePresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeinformationsAttributsClassesPresentation = new List<List<string>>();
			List<List<Attribut>> ListeAttributsClassesPresentation = new List<List<Attribut>>();


			for (int i = 1; i < ClassePresentation.NombreClassesPresentation(doc, nsmgr) + 1; i++)

			{

				ListeinformationsAttributsClassesPresentation.Add(new List<string>());
				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";


				nodeList2 = root.SelectNodes(xpath, nsmgr);


				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeinformationsAttributsClassesPresentation[i - 1].Add(isbn2.InnerText);

				}
				ListeAttributsClassesPresentation.Add(ListeAAttributs(ListeinformationsAttributsClassesPresentation[i - 1]));

			}
			return ListeAttributsClassesPresentation;

		}






		#endregion

		#endregion


	}
}