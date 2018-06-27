using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Table
	{
		public String Nom { get; set; }
		public List<Colonne> Colonnes { get; set; }
		public Contrainte Contraintes { get; set; }
		public List<Donnee> Donnees { get; set; }


		public Table(string Nom, List<Colonne> Colonnes,Contrainte Contraintes,List<Donnee> donnees)
		{
			this.Nom = Nom;
			this.Colonnes = Colonnes;
			this.Contraintes = Contraintes;
			this.Donnees = donnees;

		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeTables = new List<string>();
			List<string> ListeTables2 = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeTables2.Add(isbn2.InnerText);
			}

			return ListeTables2;


		}
		/// <summary>
		/// Retourne le nombre de tables dans la classe 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsTables(doc, nsmgr).Count();
			return res;
		}

		public static List<Table> Tables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsTables(doc, nsmgr);
			List<List<Colonne>> colonnes = Colonne.GetColonnesTables(doc, nsmgr);
			List<Contrainte> contraintes = Contrainte.Contraintes(doc, nsmgr);
			List<Table> tables = new List<Table>();
			List<List<Donnee>> donnees = Donnee.GetDonneesTables(doc, nsmgr);

			for (int i = 0; i < NombreTables(doc, nsmgr); i++)
			{
				tables.Add(new Table(noms[i], colonnes[i],contraintes[i],donnees[i]));

			}
			return tables;

		}
	}
}