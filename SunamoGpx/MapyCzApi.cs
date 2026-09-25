namespace SunamoGpx;

using System.Text.Json.Serialization;

public class Item(string name, Position position)
{
    public string Name { get; set; } = name;

    public Position Position { get; set; } = position;

    public string? Label { get; set; }

    public string? Type { get; set; }

    public string? Location { get; set; }

    public List<RegionalStructure>? RegionalStructure { get; set; }
}

public class Position
{
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    public override string ToString() => $"{Lat} {Lon}";
}

public class RegionalStructure
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("type")]
    public required string Type { get; set; }

    [JsonPropertyName("isoCode")]
    public required string IsoCode { get; set; }
}

public class GeocodeResponse
{
    [JsonPropertyName("items")]
    public required List<Item> Items { get; set; }

    [JsonPropertyName("locality")]
    public required List<object> Locality { get; set; }
}
