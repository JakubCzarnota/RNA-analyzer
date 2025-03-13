using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AnalyzerGui.Converters;

public class AddToNumberConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is not int number)
            return null;
        
        if (!int.TryParse(parameter as string, out var parameterNumber))
            return value;
        
        return number + parameterNumber;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}