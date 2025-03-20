using System;
using System.Collections.Generic;
using System.IO;
using CoreAnalyzer;
using Newtonsoft.Json;

namespace AnalyzerGui;

public static class OptionsHelper
{
    private static string _optionsFilePath =
        System.IO.Path.GetDirectoryName(
            System.Diagnostics.Process.GetCurrentProcess().MainModule!.FileName
        ) + "/options.json";
    
    public static Options Load()
    {
        try
        {
            var jsonString = File.ReadAllText(_optionsFilePath);

            return JsonConvert.DeserializeObject<Options>(jsonString)!;

        }
        catch (Exception)
        {
            return new Options().Save();
        }
    }

    public static Options Save(this Options options)
    {
        var jsonString = JsonConvert.SerializeObject(options);
        
        File.WriteAllText(_optionsFilePath, jsonString);
        
        return options;
    }
}