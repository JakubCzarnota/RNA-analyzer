using System.Collections.Generic;
using AnalyzerGui.Views;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CoreAnalyzer;

namespace AnalyzerGui.ViewModels;

public partial class RnaSharedViewModel : ViewModelBase
{
 
  [ObservableProperty]
  private string _rnaString = string.Empty;

  [ObservableProperty]
  private Rna? _rna;
  
  [ObservableProperty]
  private List<Protein>? _currentRnaSequence;
  
  [ObservableProperty]
  private Protein? _currentProtein;
  
  private int _currentRnaSequenceIndex = -1;

  public int CurrentRnaSequenceIndex
  {
    get => _currentRnaSequenceIndex;
    set {
      if (Rna is null || Rna.Proteins.Length == 0)
      {
        SetProperty(ref _currentRnaSequenceIndex, -1);
        CurrentRnaSequence = null;
        CurrentProteinIndex = -1;
        return;
      }

      if (value >= Rna.Proteins.Length)
      {
        SetProperty(ref _currentRnaSequenceIndex, 0);
        CurrentRnaSequence = Rna.Proteins[0];
        CurrentProteinIndex = 0;
        return;
      }

      if (value < 0)
      {
        SetProperty(ref _currentRnaSequenceIndex, Rna.Proteins.Length - 1);
        CurrentRnaSequence = Rna.Proteins[Rna.Proteins!.Length - 1];
        CurrentProteinIndex = 0;
        return;
      }
      
      SetProperty(ref _currentRnaSequenceIndex, value);
      CurrentRnaSequence = Rna.Proteins[value];
      CurrentProteinIndex = 0;
    }
  }
  
  private int _currentProteinIndex = -1;

  public int CurrentProteinIndex
  {
    get => _currentProteinIndex;
    set {
      if (Rna is null || CurrentRnaSequence is null)
      {
        SetProperty(ref _currentProteinIndex, -1);
        CurrentProtein = null;
        return;
      }

      if (value >= CurrentRnaSequence.Count)
      {
        SetProperty(ref _currentProteinIndex, 0);
        CurrentProtein = Rna.Proteins[CurrentProteinIndex][0];
        return;
      }
      
      if (value < 0)
      {
        SetProperty(ref _currentProteinIndex, Rna.Proteins[CurrentRnaSequenceIndex].Count - 1);
        CurrentProtein = Rna.Proteins[CurrentProteinIndex][value];
        return;
      }
      
      SetProperty(ref _currentProteinIndex, value);
      CurrentProtein = Rna.Proteins[CurrentProteinIndex][value];
    }
  }

  [ObservableProperty] 
  private UserControl _pickerButtons;

  public RnaSharedViewModel()
  {
    PickerButtons = new PickerButtons() { DataContext = this };
  }

}
