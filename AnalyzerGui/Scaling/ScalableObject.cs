using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.VisualTree;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.Avalonia;

namespace AnalyzerGui.Scaling;

public class ScalableObject : IScalable
{

    private List<IScalable> _scalables = [];
    
    public ScalableObject(Control control)
    {
        switch (control)
        {
            case Button button:
                _scalables.Add(button.GenerateScalablesProperties());
                break;
            case TextBlock textBlock:
                _scalables.Add(textBlock.GenerateScalablesProperties());
                break;
            case TextBox textBox:
                _scalables.Add(textBox.GenerateScalablesProperties());
                break;
            case ComboBox comboBox:
                _scalables.Add(comboBox.GenerateScalablesProperties());
                break;
            case Label label:
                _scalables.Add(label.GenerateScalablesProperties());
                break;
            case Image image:
                _scalables.Add(image.GenerateScalablesProperties());
                break;
            case StackPanel stackPanel:
                _scalables.Add(stackPanel.GenerateScalablesProperties());
                break;
            case Panel panel:
                _scalables.Add(panel.GenerateScalablesProperties());
                break;
            case CartesianChart cartesianChart:
                _scalables.Add(cartesianChart.GenerateScalablesProperties());
                break;
        }

        foreach (var child in control.GetVisualChildren())
        {
            if  (child is Control controlChild)
                _scalables.Add(new ScalableObject(controlChild));
                
        }
    }
    
    public void Scale(double scaleFactor)
    {
        _scalables.ForEach(s => s.Scale(scaleFactor));
    }
}