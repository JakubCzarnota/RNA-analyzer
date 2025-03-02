// See https://aka.ms/new-console-template for more information
using CoreAnalyzer;

var rna = new Rna(
    "AUGGCCUUUGGAUAGGGAUGCCGGAUUUCACGUGGACUGCAUCCGGAUGAAUGAAGGCUCUGCAAGGGACCUUCGAUAAUAUGUUCAGGUAUAUCAAGCCCGUUAGGAGUGAAUCUCUGA"
);

foreach (var proteinList in rna.Proteins)
{
    foreach (var protein in proteinList)
    {
        foreach (var aminoAcid in protein.AminoAcids)
        {
            System.Console.Write(aminoAcid.Symbol1);
        }
        Console.WriteLine();
    }
    Console.WriteLine("------");
}
