using AnalyzerGui.Scaling;
using AnalyzerGui.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AnalyzerGui.Views;

public partial class MainWindow : ScalableWindow
{
    public MainWindow()
    {
        InitializeComponent();
        
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        
        var dataContext = this.DataContext as MainWindowViewModel;
        
        Scale(dataContext!.Scale);

        dataContext.OnScaleChanged = s =>
        {
            Scale(s);
            foreach (var userControl in dataContext!.UserControls)
            {
                var userControlDataContext = userControl.DataContext as PageViewModelBase;
                userControlDataContext!.Scale = s;

                userControl.Scale();
            }
        };
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        
        var id = int.Parse((button!.Tag as string)!);
        
        var dataContext = this.DataContext as MainWindowViewModel;

        dataContext!.CurrentUserControl = dataContext.UserControls[id];
    }
    
}
