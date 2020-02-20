namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Cartridge
    {
        [JsonProperty("data")]
        public Question[] Data { get; set; }
    }

    public partial class Question
    {
        [JsonProperty("questiontext")]
        public string Questiontext { get; set; }

        [JsonProperty("answers")]
        public string[] Answers { get; set; }

        [JsonProperty("correctanswers")]
        public int[] Correctanswers { get; set; }
    }

    public partial class Cartridge
    {
        public static Cartridge FromJson(string json) => JsonConvert.DeserializeObject<Cartridge>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Cartridge self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
        {
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
        };
    }
}