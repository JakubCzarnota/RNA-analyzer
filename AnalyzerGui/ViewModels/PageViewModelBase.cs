using System;
using AnalyzerGui.Models;

namespace AnalyzerGui.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public SharedData Shared { get; private set; }
    
    public double Scale { get; set; }
    
    public Action? ScaleAction { get; protected set; }
    
    public Action? InvokeScale { get; set; }

    protected PageViewModelBase()
    {
        Shared = new SharedData();
    }

    protected PageViewModelBase(SharedData shared, double scale = 1)
    {
        Shared = shared;
        Scale = scale;
    }
}