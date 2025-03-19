using System;
using System.Collections.Generic;
using System.Linq;
using CoreAnalyzer;
using CoreAnalyzer.Enums;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.Charts;

public class PolarityChart : ChartBase
{
    public PolarityChart(Protein? protein) : base(protein)
    {
        Name = "Polarity";
        
        Series = new()
        {
            new ColumnSeries<int>()
            {
                Values = protein?.AminoAcids.Select(a => (int)a.Polarity).ToList(),
            }
        };
        
    }

    protected override List<Axis> GenerateYAxis()
    {
        var yAxies = base.GenerateYAxis();

        yAxies[0].MinStep = 1;
        yAxies[0].MinLimit = 0;
        yAxies[0].MaxLimit = 3;
        yAxies[0].ForceStepToMin = true;
        yAxies[0].Labeler = (value) => value is >= 0 and <= 3 ? ((Polarities)((int)value)).ToString().FormatCamelCase() : "";
        
        return yAxies;
    }
}