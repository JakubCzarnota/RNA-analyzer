using AnalyzerGui.Models;
using AnalyzerGui.Views;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AnalyzerGui.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private UserControl _currentUserControl;

    public UserControl[] UserControls { get; private set; }
    
    public MainWindowViewModel()
    {
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
