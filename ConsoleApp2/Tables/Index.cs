using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Index
	{

			public string nom;
			public string colonne;


			public Index(string nom, string colonne)
			{
				this.nom = nom;
				this.colonne = colonne;

			}
			public override string ToString()
			{
				return (this.nom + " " + this.colonne); //temporaire à regkler plus tard 
			}

			public static List<List<Index>> GetIndexTables(XmlDocument doc, XmlNamespaceManager nsmgr)
			{
				XmlNodeList nodeList2;
				XmlElement root = doc.DocumentElement;
				List<List<string>> ListeIndexesTables = new List<List<string>>();
				List<List<Index>> ListeIndexesTables2 = new List<List<Index>>();


				//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
				int n = 6;
				int x = 0;
				for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

				{

				ListeIndexesTables.Add(new List<string>());
					string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+"] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/preceding-sibling::w:tbl / w:tr /w:tc)]";
					nodeList2 = root.SelectNodes(xpath, nsmgr);


					foreach (XmlNode isbn2 in nodeList2)
					{
					ListeIndexesTables[x].Add(isbn2.InnerText);

					}
				ListeIndexesTables2.Add(ListeAIndex(ListeIndexesTables[x]));
					n = n + 6;
					x++;
				}
				return ListeIndexesTables2;

			}


			/// <summary>
			/// Fonction qui prend une liste de string et la transforme en liste de contraintes non nulles
			/// 
			/// </summary>
			/// <param name="liste"></param>
			/// <returns></returns>
			public static List<Index> ListeAIndex(List<string> liste)
			{
				List<Index> ListeIndexesTables = new List<Index>();
				for (int i = 2; i < liste.Count; i = i + 2)
				{
				ListeIndexesTables.Add(new Index(liste[i], liste[i + 1]));
				}
				return ListeIndexesTables;
			}
		}
	}
