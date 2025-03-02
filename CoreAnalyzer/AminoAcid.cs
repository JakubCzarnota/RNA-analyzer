using CoreAnalyzer.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CoreAnalyzer
{
    public class AminoAcid
    {
        public string FullName { get; set; } = string.Empty;

        public string Symbol3 { get; set; } = string.Empty;

        public string Symbol1 { get; set; } = string.Empty;

        public string[] Nucleotides { get; set; } = new string[0];

        public string ClassName { get; set; } = string.Empty;

        [JsonConverter(typeof(StringEnumConverter))]
        public Polarities Polarity { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public NetCharges NetCharge { get; set; }

        public float HydropathyIndex { get; set; }

        public float[]? MolarAbsorptivityWavelength { get; set; }

        public float[]? MolarAbsorptivityCoefficient { get; set; }

        public float MolecularMass { get; set; }

        public float AbundanceInProteinsPercentage { get; set; }

        public string[] StandardGeneticCodingNotation { get; set; } = new string[9];

        public float IsoelectricPoint { get; set; }

        public string GetFormatedPolarity()
        {
            switch (Polarity)
            {
                case Polarities.BasicPolar:
                    return "Basic polar";
                case Polarities.BrønstedBase:
                    return "Brønsted base";
                case Polarities.BrønstedAcid:
                    return "Brønsted acid";
                case Polarities.BrønstedAcidAndBase:
                    return "Brønsted acid and base";
                default:
                    return Polarity.ToString();
            }
        }
    }
}
