
using ConsoleApp2.Classes;
using ConsoleApp2.Tables;
using ConsoleApp2.WebMethodes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
namespace ConsoleApp2
{
	public class Program
	{


		public static void Main(string[] args)
		{


			XmlDocument doc = new XmlDocument();
			//doc.Load("C:\\Users\\CameleaOUARKOUB\\Pictures\\Exemple2.xml");
			doc.Load("C:\\Users\\CameleaOUARKOUB\\Desktop\\document.xml");
			


			//Create an XmlNamespaceManager for resolving namespaces.
			XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
			nsmgr.AddNamespace("wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
			nsmgr.AddNamespace("cx", "http://schemas.microsoft.com/office/drawing/2014/chartex");
			nsmgr.AddNamespace("cx1", "http://schemas.microsoft.com/office/drawing/2015/9/8/chartex");
			nsmgr.AddNamespace("cx2", "http://schemas.microsoft.com/office/drawing/2015/10/21/chartex");
			nsmgr.AddNamespace("cx3", "http://schemas.microsoft.com/office/drawing/2016/5/9/chartex");
			nsmgr.AddNamespace("cx4", "http://schemas.microsoft.com/office/drawing/2016/5/10/chartex");
			nsmgr.AddNamespace("cx5", "http://schemas.microsoft.com/office/drawing/2016/5/11/chartex");
			nsmgr.AddNamespace("cx6", "http://schemas.microsoft.com/office/drawing/2016/5/12/chartex");
			nsmgr.AddNamespace("cx7", "http://schemas.microsoft.com/office/drawing/2016/5/13/chartex");
			nsmgr.AddNamespace("cx8", "http://schemas.microsoft.com/office/drawing/2016/5/14/chartex");
			nsmgr.AddNamespace("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
			nsmgr.AddNamespace("aink", "http://schemas.microsoft.com/office/drawing/2016/ink");
			nsmgr.AddNamespace("am3d", "http://schemas.microsoft.com/office/drawing/2017/model3d");
			nsmgr.AddNamespace("o", "urn:schemas-microsoft-com:office:office");
			nsmgr.AddNamespace("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
			nsmgr.AddNamespace("m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
			nsmgr.AddNamespace("v", "urn:schemas-microsoft-com:vml");
			nsmgr.AddNamespace("wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
			nsmgr.AddNamespace("wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
			nsmgr.AddNamespace("w10", "urn:schemas-microsoft-com:office:word");
			nsmgr.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			nsmgr.AddNamespace("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			nsmgr.AddNamespace("w15", "http://schemas.microsoft.com/office/word/2012/wordml");
			nsmgr.AddNamespace("w16se", "http://schemas.microsoft.com/office/word/2015/wordml/symex");
			nsmgr.AddNamespace("wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
			nsmgr.AddNamespace("wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
			nsmgr.AddNamespace("wne", "http://schemas.microsoft.com/office/word/2006/wordml");
			nsmgr.AddNamespace("wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
			nsmgr.AddNamespace("mc: Ignorable", "w14 w15 w16se wp14");

			var sequences = WebMethode.GetDescriptionWebMethode(doc, nsmgr);
			List<string> resultat = sequences;
			foreach (string x in resultat)
			{
				
					Console.WriteLine(x);

				}
			


			//	Console.ReadKey();
			//}


			//ListeTable t = new ListeTable();
			//t.NomTable(doc, nsmgr);


			//var cls = Classe.GetClasses(doc, nsmgr);
			//List<Classe> resultat = cls;
			//foreach (Classe elem in resultat)
			//{
			//	Console.WriteLine(elem.Nom);
			//	Console.ReadKey();
			//}

			//List<String> colonnes = new List<string>();
			//colonnes.Add("Nom");
			//colonnes.Add("Type");
			//colonnes.Add("Description");
			//colonnes.Add("Cle");
			//colonnes.Add("Number(18)");
			//colonnes.Add("Clé technique de lassociation entre la ligne et le kitBox.");
			//colonnes.Add("CleLigne");
			//colonnes.Add("Number(18)");
			//colonnes.Add("Clé unique de la ligne.");
			//Console.WriteLine(colonnes.Count);

			//var col = Colonne.ListeAColonnes(colonnes);
			//foreach (Colonne elem in col)
			//{
			//	Console.WriteLine(elem.ToString());
			//}

			//Console.ReadKey();

			//var col2 = Table.Tables(doc, nsmgr);
			//foreach (Table l in col2)
				
			//	{
			//	foreach (Donnee cl in l.Donnees)
			//	{

			//		Console.WriteLine(cl.ToString());
			//	}

			//	}


				//}
				//Console.ReadKey();

			
			Console.ReadKey();
		}



	}
}


