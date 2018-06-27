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
		public override string ToString()
		{
			return (nom);
		}


		public static List<Sequence> GetSequencesTables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeSequencesTables = new List<string>();
			List<Sequence> ListeSequencesTables2 = new List<Sequence>();


			//nodeList2 = root.SelectNodes(" // w:p [ w:pPr / w:pStyle [@w:val='Heading2']] | // w:p  [ w:pPr / w:pStyle [@w:val='Heading2']] ", nsmgr);// 
			int n = 1;
			for (int i = 1; i < Table.NombreTables(doc, nsmgr) + 1; i++)

			{


				string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + n + "]/ following-sibling::w:tbl / w:tr /w:tc [count(. | //w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (n + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);
				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeSequencesTables.Add(isbn2.InnerText);
				}
				n = n + 6;
			}

			
			for (int i = 0; i < ListeSequencesTables.Count - 1; i++)
			{
				ListeSequencesTables2.Add(new Sequence(ListeSequencesTables[i + 1]));
			}
			

			while (ListeSequencesTables2.Count < Table.NombreTables(doc, nsmgr))
			{
				ListeSequencesTables2.Add(new Sequence("none"));
			}
			return ListeSequencesTables2;
		}
	}
}





