using AnalyzerGui.Models;

namespace AnalyzerGui.ViewModels;

public abstract class PageViewModelBase : ViewModelBase
{
    public SharedData Shared { get; private set; }

    protected PageViewModelBase()
    {
        Shared = new SharedData();
    }

    protected PageViewModelBase(SharedData shared)
    {
        Shared = shared;
    }
}