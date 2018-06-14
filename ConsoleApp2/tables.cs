//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;
//using System.Xml.XPath;

//namespace ConsoleApp2.Tables
//{
//	class tables
//	{
//		XmlDocument xmldoc;


//		public List<string> NomColonne()
//		{
//			va toujours etres la 4eme colonne puis avancer de 3 colonnes(w: tc)
//			String strExpression = "/bookstore/book/price";
//			String tableXMLvalue = xmldoc.SelectSingleNode(strExpression).InnerText;
//			mettre un foreach pour recuperer tous les noms pareil pour decsription et type
//			faire en sort e que ca renvoie une liste
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> nomscolonnes = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				nomscolonnes.Add(titlenode.InnerText);
//			}
//			return nomscolonnes;

//		}

//		public List<string> TypeColonne() // va prendre un stringou un node )

//		{
//			le type va etre la 5 eme colonne ensuite on augemente de 3
//			String strExpression = "/bookstore/book/price";
//			String tableXMLvalue = xmldoc.SelectSingleNode(strExpression).InnerText;
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> typescolonnes = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				typescolonnes.Add(titlenode.InnerText);
//			}
//			return typescolonnes;
//		}

//		public List<string> Description()//La 6 eme colonne est on avance de 3  
//		{
//			String strExpression = "/bookstore/book/price";
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> colonnesdescription = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				colonnesdescription.Add(titlenode.InnerText);
//			}
//			return colonnesdescription;


//		}
//		public string NomTable()
//		{
//			String strExpression = "/bookstore/book/price";
//			String tableXMLvalue = xmldoc.SelectSingleNode(strExpression).InnerText;
//			String tablevalue = "CREATE TABLE  " + tableXMLvalue;
//			return tablevalue;


//		}

//		public void CreateTable()
//		{
//			String Tables = NomTable
//			prendre le premier element de chaque fnct ci-dessus(NomTable type description(la decsription en fait non psq ca sera dans la doc
//			donc mettre la doc avant la creation de la table mlettre des virgules apres chaque ligne il va falloir regarder aussi la liste des contraintes si il y a une contrainte qui a la meme clé alors ajouter
//			 sinon mettre une virgule



//		}
//		public List<string> ListeClesPrimaires()
//		{
//			String strExpression = "/bookstore/book/price";
//			String tableXMLvalue = xmldoc.SelectSingleNode(strExpression).InnerText;
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> clesprimaires = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				clesprimaires.Add(titlenode.InnerText);
//			}
//			return clesprimaires;
//		}

//		public List<string> ListeNomsClesPrimaires()
//		{

//			String strExpression = "/bookstore/book/price";
//			String tableXMLvalue = xmldoc.SelectSingleNode(strExpression).InnerText;
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> nomclesprimaires = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				nomclesprimaires.Add(titlenode.InnerText);
//			}
//			return nomclesprimaires;

//		}

//		public List<string> CorrespondanceNomsClesPrimaires()
//		{
//			String strExpression = "/bookstore/book/price";
//			List<string> nomsclesprimaires = new List<string>();
//			foreach (string cle in ListeClesPrimaires())
//			{
//				foreach (string nom in ListeNomsClesPrimaires())
//				{

//					nomsclesprimaires.Add("CONSTRAINT " + nom + "PRIMARY KEY" + cle + "ENABLE");

//				}

//			}
//			return nomsclesprimaires;
//		}


//		public List<string> ListeClesContraintes()
//		{
//			String strExpression = "/bookstore/book/price";
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> clescontraintes = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				clescontraintes.Add(titlenode.InnerText);
//			}

//			return clescontraintes;
//		}

//		public List<string> ListeContraintes()
//		{
//			String strExpression = "/bookstore/book/price";
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> contraintes = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				contraintes.Add(titlenode.InnerText);
//			}

//			return contraintes;
//		}

//		public Dictionary<string, string> CorrespondanceClesContraintes()
//		{
//			String strExpression = "/bookstore/book/price";
//			Dictionary<string, string> clecontraintes = new Dictionary<string, string>();
//			foreach (string cle in ListeClesContraintes())
//			{
//				foreach (string contrainte in ListeContraintes())
//				{

//					clecontraintes.Add(cle, contrainte);

//				}

//			}
//			return clecontraintes;
//		}

//		public string PrintColonne(string cle, string type)
//		{
//			Dictionary<string, string> clecontraintesnonnulles = CorrespondanceClesContraintesNonNulles();
//			if (ListeClesContraintes().Contains(cle))
//			{
//				return (cle + type) + ValeurViaCle(cle, clecontraintesnonnulles);
//			}

//			else
//			{
//				return (cle + type);
//			}
//		}

//		public string ValeurViaCle(string cle, Dictionary<string, string> dictionaire)
//		{
//			string valeur;
//			if (dictionaire.TryGetValue(cle, out valeur) == true)
//			{
//				return valeur;
//			}
//			else
//			{
//				return " message erreur ";
//			}
//		}



//		public List<string> ListeContraintesNonNulles()
//		{
//			String strExpression = "/bookstore/book/price";
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> contraintesnonnulles = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				contraintesnonnulles.Add(titlenode.InnerText);
//			}

//			return contraintesnonnulles;


//		}

//		public List<string> ListeclesContraintesNonNulles()
//		{
//			String strExpression = "/bookstore/book/price";
//			XmlNodeList titlenodes = xmldoc.SelectNodes(strExpression);
//			List<String> clescontraintesnonnulles = new List<String>();
//			foreach (XmlNode titlenode in titlenodes)
//			{
//				clescontraintesnonnulles.Add(titlenode.InnerText);
//			}

//			return clescontraintesnonnulles;


//		}

//		public Dictionary<string, string> CorrespondanceClesContraintesNonNulles()
//		{
//			String strExpression = "/bookstore/book/price";
//			Dictionary<string, string> clecontraintesnonnulles = new Dictionary<string, string>();
//			foreach (string cle in ListeclesContraintesNonNulles())
//			{
//				foreach (string contrainte in ListeContraintesNonNulles())
//				{

//					clecontraintesnonnulles.Add(cle, contrainte);

//				}

//			}
//			return clecontraintesnonnulles;
//		}

//		public string Tables()
//		{
//			string table = (NomTable()) + (

//				foreach (string colonne in NomColonne())
//			{
//				foreach (string type in TypeColonne())
//				{
//					colonnes(colonne, type);
//				}


//			})


//				return table;


//		}
//	}




//}
