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
            return 0;
        
        return int.TryParse(parameter as string, out var i) ? rna.Proteins[i].Count : 0;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}