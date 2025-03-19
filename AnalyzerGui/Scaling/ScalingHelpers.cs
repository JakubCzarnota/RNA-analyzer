using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using LiveChartsCore.Kernel.Sketches;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Avalonia;

namespace AnalyzerGui.Scaling;

public static class ScalingHelpers
{
    public static List<IScalable> GenerateScalablesProperties(this Button button) =>
    [
        new ScalableProperty<Button, double>(
            button,
            button.FontSize,
            (b, d, s) =>
            {
                b.FontSize = d * s;
            }),
        new ScalableProperty<Button, double>(
            button,
            button.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<Button, double>(
            button,
            button.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
        new ScalableProperty<Button, Thickness>(
            button,
            button.Padding,
            (b, d, s) =>
            {
                b.Padding = d * s;
            }),
    ];

    public static List<IScalable> GenerateScalablesProperties(this TextBlock textBlock) =>
    [
        new ScalableProperty<TextBlock, double>(
            textBlock,
            textBlock.FontSize,
            (b, d, s) =>
            {
                b.FontSize = d * s;
            }),
        new ScalableProperty<TextBlock, double>(
            textBlock,
            textBlock.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<TextBlock, double>(
            textBlock,
            textBlock.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
        new ScalableProperty<TextBlock, Thickness>(
            textBlock,
            textBlock.Padding,
            (b, d, s) =>
            {
                b.Padding = d * s;
            }),
    ];
    
    public static List<IScalable> GenerateScalablesProperties(this TextBox textBox) =>
    [
        new ScalableProperty<TextBox, double>(
            textBox,
            textBox.FontSize,
            (b, d, s) =>
            {
                b.FontSize = d * s;
            }),
        new ScalableProperty<TextBox, double>(
            textBox,
            textBox.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<TextBox, double>(
            textBox,
            textBox.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
        new ScalableProperty<TextBox, Thickness>(
            textBox,
            textBox.Padding,
            (b, d, s) =>
            {
                b.Padding = d * s;
            }),
    ];
    
    public static List<IScalable> GenerateScalablesProperties(this ComboBox comboBox) =>
    [
        new ScalableProperty<ComboBox, double>(
            comboBox,
            comboBox.FontSize,
            (b, d, s) =>
            {
                b.FontSize = d * s;
            }),
        new ScalableProperty<ComboBox, double>(
            comboBox,
            comboBox.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<ComboBox, double>(
            comboBox,
            comboBox.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
        new ScalableProperty<ComboBox, Thickness>(
            comboBox,
            comboBox.Padding,
            (b, d, s) =>
            {
                b.Padding = d * s;
            }),
    ];

    public static List<IScalable> GenerateScalablesProperties(this Label label) =>
    [
        new ScalableProperty<Label, double>(
            label,
            label.FontSize,
            (b, d, s) =>
            {
                b.FontSize = d * s;
            }),
        new ScalableProperty<Label, double>(
            label,
            label.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<Label, double>(
            label,
            label.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
        new ScalableProperty<Label, Thickness>(
            label,
            label.Padding,
            (b, d, s) =>
            {
                b.Padding = d * s;
            }),
    ];

    public static List<IScalable> GenerateScalablesProperties(this Image image) =>
    [
        new ScalableProperty<Image, double>(
            image,
            image.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<Image, double>(
            image,
            image.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
    ];
    
    public static List<IScalable> GenerateScalablesProperties(this Panel panel) =>
    [
        new ScalableProperty<Panel, double>(
            panel,
            panel.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<Panel, double>(
            panel,
            panel.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
    ];

    public static List<IScalable> GenerateScalablesProperties(this StackPanel stackPanel) =>
    [
        new ScalableProperty<StackPanel, double>(
            stackPanel,
            stackPanel.Width,
            (b, d, s) =>
            {
                b.Width = d * s;
            }),
        new ScalableProperty<StackPanel, double>(
            stackPanel,
            stackPanel.Height,
            (b, d, s) =>
            {
                b.Height = d * s;
            }),
    ];

    public static List<IScalable> GenerateScalablesProperties(this CartesianChart cartesianChart) =>
    [
        new ScalableProperty<CartesianChart, List<double>>(
            cartesianChart,
            cartesianChart.YAxes.Select(a => a.TextSize).ToList(),
            (b, d, s) =>
            {
                for (var i = 0; i < b.XAxes.Count() && i < d.Count(); i++)
                {
                    b.XAxes.ElementAt(i).TextSize = d[i] * s;
                }
            }),
        new ScalableProperty<CartesianChart, List<double>>(
            cartesianChart,
            cartesianChart.YAxes.Select(a => a.TextSize).ToList(),
            (b, d, s) =>
            {
                for (var i = 0; i < b.YAxes.Count() && i < d.Count; i++)
                {
                    b.YAxes.ElementAt(i).TextSize = d[i] * s;
                }
            }),
    ];

}