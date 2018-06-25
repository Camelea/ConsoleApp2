using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Contrainte
	{
		public List<ClePrimaire> clesPrimaires;
		//List<CleEtrangere> clesetrangeres;
		public List<ContrainteNonNulle> contraintesNonNulles;
		//List<ContrainteVerification> contraintesdeverification;
		public Sequence sequence;
		public List<Index> indexes;
		//List<Index> indexes;

		public Contrainte(Sequence sequence,List<ClePrimaire> clesPrimaires, List<ContrainteNonNulle> contraintesNonNulles,List<Index> indexes)
		{
			this.clesPrimaires = clesPrimaires;
			this.sequence = sequence;
			this.sequence = sequence;
			this.contraintesNonNulles = contraintesNonNulles;
			this.indexes = indexes;
		}

		public static List<Contrainte> Contraintes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Sequence> sequences = Sequence.GetSequencesTables(doc, nsmgr);
			List<Contrainte> contraintes = new List<Contrainte>();
			List<List<ClePrimaire>> clesprimaires = ClePrimaire.GetClesPrimairesTables(doc, nsmgr);
			List<List<ContrainteNonNulle>> contraintesnonnulles = ContrainteNonNulle.GetContraintesNonNullesTables(doc, nsmgr);
			List<List<Index>> indexes = Index.GetIndexTables(doc, nsmgr);
			for (int i = 0; i < sequences.Count; i++)
			{
				contraintes.Add(new Contrainte(sequences[i],clesprimaires[i], contraintesnonnulles[i],indexes[i]));
		
			}
			return contraintes;

		}




	}
}