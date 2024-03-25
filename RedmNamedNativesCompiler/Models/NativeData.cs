using System.Text.Json.Serialization;

namespace RedmNamedNativesCompiler.Models;

public class NativeData
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    // [JsonPropertyName("params")]
    // public List<Param> Params { get; set; }

    [JsonPropertyName("results")]
    public string Results { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    // [JsonPropertyName("examples")]
    // public List<object> Examples { get; set; }

    [JsonPropertyName("hash")]
    public string Hash { get; set; }

    [JsonPropertyName("ns")]
    public string Ns { get; set; }

    // [JsonPropertyName("aliases")]
    // public List<string> Aliases { get; set; }

    [JsonPropertyName("manualHash")]
    public bool ManualHash { get; set; }
}