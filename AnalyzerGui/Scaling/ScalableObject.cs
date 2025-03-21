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
                _scalables.Add(button.GenerateScalableProperties());
                break;
            case TextBlock textBlock:
                _scalables.Add(textBlock.GenerateScalableProperties());
                break;
            case TextBox textBox:
                _scalables.Add(textBox.GenerateScalableProperties());
                break;
            case ComboBox comboBox:
                _scalables.Add(comboBox.GenerateScalableProperties());
                break;
            case Label label:
                _scalables.Add(label.GenerateScalableProperties());
                break;
            case Image image:
                _scalables.Add(image.GenerateScalableProperties());
                break;
            case StackPanel stackPanel:
                _scalables.Add(stackPanel.GenerateScalableProperties());
                break;
            case Panel panel:
                _scalables.Add(panel.GenerateScalableProperties());
                break;
            case CartesianChart cartesianChart:
                _scalables.Add(cartesianChart.GenerateScalableProperties());
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