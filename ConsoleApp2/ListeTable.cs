//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//namespace ConsoleApp2.Tables
//{
//	class ParserTable
//	{


//		private string docpath;





//		public List<string> NomColonnes(XmlDocument doc, XmlNamespaceManager nsmgr)
//		{

//			XmlNodeList nodeList2;
//			XmlElement root = doc.DocumentElement;
//			List<string> ListeTables = new List<string>();
//			List<string> NomsColonnes = new List<string>();

//			nodeList2 = root.SelectNodes("  // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading3']] | // w:p  [ w:pPr / w:pStyle [@w:val='Paragraphe']] | // w:p  [ w:pPr / w:pStyle [@w:val='NoSpacing']] ", nsmgr);
//			foreach (XmlNode isbn2 in nodeList2)
//			{
//				if (isbn2.InnerText != "")
//					ListeTables.Add(isbn2.InnerText.Trim());
//			}
//			foreach (string elem in ListeTables)
//			{

//				int i = ListeTables.IndexOf("Contraintes");
//				int i2 = ListeTables.IndexOf("Nom");
//				for (int n = i2 + 3; n < i; n = n + 3)
//				{
//					NomsColonnes.Add(ListeTables[n]);
//				}



//			}
//			return NomsColonnes;

//		}

//		public List<string> TypeColonnes(XmlDocument doc, XmlNamespaceManager nsmgr)
//		{

//			XmlNodeList nodeList2;
//			XmlElement root = doc.DocumentElement;
//			List<string> ListeTables = new List<string>();
//			List<string> TypeColonnes = new List<string>();

//			nodeList2 = root.SelectNodes("  // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading3']] | // w:p  [ w:pPr / w:pStyle [@w:val='Paragraphe']] | // w:p  [ w:pPr / w:pStyle [@w:val='NoSpacing']] ", nsmgr);
//			foreach (XmlNode isbn2 in nodeList2)
//			{
//				if (isbn2.InnerText != "")
//					ListeTables.Add(isbn2.InnerText.Trim());
//			}
//			foreach (string elem in ListeTables)
//			{

//				int i = ListeTables.IndexOf("Contraintes");
//				int i2 = ListeTables.IndexOf("Nom");
//				for (int n = i2 + 3; n < i; n = n + 3)
//				{
//					TypeColonnes.Add(ListeTables[n]);
//				}



//			}
//			return TypeColonnes;

//		}

//		public List<string> DescriptionColonnes(XmlDocument doc, XmlNamespaceManager nsmgr)
//		{

//			XmlNodeList nodeList2;
//			XmlElement root = doc.DocumentElement;
//			List<string> ListeTables = new List<string>();
//			List<string> DescriptionTables = new List<string>();

//			nodeList2 = root.SelectNodes("  // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading3']] | // w:p  [ w:pPr / w:pStyle [@w:val='Paragraphe']] | // w:p  [ w:pPr / w:pStyle [@w:val='NoSpacing']] ", nsmgr);
//			foreach (XmlNode isbn2 in nodeList2)
//			{
//				if (isbn2.InnerText != "")
//					ListeTables.Add(isbn2.InnerText.Trim());
//			}
//			foreach (string elem in ListeTables)
//			{

//				int i = ListeTables.IndexOf("Contraintes");
//				int i2 = ListeTables.IndexOf("Nom");
//				for (int n = i2 + 3; n < i; n = n + 3)
//				{
//					DescriptionTables.Add(ListeTables[n]);
//				}



//			}
//			return DescriptionTables;

//		}


//		public List<Colonne> Colonnes(List<string> noms, List<string> types, List<string> descriptions)
//		{
//			List<Colonne> colonnes = new List<Colonne>();
//			for (int i = 0; i < (noms.Count() - 1); i++)
//			{
//				colonnes.Add(new Colonne()
//				{
//					nom = noms[i],
//					type = types[i],
//					description = descriptions[i]

//				});



//			}
//			return colonnes;
//		}

//		Renvoie la liste des séquences de toutes les tables et pas de séquence si il n y en a pas
//		public List<Sequence> ListesSequences(XmlDocument doc, XmlNamespaceManager nsmgr)
//		{
//			//Select and display the value of all the ISBN attributes.

//			XmlNodeList nodeList2;
//			XmlElement root = doc.DocumentElement;
//			//nodeList = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading1']]   ", nsmgr);
//			List<string> ListeTables = new List<string>();
//			List<Sequence> sequences = new List<Sequence>();

//			//foreach (XmlNode isbn in nodeList)

//			nodeList2 = root.SelectNodes("  // w:p  [ w:pPr / w:pStyle [@w:val='Heading4']]|  // w:tbl / w:tr / w:tc / w:p ", nsmgr);
//			foreach (XmlNode isbn2 in nodeList2)
//			{
//				if (isbn2.InnerText != "")
//					ListeTables.Add(isbn2.InnerText.Trim());
//			}
//			//Console.WriteLine(nodeList2[0].InnerText);
//			for (int elem = 0; elem < ListeTables.Count; elem++)
//			{
//				if (ListeTables[elem] == "Séquence")
//				{
//					if ((ListeTables[elem + 2]) == "Clés étrangères")
//					{
//						sequences.Add("pas de séquence");

//					}
//					else
//					{
//						Console.WriteLine((ListeTables[elem + 2]));
//					}
//				}
//			}
//		}
//	}
//}




