using System;
using Avalonia;

namespace AnalyzerGui.Scaling;

public class ScalableProperty<T1, T2> : IScalable
{
    private readonly T1 _control;
    
    private readonly T2 _defaultValue;
    
    private readonly Action<T1, T2, double> _setPropertyAction;
    
    public ScalableProperty(T1 control ,T2 defaultValue ,Action<T1, T2, double> setPropertyAction)
    {
        _control = control;
        _setPropertyAction = setPropertyAction;
        _defaultValue = defaultValue;
    }

    public void Scale(double scaleFactor)
    {
        _setPropertyAction(_control, _defaultValue, scaleFactor);
    }
}