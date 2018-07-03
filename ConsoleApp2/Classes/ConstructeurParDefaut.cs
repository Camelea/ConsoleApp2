using System.Collections.Generic;

namespace ConsoleApp2.Classes
{
	public class ConstructeurParDefaut
	{
		public string Description;
		public List<ParametreEntrant> ParametresEntrants;
		public string Algorithme;

		public ConstructeurParDefaut(string description, List<ParametreEntrant> parametresEntrants, string algorithme)
		{
			this.Description = description;
			this.ParametresEntrants = parametresEntrants;
			this.Algorithme = algorithme;

		}
	}
}