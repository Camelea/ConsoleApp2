using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.Classes
{

	internal class Classe
	{
		public string Nom;
		public List<Attribut> Attributs;
		public List<Constructeur> Constructeurs;
		public List<ProprieteDynamique> ProprietesDynamiques;
		public List<Methode> Methodes;

		public Classe(string nom, List<Attribut> attributs, List<Constructeur> constructeurs, List<ProprieteDynamique> proprietesDynamiques, List<Methode> methodes)
		{
			this.Nom = nom;
			this.Attributs = attributs;
			this.Constructeurs = constructeurs;
			this.ProprietesDynamiques = proprietesDynamiques;
			this.Methodes = methodes;



		}

	}
}

