using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Contrainte
	{
		public List<ClePrimaire> clesPrimaires;
		//List<CleEtrangere> clesetrangeres;
		List<ContrainteNonNulle> contraintesNonNulles;
		//List<ContrainteVerification> contraintesdeverification;
		public Sequence sequence;
		//List<Index> indexes;

		public Contrainte(Sequence sequence,List<ClePrimaire> clesPrimaires, List<ContrainteNonNulle> contraintesNonNulles)
		{
			this.clesPrimaires = clesPrimaires;
			this.sequence = sequence;
			this.contraintesNonNulles = contraintesNonNulles;
		}

		public static List<Contrainte> Contraintes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Sequence> sequences = Sequence.GetSequencesTables(doc, nsmgr);
			List<Contrainte> contraintes = new List<Contrainte>();
			List<List<ClePrimaire>> clesprimaires = ClePrimaire.GetClesPrimairesTables(doc, nsmgr);
			List<List<ContrainteNonNulle>> contraintesnonnulles = ContrainteNonNulle.GetContraintesNonNullesTables(doc, nsmgr);
			for (int i = 0; i < sequences.Count; i++)
			{
				contraintes.Add(new Contrainte(sequences[i],clesprimaires[i], contraintesnonnulles[i]));
		
			}
			return contraintes;

		}




	}
}