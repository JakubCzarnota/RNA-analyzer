using System;
using AnalyzerGui.Scaling;
using AnalyzerGui.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CoreAnalyzer;

namespace AnalyzerGui.Views;

public partial class RnaInputUserControl : PageBase
{
    public RnaInputUserControl()
    {
        InitializeComponent();
    }
    

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var dataContext = (RnaInputUserControlViewModel)this.DataContext!;

        dataContext.Shared.Rna = new Rna(dataContext.Shared.RnaString);

        dataContext.Shared.CurrentRnaSequenceIndex = 0;

    }
}