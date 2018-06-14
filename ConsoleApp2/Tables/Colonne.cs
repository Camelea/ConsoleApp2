using System.Collections.Generic;

namespace ConsoleApp2.Tables
{
	internal class Colonne
	{
		List<Colonne> colonnes;
		public string type;
		public string description;
		public string nom;

		public Colonne()
		{
			this.nom = nom;
			this.type = type;
			this.description = description;

		}

		public string colonne()
		{
			return (nom + type );

		}
	}
	
}