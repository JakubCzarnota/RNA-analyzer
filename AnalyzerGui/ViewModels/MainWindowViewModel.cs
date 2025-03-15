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
        var sharedViewModel = new RnaSharedViewModel();

        UserControls =
        [
            new RnaInputUserControl() { DataContext = sharedViewModel },
            new ProteinOverviewUserControl()  { DataContext = sharedViewModel },
            new AminoAcidsInProteinDisplay() { DataContext = sharedViewModel }
        ];

        _currentUserControl = UserControls[0];
    }
}
