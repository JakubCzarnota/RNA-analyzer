namespace CoreAnalyzer
{
    public class Rna
    {
        public string RnaString { get; private set; }

        public List<Protein>[] Proteins { get; private set; }

        public Rna(string rna)
        {
            RnaString = rna;

            List<Task> tasks = new List<Task>();

            Proteins = new List<Protein>[3];

            tasks.Add(
                Task.Run(() =>
                {
                    Proteins[0] = FindProteins(rna);
                })
            );
            tasks.Add(
                Task.Run(() =>
                {
                    Proteins[1] = FindProteins(rna.Remove(0, 1));
                })
            );
            tasks.Add(
                Task.Run(() =>
                {
                    Proteins[2] = FindProteins(rna.Remove(0, 2));
                })
            );

            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }

        private List<Protein> FindProteins(string dna)
        {
            List<Protein> proteins = new List<Protein>();

            Protein newProtein = new Protein();

            bool isProtein = false;

            for (int i = 2; i < dna.Length; i += 3)
            {
                string currentAminoAcid =
                    dna[i - 2].ToString() + dna[i - 1].ToString() + dna[i].ToString();

                if (currentAminoAcid == "AUG")
                {
                    isProtein = true;
                    newProtein = new Protein();
                    newProtein.AminoAcids.Add(GetAminoAcid(currentAminoAcid));
                }
                else if (isProtein)
                {
                    if (
                        currentAminoAcid == "UAA"
                        || currentAminoAcid == "UAG"
                        || currentAminoAcid == "UGA"
                    )
                    {
                        isProtein = false;
                        proteins.Add(newProtein);
                    }
                    else
                    {
                        var aminoAcid = GetAminoAcid(currentAminoAcid);

                        newProtein.AminoAcids.Add(aminoAcid);
                    }
                }
            }

            return proteins;
        }

        private AminoAcid GetAminoAcid(string Nucleotides)
        {
            var aminoAcid = AminoAcidsHelper
                .AllAminoAcids.Where(AminoAcid => AminoAcid.Nucleotides.Contains(Nucleotides))
                .FirstOrDefault();

            if (aminoAcid is null)
                throw new ArgumentException();

            return aminoAcid;
        }
    }
}
