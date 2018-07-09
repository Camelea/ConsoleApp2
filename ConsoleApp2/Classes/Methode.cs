using System.Collections.Generic;

namespace ConsoleApp2.Classes
{
	public class Methode
	{
		#region Attributs

		public string Description;
		public List<ParametreEntrant> ParametresEntrants;
		public string Algorithme;

		#endregion

		#region Constructeur 

		public Methode(string description, List<ParametreEntrant> parametresEntrants, string algorithme)
		{
			this.Description = description;
			this.ParametresEntrants = parametresEntrants;
			this.Algorithme = algorithme;

		}
		#endregion
	}
}