using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AnalyzerGui.Views;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoreAnalyzer;
using static System.Text.RegularExpressions.Regex;

namespace AnalyzerGui.ViewModels;

public partial class RnaSharedViewModel : ViewModelBase
{
 
  private readonly string _currentDirectory = System.IO.Path.GetDirectoryName(
    System.Environment.ProcessPath
  )! + "/";
  
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
        CurrentAminoAcid = null;
        AminoAcidsImgs = GetAminoAcidsImgsList();
        return;
      }

      if (value >= CurrentRnaSequence.Count)
      {
        SetProperty(ref _currentProteinIndex, 0);
        CurrentProtein = CurrentRnaSequence[0];
        CurrentAminoAcid = CurrentProtein.AminoAcids[0];
        AminoAcidsImgs = GetAminoAcidsImgsList();
        return;
      }
      
      if (value < 0)
      {
        SetProperty(ref _currentProteinIndex, Rna.Proteins[CurrentRnaSequenceIndex].Count - 1);
        CurrentProtein = CurrentRnaSequence.Last();
        CurrentAminoAcid = CurrentProtein.AminoAcids[0];
        AminoAcidsImgs = GetAminoAcidsImgsList();
        return;
      }
      
      SetProperty(ref _currentProteinIndex, value);
      CurrentProtein = CurrentRnaSequence[value];
      CurrentAminoAcid = CurrentProtein.AminoAcids[0];
      AminoAcidsImgs = GetAminoAcidsImgsList();
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
        CurrentAminoAcidImg = null;
        return;
      }
      
      SetProperty(ref _currentAminoAcid, value);
      CurrentAminoAcidPropertiesPanel = GetAminoAcidPropertiesPanel(CurrentAminoAcid!);
      CurrentAminoAcidImg = GetAmiAcidBitmap(CurrentAminoAcid!);
    }
  }
  
  [ObservableProperty]
  private Bitmap? _currentAminoAcidImg =  null;
  
  public UserControl PickerButtons => new PickerButtons() { DataContext = this };
  
  [ObservableProperty]
  private StackPanel _aminoAcidsImgs = new ();
  
  [ObservableProperty] 
  private StackPanel _currentAminoAcidPropertiesPanel = new ();

  private StackPanel GetAminoAcidPropertiesPanel(AminoAcid aminoAcid)
  {
    var stackPanel = new StackPanel();
    
    if(CurrentAminoAcid is null)
      return stackPanel;
    
    var properties = typeof(AminoAcid).GetProperties();

    foreach (var property in properties)
    {
      var name = Replace(
        Replace(
          property.Name,
          @"(\P{Ll})(\P{Ll}\p{Ll})",
          "$1 $2"
        ),
        @"(\p{Ll})(\P{Ll})",
        "$1 $2").CapitalizeOnlyFirstLetter();
      
      var value = property.GetValue(aminoAcid);

      stackPanel.Children.Add(
        new TextBlock()
        {
          Text = $"{name}: {value.FormatedToString()}",
        }
      );
    }
    
    return stackPanel;
  }
  
  private StackPanel GetAminoAcidsImgsList()
  {
    var stackPanel = new StackPanel()
    {
      Orientation = Orientation.Horizontal,
      Background = new SolidColorBrush(Colors.White),
    };

    if (CurrentProtein is null)
      return stackPanel;
    
    foreach (var aminoAcid in CurrentProtein.AminoAcids)
    {
      stackPanel.Children.Add(
        new StackPanel()
        {
          Orientation = Orientation.Vertical,
          Children =
          {
            new Button()
            {
              Command = new RelayCommand(() =>
              {
                CurrentAminoAcid = aminoAcid;
                CurrentAminoAcidImg = GetAmiAcidBitmap(aminoAcid);
              }) ,
              Content = new Image() 
              {
                Height = 100,
                Source = GetAmiAcidBitmap(aminoAcid),
              }
            },
            new TextBlock()
            {
              Text = aminoAcid.FullName,
              TextAlignment = TextAlignment.Center,
              Foreground = new SolidColorBrush(Colors.Black),
            }
          }
        }
        );
    }
    return stackPanel;
  }

  private Bitmap GetAmiAcidBitmap(AminoAcid aminoAcid) =>
    new Bitmap($"{_currentDirectory}aminoacids/{aminoAcid.Symbol3.ToLower()}.png");


}
