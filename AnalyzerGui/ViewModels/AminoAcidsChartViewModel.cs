using System.Collections.Generic;
using System.Collections.ObjectModel;
using AnalyzerGui.Charts;
using AnalyzerGui.Models;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CoreAnalyzer;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;

namespace AnalyzerGui.ViewModels;

public partial class AminoAcidsChartViewModel : PageViewModelBase
{
    
    [ObservableProperty]
    private ComboBox _comboBox;

    private List<ChartBase> _charts;
    
    public ObservableCollection<ISeries> Series { get; private set; } = [];
    
    public ObservableCollection<Axis> XAxis { get; private set; } = new()
    {
        new Axis()
    };

    public ObservableCollection<Axis> YAxis { get; private set; } = new()
    {
        new Axis()
    };
    
    [ObservableProperty] 
    private Axis _axis;

    public AminoAcidsChartViewModel(SharedData shared) : base(shared)
    {
        Configure(shared);
    }

    public AminoAcidsChartViewModel() : this(new SharedData())
    {
        Configure(Shared);
    }

    private void Configure(SharedData shared)
    {
        _charts = GetCharts(shared.CurrentProtein);

        ComboBox = new ComboBox();

        _charts.ForEach(c => ComboBox.Items.Add(c.Name));
        
        ComboBox.SelectionChanged += (sender, args) =>
        {
            var i = ComboBox.SelectedIndex;
            
            Series.Clear();

            if (i >= 0 && i <= _charts.Count)
            {
                _charts[i].Series.ForEach(s => Series.Add(s));
                XAxis.ReplaceValuesWith(_charts[i].XAxis);
                YAxis.ReplaceValuesWith(_charts[i].YAxis);
            }
        };
        
        shared.OnCurrentProteinChange.Add(protein =>
        {
            var i = ComboBox.SelectedIndex;
            
            _charts = GetCharts(protein);
            
            Series.Clear();
            if (i >= 0 && i < _charts.Count)
            {
                _charts[i].Series.ForEach(s => Series.Add(s));
                XAxis.ReplaceValuesWith(_charts[i].XAxis);
                YAxis.ReplaceValuesWith(_charts[i].YAxis);
            }
        });
    }

    private List<ChartBase> GetCharts(Protein? protein)
    {
        return new ()
        {
            new HydropathyIndexChart(protein),
            new PolarityChart(protein),
            new NetChargeChart(protein),
            new MolecularMassChart(protein),
            new IsoelectricPointChart(protein),
            new MolarAbsorptivityWavelengthChart(protein),
            new MolarAbsorptivityCoefficientChart(protein),
        };
    }
}