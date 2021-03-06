﻿using System;
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

		/// <summary>
		/// Constructeur pour une table 
		/// </summary>
		/// <param name="nom"></param>
		/// <param name="colonnes"></param>
		/// <param name="contraintes"></param>
		/// <param name="donnees"></param>
		public Table(string nom, List<Colonne> colonnes,Contrainte contraintes,List<Donnee> donnees)
		{
			this.Nom = nom;
			this.Colonnes = colonnes;
			this.Contraintes = contraintes;
			this.Donnees = donnees;

		}

		/// <summary>
		/// Retourne une liste de noms des tables présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNomsTables = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading2']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading2']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNomsTables.Add(isbn2.InnerText);
			}

			return ListeNomsTables;


		}
		/// <summary>
		/// Retourne le nombre de tables dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			int res = NomsTables(doc, nsmgr).Count;
			return res;
		}



		/// <summary>
		/// Renvoie la liste des tables 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
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