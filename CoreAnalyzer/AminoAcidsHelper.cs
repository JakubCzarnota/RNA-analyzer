using Newtonsoft.Json;

namespace CoreAnalyzer
{
    public static class AminoAcidsHelper
    {
        public static List<AminoAcid> AllAminoAcids { get; private set; }

        static AminoAcidsHelper()
        {
            var AminoAcidsJsonPath =
                System.IO.Path.GetDirectoryName(
                    System.Diagnostics.Process.GetCurrentProcess().MainModule!.FileName
                ) + "/AminoAcids.json";

            string jsonString = File.ReadAllText(AminoAcidsJsonPath);

            AllAminoAcids = JsonConvert.DeserializeObject<List<AminoAcid>>(jsonString)!;
        }
    }
}
