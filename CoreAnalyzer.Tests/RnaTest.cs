using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using CoreAnalyzer;
using FluentAssertions;
using Xunit;

namespace CoreAnalyzer.Tests
{
    public class RnaTest
    {
        public static IEnumerable<object[]> GetSampleDataForRnaProteinFindTest()
        {
            yield return new object[]
            {
                "AUGGCCUUUGGAUAGGGAUGCCGGAUUUCACGUGGACUGCAUCCGGAUGAAUGAAGGCUCUGCAAGGGACCUUCGAUAAUAUGUUCAGGUAUAUCAAGCCCGUUAGGAGUGAAUCUCUGA",
                new List<Protein>[]
                {
                    new List<Protein>
                    {
                        new Protein()
                        {
                            AminoAcids = new List<AminoAcid>()
                            {
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "M"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "A"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "F"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "G"),
                            },
                        },
                    },
                    new List<Protein>
                    {
                        new Protein()
                        {
                            AminoAcids = new List<AminoAcid>()
                            {
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "M"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "N"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "E"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "G"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "S"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "A"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "R"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "D"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "L"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "R"),
                            },
                        },
                    },
                    new List<Protein>
                    {
                        new Protein()
                        {
                            AminoAcids = new List<AminoAcid>()
                            {
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "M"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "P"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "D"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "F"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "T"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "W"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "T"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "A"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "S"),
                                AminoAcidsHelper.AllAminoAcids.First(a => a.Symbol1 == "G"),
                            },
                        },
                    },
                },
            };
        }

        [MemberData(nameof(GetSampleDataForRnaProteinFindTest))]
        [Theory]
        public void Rna_ForFivenRna_FindCorrectProteins(string rnaString, List<Protein>[] proteins)
        {
            // arrange

            // act

            var rna = new Rna(rnaString);

            // assert

            rna.Proteins.Should().BeEquivalentTo(proteins);
        }
    }
}
