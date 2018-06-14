using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Tables
{
	public abstract class Cle
	{
			
		protected string nom;
		protected string colonne;

		public Cle(string nom, string colonne)
		{
			this.nom = nom;
			this.colonne = colonne;
		}
		public abstract override string ToString();
	}
}
