namespace SunamoGpx;

using System.Text.Json.Serialization;

/// <summary>
/// Item.
/// </summary>
/// <param name="name">The name.</param>
/// <param name="position">The position.</param>
/// <returns>The item result.</returns>
public class Item(string name, Position position)
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets the position.
    /// </summary>
    public Position Position { get; set; } = position;

    /// <summary>
    /// Gets or sets the label.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the location.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Gets or sets the regional structure.
    /// </summary>
    public List<RegionalStructure>? RegionalStructure { get; set; }
}

/// <summary>
/// Represents the position type.
/// </summary>
public class Position
{
    /// <summary>
    /// Gets or sets the lon.
    /// </summary>
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    /// <summary>
    /// Gets or sets the lat.
    /// </summary>
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    /// <summary>
    /// Returns a string representation of the position in "latitude longitude" format.
    /// </summary>
    /// <returns>A string containing the latitude and longitude separated by a space.</returns>
    public override string ToString() => $"{Lat} {Lon}";
}

/// <summary>
/// Represents the regional structure type.
/// </summary>
public class RegionalStructure
{
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the type.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Gets or sets the iso code.
    /// </summary>
    [JsonPropertyName("isoCode")]
    public required string IsoCode { get; set; }
}

/// <summary>
/// Represents the geocode response type.
/// </summary>
public class GeocodeResponse
{
    /// <summary>
    /// Gets or sets the items.
    /// </summary>
    [JsonPropertyName("items")]
    public required List<Item> Items { get; set; }

    /// <summary>
    /// Gets or sets the locality.
    /// </summary>
    [JsonPropertyName("locality")]
    public required List<object> Locality { get; set; }
}
