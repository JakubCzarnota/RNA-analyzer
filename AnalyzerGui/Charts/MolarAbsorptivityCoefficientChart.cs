using System;
using System.Collections.Generic;
using System.Linq;
using CoreAnalyzer;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.Charts;

public class MolarAbsorptivityCoefficientChart : ChartBase
{
    public MolarAbsorptivityCoefficientChart(Protein? protein) : base(protein)
    {
        Name = "Molar absorptivity coefficient";
        
        var values = protein?.AminoAcids.Select(a =>
            {
                if (a.MolarAbsorptivityCoefficient is null)
                    return [0, 0, 0];

                var list = new List<double>();
                
                foreach (var f in a.MolarAbsorptivityCoefficient)
                {
                    list.Add(f);
                }

                for (var i = list.Count; i < 3; i++)
                {
                    list.Add(0);
                }
                
                return list.ToArray();
            })
            .ToList();
        
        Series = new()
        {
            new ColumnSeries<double>()
            {
                Values = values?.Select(f => Math.Floor(f[0] * 100) / 100).ToList(),
            },
            new ColumnSeries<double>()
            {
                Values = values?.Select(f => Math.Floor(f[1] * 100) / 100).ToList(),
            },
            new ColumnSeries<double>()
            {
                Values = values?.Select(f => Math.Floor(f[2] * 100) / 100).ToList(),
            }
        };
    }
}