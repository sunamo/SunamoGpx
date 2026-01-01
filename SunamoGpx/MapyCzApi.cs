using System.Text.Json.Serialization;

namespace SunamoGpx;

/// <summary>
/// Represents a geocoded location item from Mapy.cz API response.
/// </summary>
public class Item(string name, Position position)
{
    /// <summary>
    /// Gets or sets the name of the location.
    /// </summary>
    public string Name { get; set; } = name;

    /// <summary>
    /// Gets or sets the geographical position of the location.
    /// </summary>
    public Position Position { get; set; } = position;

    /// <summary>
    /// Gets or sets the label of the location.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the type of the location.
    /// </summary>
    public string? Type { get; set; }

    /// <summary>
    /// Gets or sets the location description.
    /// </summary>
    public string? Location { get; set; }

    /// <summary>
    /// Gets or sets the regional structure information.
    /// </summary>
    public List<RegionalStructure>? RegionalStructure { get; set; }
}

/// <summary>
/// Represents a geographical position with longitude and latitude coordinates.
/// </summary>
public class Position
{
    /// <summary>
    /// Gets or sets the longitude coordinate.
    /// </summary>
    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    /// <summary>
    /// Gets or sets the latitude coordinate.
    /// </summary>
    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    /// <summary>
    /// Returns a string representation of the position in "latitude longitude" format.
    /// </summary>
    /// <returns>A string containing the latitude and longitude separated by a space.</returns>
    public override string ToString()
    {
        return Lat + " " + Lon;
    }
}

/// <summary>
/// Represents the regional structure information of a location.
/// </summary>
public class RegionalStructure
{
    /// <summary>
    /// Gets or sets the name of the regional structure.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// Gets or sets the type of the regional structure.
    /// </summary>
    [JsonPropertyName("type")]
    public required string Type { get; set; }

    /// <summary>
    /// Gets or sets the ISO code of the regional structure.
    /// </summary>
    [JsonPropertyName("isoCode")]
    public required string IsoCode { get; set; }
}

/// <summary>
/// Represents the response from Mapy.cz geocoding API.
/// </summary>
public class GeocodeResponse
{
    /// <summary>
    /// Gets or sets the list of geocoded items.
    /// </summary>
    [JsonPropertyName("items")]
    public required List<Item> Items { get; set; }

    /// <summary>
    /// Gets or sets the locality information.
    /// </summary>
    [JsonPropertyName("locality")]
    public required List<object> Locality { get; set; }
}