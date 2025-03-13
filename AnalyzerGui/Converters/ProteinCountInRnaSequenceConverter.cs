using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;
using CoreAnalyzer;

namespace AnalyzerGui.Converters;

public class ProteinCountInRnaSequenceConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is not List<Protein> proteins ? 0 : proteins.Count;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}