using System;
using System.Collections.Generic;
using System.Linq;
using CoreAnalyzer;
using CoreAnalyzer.Enums;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.Charts;

public class NetChargeChart : ChartBase
{
    public NetChargeChart(Protein? protein) : base(protein)
    {
        Name = "Net charge";
        
        Series = new()
        {
            new ColumnSeries<int>()
            {
                Values = protein?.AminoAcids.Select(a => (int)a.NetCharge).ToList(),
            }
        };
        
    }

    protected override List<Axis> GenerateYAxis()
    {
        var yAxies = base.GenerateYAxis();

        yAxies[0].MinStep = 1;
        yAxies[0].MinLimit = -1;
        yAxies[0].MaxLimit = 1;
        yAxies[0].ForceStepToMin = true;
        yAxies[0].Labeler = (value) => 
            value is >= -1 and <= 1 ? ((NetCharges)((int)value)).ToString().FormatCamelCase() : "";
        
        return yAxies;
    }
}