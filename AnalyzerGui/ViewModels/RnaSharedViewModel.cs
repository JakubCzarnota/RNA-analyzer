using CommunityToolkit.Mvvm.ComponentModel;
using CoreAnalyzer;

namespace AnalyzerGui.ViewModels;

public partial class RnaSharedViewModel : ViewModelBase
{
 
  [ObservableProperty]
  private string _rnaString = string.Empty;

  [ObservableProperty]
  private Rna? _rna;
  
  
}
