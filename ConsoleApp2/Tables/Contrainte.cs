using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp2.Tables
{
	internal class Contrainte
	{
		public List<ClePrimaire> clesPrimaires;
		public List<CleEtrangere> clesetrangeres;
		public List<ContrainteNonNulle> contraintesNonNulles;
		public List<ContrainteDeVerification> contraintesdeverification;
		public Sequence sequence;
		public List<Index> indexes;
		
		/// <summary>
		/// Constructeur pour la contrainte qui va contenir une sequence , une liste de : clées primaires , clés etrangeres , contraintes non nulles et d'indexes 
		/// </summary>
		/// <param name="sequence"></param>
		/// <param name="clesPrimaires"></param>
		/// <param name="contraintesNonNulles"></param>
		/// <param name="indexes"></param>
		public Contrainte(Sequence sequence,List<ClePrimaire> clesPrimaires, List<ContrainteNonNulle> contraintesNonNulles,List<Index> indexes, List<CleEtrangere> clesetrangeres, List<ContrainteDeVerification> contraintesdeverification)
		{
			this.clesPrimaires = clesPrimaires;
			this.sequence = sequence;
			this.sequence = sequence;
			this.contraintesNonNulles = contraintesNonNulles;
			this.indexes = indexes;
			this.clesetrangeres = clesetrangeres;
			this.contraintesdeverification = contraintesdeverification;
		}

		public static List<Contrainte> Contraintes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Sequence> sequences = Sequence.GetSequencesTables(doc, nsmgr);
			List<Contrainte> contraintes = new List<Contrainte>();
			List<List<ClePrimaire>> clesprimaires = ClePrimaire.GetClesPrimairesTables(doc, nsmgr);
			List<List<ContrainteNonNulle>> contraintesnonnulles = ContrainteNonNulle.GetContraintesNonNullesTables(doc, nsmgr);
			List<List<Index>> indexes = Index.GetIndexTables(doc, nsmgr);
			List<List<CleEtrangere>> clesetrangeres = CleEtrangere.GetClesEtrangeresTables(doc, nsmgr);
			List<List<ContrainteDeVerification>> contraintesdeverification = ContrainteDeVerification.GetContraintesDeVerificationTables(doc, nsmgr);
			for (int i = 0; i < sequences.Count; i++)
			{
				contraintes.Add(new Contrainte(sequences[i],clesprimaires[i], contraintesnonnulles[i],indexes[i],clesetrangeres[i],contraintesdeverification[i]));
		
			}
			return contraintes;

		}




	}
}