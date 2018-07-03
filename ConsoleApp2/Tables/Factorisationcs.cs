using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp2.Tables
{
	abstract class Factorisation<T> //Nom temporaire 
	{
		public string nom;
		public string colonne;

		protected Factorisation(string nom, string colonne)
		{
			this.nom = nom;
			this.colonne = colonne;

		}


		public abstract T CreerObjet(string nom, string colonne);


		public  List<T> ListeAObjet(List<string> liste)
		{
			List<T> ListeClesPrimaireTables = new List<T>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeClesPrimaireTables.Add(CreerObjet(liste[i], liste[i + 1]));
			}
			return ListeClesPrimaireTables;
		}

	}

}
