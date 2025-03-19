using AnalyzerGui.Models;
using AnalyzerGui.Scaling;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CoreAnalyzer;
using static System.Text.RegularExpressions.Regex;

namespace AnalyzerGui.ViewModels;

public partial class AminoAcidsInProteinDisplayViewModel : PageViewModelBase
{
    private readonly string _currentDirectory = System.IO.Path.GetDirectoryName(
        System.Environment.ProcessPath
    )! + "/";
    
    [ObservableProperty]
    private Bitmap? _currentAminoAcidImg;
    
    [ObservableProperty]
    private StackPanel _aminoAcidsImgs = new ();

    private ScalableObject? _currentAminoAcidPropertiesPanelScalable;
    
    private ScalableObject? _aminoAcidsImgsScalable;
    
    [ObservableProperty] 
    private StackPanel _currentAminoAcidPropertiesPanel = new ();
    
    public AminoAcidsInProteinDisplayViewModel(SharedData shared) : base(shared) 
    {
        ScaleAction = () =>
        {
          _currentAminoAcidPropertiesPanelScalable?.Scale(Scale);
          _aminoAcidsImgsScalable?.Scale(Scale);
        };
      
        shared.OnCurrentProteinChange.Add(protein =>
        {
          var imgs = GetAminoAcidsImgsList(protein);
          AminoAcidsImgs = imgs;

          var scalable = new ScalableObject(imgs);
          _aminoAcidsImgsScalable = scalable;
          scalable.Scale(Scale);
        });
        
        shared.OnCurrentAminoAcidChange.Add(aminoAcid =>
        {
          CurrentAminoAcidImg = GetAminoAcidBitmap(aminoAcid);
          
          var stackPanel = GetAminoAcidPropertiesPanel(aminoAcid);
          CurrentAminoAcidPropertiesPanel = stackPanel;

          var scalableStackPanel = new ScalableObject(stackPanel);
          _currentAminoAcidPropertiesPanelScalable = scalableStackPanel;
          scalableStackPanel.Scale(Scale);
        });
    }

    public AminoAcidsInProteinDisplayViewModel() : base()
    {
        
    }
    
    private StackPanel GetAminoAcidPropertiesPanel(AminoAcid aminoAcid)
    {
      var stackPanel = new StackPanel();
      
      if(Shared.CurrentAminoAcid is null)
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

    private StackPanel GetAminoAcidsImgsList(Protein protein)
    {
      var stackPanel = new StackPanel()
      {
        Orientation = Orientation.Horizontal,
        Background = new SolidColorBrush(Colors.White),
      };

      if (Shared.CurrentProtein is null)
        return stackPanel;
      
      foreach (var aminoAcid in protein.AminoAcids)
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
                  Shared.CurrentAminoAcid = aminoAcid;
                  CurrentAminoAcidImg = GetAminoAcidBitmap(aminoAcid);
                }) ,
                Content = new Image() 
                {
                  Height = 100,
                  Source = GetAminoAcidBitmap(aminoAcid),
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

    private Bitmap? GetAminoAcidBitmap(AminoAcid? aminoAcid) => 
      aminoAcid is not null ? new Bitmap($"{_currentDirectory}aminoacids/{aminoAcid.Symbol3.ToLower()}.png") : null;
}