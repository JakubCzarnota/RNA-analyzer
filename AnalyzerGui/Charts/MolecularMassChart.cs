using System;
using System.Linq;
using CoreAnalyzer;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.Charts;

public class MolecularMassChart :  ChartBase
{
    public MolecularMassChart(Protein? protein) : base(protein)
    {
        Name = "Molecular mass";
        
        Series = new()
        {
            new ColumnSeries<double>()
            {
                Values = protein?.AminoAcids.Select(a => Math.Floor(a.MolecularMass * 100) / 100).ToList(),
            }
        };
    }
}