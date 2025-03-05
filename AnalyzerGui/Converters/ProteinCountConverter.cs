using System;
using System.Globalization;
using Avalonia.Data.Converters;
using CoreAnalyzer;

namespace AnalyzerGui.Converters;

public class ProteinCountConverter : IValueConverter
    
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not Rna rna)
            throw new ArgumentException("Cannot convert a null RNA");
        
        if (!int.TryParse(parameter as string, out var i))
            throw new ArgumentException("Invalid parameter");
        
        return rna.Proteins[i].Count;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}