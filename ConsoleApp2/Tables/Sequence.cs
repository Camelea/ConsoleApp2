using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Sequence
	{
		public string nom { get; set; }
		public Sequence(string nom)
		{
			this.nom = nom;
		}

		public static List<Sequence> GetSequencesTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			//List<Sequence> ListeColonnesTables2 = new List<Sequence>();
			List<Sequence> ListeColonnesTables2 = new List<Sequence>();

			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 1;
			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)
			{

				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				{
					ListeColonnesTables2.Add(new Sequence(nodeList2[1].InnerText));

				}
				n = n + 6;
			}
			return ListeColonnesTables2;

		}

	}
}