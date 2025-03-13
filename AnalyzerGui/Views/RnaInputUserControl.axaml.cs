using System;
using AnalyzerGui.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CoreAnalyzer;

namespace AnalyzerGui.Views;

public partial class RnaInputUserControl : UserControl
{
    public RnaInputUserControl()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var dataContext = (RnaSharedViewModel)this.DataContext!;

        dataContext.Rna = new Rna(dataContext.RnaString);

        dataContext.CurrentRnaSequenceIndex = 0;

    }
}