using AnalyzerGui.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AnalyzerGui.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        
        var id = int.Parse((button!.Tag as string)!);
        
        var dataContext = this.DataContext as MainWindowViewModel;

        dataContext!.CurrentUserControl = dataContext.UserControls[id];
    }
}
