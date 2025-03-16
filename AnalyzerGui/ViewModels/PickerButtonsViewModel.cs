using AnalyzerGui.Models;

namespace AnalyzerGui.ViewModels;

public class PickerButtonsViewModel
{
    public SharedData Shared { get; private set; }

    public PickerButtonsViewModel(SharedData shared)
    {
        Shared = shared;
    }

    public PickerButtonsViewModel()
    {
        Shared = new SharedData();
    }
}