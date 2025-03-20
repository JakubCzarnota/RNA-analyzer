using AnalyzerGui.Scaling;
using AnalyzerGui.ViewModels;
using Avalonia.Interactivity;

namespace AnalyzerGui.Views;

public abstract class PageBase : ScalableUserControl
{
    public virtual void Scale()
    {
        var dataContext = this.DataContext as PageViewModelBase;
        
        Scale(dataContext!.Scale); 
        
        if (dataContext.ScaleAction is not null)
            dataContext.ScaleAction();
    }
    
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        
        Scale();
    }
}