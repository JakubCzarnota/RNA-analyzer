using System.Numerics;

namespace AnalyzerGui;

public static class Utils
{
    public static string FormatedToString(this object? value) => 
        value switch
        {
            null => string.Empty,
            object[] array => string.Join(", ", array),
            int[] i  => string.Join(", ", i),
            float[] f  => string.Join(", ", f),
            int i => $"{i}",
            float f => $"{f}",
            _ => value.ToString()!
        };
    
    public static string CapitalizeOnlyFirstLetter(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        return char.ToUpper(value[0]) + value.Substring(1).ToLower();
    }
}