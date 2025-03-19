using System.Collections.Generic;
using System.Numerics;
using static System.Text.RegularExpressions.Regex;

namespace AnalyzerGui;

public static class Utils
{
    public static string FormatCamelCase(this string str) => Replace(
        Replace(
            str,
            @"(\P{Ll})(\P{Ll}\p{Ll})",
            "$1 $2"
        ),
        @"(\p{Ll})(\P{Ll})",
        "$1 $2").CapitalizeOnlyFirstLetter();
    
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

    public static void ReplaceValuesWith<T>(this ICollection<T> collection, ICollection<T> newCollection)
    {
        collection.Clear();
        foreach (var value in newCollection)
        {
            collection.Add(value);
        }
    }
}