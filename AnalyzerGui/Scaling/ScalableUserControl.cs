using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.VisualTree;

namespace AnalyzerGui.Scaling;

public class ScalableUserControl : UserControl
{
    private readonly List<IScalable> _scalableObjects = [];
    
    protected override void OnLoaded(RoutedEventArgs e)
    {
        base.OnLoaded(e);
        
        if (_scalableObjects .Count > 0)
            return;

        foreach (var child in this.GetVisualChildren())
        {
            if (child is Control controlChild)
                _scalableObjects.Add(new ScalableObject(controlChild));
        }
    }

    protected virtual void Scale(double scaleFactor)
    {
        _scalableObjects.ForEach(o => o.Scale(scaleFactor));
    }
}