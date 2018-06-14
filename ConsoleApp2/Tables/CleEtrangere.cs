namespace ConsoleApp2.Tables
{
	internal class CleEtrangere : Cle
	{

		protected string table;


		public CleEtrangere(string nom, string colonne, string table) : base(nom, table)
		{
			this.nom = nom;
			this.colonne = colonne;
			this.table = table;
		}
		public override string ToString()
		{
			return ("CONSTRAINT" + "\"" + this.nom + "\"" + "FOREIGN KEY ( \" " + this.colonne + " \" REFERENCES \" " + this.table + "(" + this.colonne + ")"); 

		}
	}

}