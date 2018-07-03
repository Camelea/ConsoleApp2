using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class ConstructeurInitialisation
	{
		public string Description;
		public List<ParametreEntrant> ParametresEntrants;
		public string Algorithme;

		public ConstructeurInitialisation(string description, List<ParametreEntrant> parametresEntrants, string algorithme)
		{
			this.Description = description;
			this.ParametresEntrants = parametresEntrants;
			this.Algorithme = algorithme;

		}


	}
}