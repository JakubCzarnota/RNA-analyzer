using System;
using System.Linq;
using CoreAnalyzer;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.Charts;

public class IsoelectricPointChart : ChartBase
{
    public IsoelectricPointChart(Protein? protein) : base(protein)
    {
        Name = "Isoelectric point";
        
        Series = new()
        {
            new ColumnSeries<double>()
            {
                Values = protein?.AminoAcids.Select(a => Math.Floor(a.IsoelectricPoint * 100) / 100).ToList(),
            }
        };
    }
}