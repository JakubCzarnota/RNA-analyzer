using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CoreAnalyzer;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.Charts;

public class HydropathyIndexChart : ChartBase
{
    public HydropathyIndexChart(Protein? protein) : base(protein)
    {
        Name = "Hydropathy index";
        
        Series = new()
        {
            new ColumnSeries<double>()
            {
                Values = protein?.AminoAcids.Select(a => Math.Floor(a.HydropathyIndex * 100) / 100).ToList(),
            }
        };
        
        Series = new()
        {
            new ColumnSeries<double>()
            {
                Values = protein?.AminoAcids.Select(a => Math.Floor(a.IsoelectricPoint * 100) / 100).ToList(),
            }
        };
    }
}