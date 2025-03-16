using System;
using System.Collections.Generic;
using System.Linq;
using AnalyzerGui.ViewModels;
using AnalyzerGui.Views;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CoreAnalyzer;


namespace AnalyzerGui.Models;

public partial class SharedData : ObservableObject
{

  public List<Action<Protein>> OnCurrentProteinChange { get; } = [];
  
  public List<Action<AminoAcid>> OnCurrentAminoAcidChange { get;  } = [];

  [ObservableProperty]
  private string _rnaString = string.Empty;

  [ObservableProperty]
  private Rna? _rna;
  
  [ObservableProperty]
  private List<Protein>? _currentRnaSequence;
  
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
  
  [ObservableProperty]
  private Protein? _currentProtein;
  
  private int _currentProteinIndex = -1;

  public int CurrentProteinIndex
  {
    get => _currentProteinIndex;
    set {
      if (Rna is null || CurrentRnaSequence is null)
      {
        SetProperty(ref _currentProteinIndex, -1);
        CurrentProtein = null;
        CurrentAminoAcid = null;
        OnCurrentProteinChange.ForEach(action => action(CurrentProtein!));
        return;
      }

      if (value >= CurrentRnaSequence.Count)
      {
        SetProperty(ref _currentProteinIndex, 0);
        CurrentProtein = CurrentRnaSequence[0];
        CurrentAminoAcid = CurrentProtein.AminoAcids[0];
        OnCurrentProteinChange.ForEach(action => action(CurrentProtein!));
        return;
      }
      
      if (value < 0)
      {
        SetProperty(ref _currentProteinIndex, Rna.Proteins[CurrentRnaSequenceIndex].Count - 1);
        CurrentProtein = CurrentRnaSequence.Last();
        CurrentAminoAcid = CurrentProtein.AminoAcids[0];
        OnCurrentProteinChange.ForEach(action => action(CurrentProtein!));
        return;
      }
      
      SetProperty(ref _currentProteinIndex, value);
      CurrentProtein = CurrentRnaSequence[value];
      CurrentAminoAcid = CurrentProtein.AminoAcids[0];
      OnCurrentProteinChange.ForEach(action => action(CurrentProtein!));
    }
  }
  
  private AminoAcid? _currentAminoAcid = null;

  public AminoAcid? CurrentAminoAcid
  {
    get => _currentAminoAcid;
    set
    {
      if (value is null)
      {
        SetProperty(ref _currentAminoAcid, null);
        OnCurrentAminoAcidChange.ForEach(action => action(CurrentAminoAcid!));
        return;
      }
      
      SetProperty(ref _currentAminoAcid, value);
      OnCurrentAminoAcidChange.ForEach(action => action(CurrentAminoAcid!));
    }
  }
  
  public UserControl PickerButtons => new PickerButtons() { DataContext = new PickerButtonsViewModel(this) };

}
