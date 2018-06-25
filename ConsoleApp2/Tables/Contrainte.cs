using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Contrainte
	{
		public List<ClePrimaire> clesPrimaires;
		//List<CleEtrangere> clesetrangeres;
		//List<ContrainteNonNulle> contraintesnonnulles;
		//List<ContrainteVerification> contraintesdeverification;
		public Sequence sequence;
		//List<Index> indexes;

		public Contrainte(Sequence sequence,List<ClePrimaire> clesPrimaires)
		{
			this.clesPrimaires = clesPrimaires;
			this.sequence = sequence;
		}

		public static List<Contrainte> Contraintes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Sequence> sequences = Sequence.GetSequencesTables(doc, nsmgr);
			List<Contrainte> contraintes = new List<Contrainte>();
			List<List<ClePrimaire>> clesprimaires = ClePrimaire.GetClesPrimairesTables(doc, nsmgr);
			for (int i = 0; i < sequences.Count; i++)
			{
				contraintes.Add(new Contrainte(sequences[i],clesprimaires[i]));
		
			}
			return contraintes;

		}




	}
}