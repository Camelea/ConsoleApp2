using System.Collections.Generic;

namespace ConsoleApp2.Classes
{
	public class Constructeur
	{
		public List<ConstructeurParDefaut> ConstructeursParDefaut;
		public List<ConstructeurInitialisation> ConstructeursInitilisation;

		public Constructeur(List<ConstructeurParDefaut> constructeursParDefaut, List<ConstructeurInitialisation> constructeursInitialisation)
		{
			this.ConstructeursParDefaut = constructeursParDefaut;
			this.ConstructeursInitilisation = constructeursInitialisation;


		}

	}
}