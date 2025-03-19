using AnalyzerGui.Scaling;
using AnalyzerGui.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AnalyzerGui.Views;

public partial class PickerButtons : ScalableUserControl
{
    public PickerButtons()
    {
        InitializeComponent();
    }

    private void ChangeRnaSequence(object? sender, RoutedEventArgs e)
    {
        var button = (Button)sender!;
        
        var tag = button.Tag as string;

        var dataContext = (PickerButtonsViewModel)this.DataContext!;
        
        switch (tag)
        {
            case "+":
                dataContext.Shared.CurrentRnaSequenceIndex++;
                break;
            case "-":
                dataContext.Shared.CurrentRnaSequenceIndex--;
                break;
        }
    }
    
    private void ChangeProtein(object? sender, RoutedEventArgs e)
    {
        var button = (Button)sender!;
        
        var tag = button.Tag as string;

        var dataContext = (PickerButtonsViewModel)this.DataContext!;
        
        switch (tag)
        {
            case "+":
                dataContext.Shared.CurrentProteinIndex++;
                break;
            case "-":
                dataContext.Shared.CurrentProteinIndex--;
                break;
        }
    }
}