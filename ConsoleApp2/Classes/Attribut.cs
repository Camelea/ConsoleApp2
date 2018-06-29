namespace ConsoleApp2.Classes
{
	public class Attribut
	{
		public string Nom;
		public string Type;
		public string Description
		{
		get;
		set;
		}

		public Attribut(string nom , string type, string description) {
			this.Nom = nom;
			this.Type = type;
			this.Description = description;

		}


	}
}