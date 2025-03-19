using System;
using AnalyzerGui.Models;
using AnalyzerGui.Scaling;
using AnalyzerGui.Views;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnalyzerGui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public Action<double> OnScaleChanged { get; set; } = d => { };
    
    private double _scale;

    public double Scale
    {
        get => _scale;
        set
        {
            SetProperty(ref _scale, value);
            OnScaleChanged(value);
        }
    }

    [ObservableProperty]
    private PageBase _currentUserControl;

    public PageBase[] UserControls { get; private set; }
    
    public MainWindowViewModel(double scaleFactor = 1)
    {
        Scale = scaleFactor;
        
        var sharedData = new SharedData();

        UserControls =
        [
            new RnaInputUserControl() { DataContext = new RnaInputUserControlViewModel(sharedData)},
            new ProteinOverviewUserControl()  { DataContext = new ProteinOverviewViewModel(sharedData) },
            new AminoAcidsChart() { DataContext = new AminoAcidsChartViewModel(sharedData) },
            new AminoAcidsInProteinDisplay() { DataContext = new AminoAcidsInProteinDisplayViewModel(sharedData) }
        ];

        _currentUserControl = UserControls[0];
    }
}
