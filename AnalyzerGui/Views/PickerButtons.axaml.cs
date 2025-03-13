using AnalyzerGui.ViewModels;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AnalyzerGui.Views;

public partial class PickerButtons : UserControl
{
    public PickerButtons()
    {
        InitializeComponent();
    }

    private void ChangeRnaSequence(object? sender, RoutedEventArgs e)
    {
        var button = (Button)sender!;
        
        var tag = button.Tag as string;

        var dataContext = (RnaSharedViewModel)this.DataContext!;
        
        switch (tag)
        {
            case "+":
                dataContext.CurrentRnaSequenceIndex++;
                break;
            case "-":
                dataContext.CurrentRnaSequenceIndex--;
                break;
        }
    }
    
    private void ChangeProtein(object? sender, RoutedEventArgs e)
    {
        var button = (Button)sender!;
        
        var tag = button.Tag as string;

        var dataContext = (RnaSharedViewModel)this.DataContext!;
        
        switch (tag)
        {
            case "+":
                dataContext.CurrentProteinIndex++;
                break;
            case "-":
                dataContext.CurrentProteinIndex--;
                break;
        }
    }
}