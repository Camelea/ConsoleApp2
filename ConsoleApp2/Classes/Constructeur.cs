using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Classes
{
	public class Constructeur
	{
		#region Attributs 

		public ConstructeurParDefaut ConstructeursParDefaut;
		public ConstructeurInitialisation ConstructeursInitilisation;

		#endregion

		#region Constructeur 

		public Constructeur(ConstructeurParDefaut constructeursParDefaut, ConstructeurInitialisation constructeursInitialisation)
		{
			this.ConstructeursParDefaut = constructeursParDefaut;
			this.ConstructeursInitilisation = constructeursInitialisation;


		}
		#endregion

		#region Méthodes
		/// <summary>
		/// Renvoie la liste des constructeurs ( par defaut et initialisation ) 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Constructeur> Tables(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<ConstructeurParDefaut> constructeursParDefaut = ConstructeurParDefaut.ConstructeursParDefaut(doc, nsmgr);
			List<ConstructeurInitialisation> constructeursInitialisation = ConstructeurInitialisation.ConstructeursInitialisation(doc, nsmgr);
			List<Constructeur> constructeurs = new List<Constructeur>();
		

			for (int i = 0; i < Classe.NombreClasses(doc, nsmgr); i++)
			{
				constructeurs.Add(new Constructeur(constructeursParDefaut[i], constructeursInitialisation[i]));

			}
			return constructeurs;

		}

		#endregion

	}
}