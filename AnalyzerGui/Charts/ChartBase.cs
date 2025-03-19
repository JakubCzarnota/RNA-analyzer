using System.Collections.Generic;
using System.Globalization;
using CoreAnalyzer;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.Charts;

public abstract class ChartBase
{
    public string Name { get; protected init; } = string.Empty;
    public List<ISeries> Series { get; protected init; } = [];

    public List<Axis> XAxis { get; protected set; }
    
    public List<Axis> YAxis { get; protected set; }

    protected ChartBase(Protein?  protein)
    {
        XAxis = GenerateXAxis();
        YAxis = GenerateYAxis();
    }

    protected virtual List<Axis> GenerateXAxis() =>
    [
        new()
        {
            MinStep = 1,
        }
    ];
    
    protected virtual List<Axis> GenerateYAxis() =>
    [
        new()
    ];
    
}