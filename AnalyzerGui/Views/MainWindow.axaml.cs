using AnalyzerGui.Scaling;
using AnalyzerGui.ViewModels;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace AnalyzerGui.Views;

public partial class MainWindow : ScalableWindow
{
    private readonly Options _options;
    
    public MainWindow()
    {
        InitializeComponent();
        
        _options = OptionsHelper.Load();
    }

    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        
        var dataContext = this.DataContext as MainWindowViewModel;
        
        dataContext!.Scale = _options.SavedScale;
        dataContext!.OnScaleChanged = ChangeScale;
        
        Scale(dataContext!.Scale);
        
    }

    private void ChangeScale(double newScale)
    {
        var dataContext = this.DataContext as MainWindowViewModel;
        
        Scale(newScale);
        foreach (var userControl in dataContext!.UserControls)
        {
            var userControlDataContext = userControl.DataContext as PageViewModelBase;
            userControlDataContext!.Scale = newScale;

            userControl.Scale();
        }

        _options.SavedScale = newScale;
        _options.Save();
    }
    
    
    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        
        var id = int.Parse((button!.Tag as string)!);
        
        var dataContext = this.DataContext as MainWindowViewModel;

        dataContext!.CurrentUserControl = dataContext.UserControls[id];
    }
    
}
