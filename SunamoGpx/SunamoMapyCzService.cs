namespace SunamoGpx;

/// <summary>
/// Service for geocoding addresses using the Mapy.cz API.
/// </summary>
/// <param name="logger">Logger instance for logging warnings and errors.</param>
public class SunamoMapyCzService(ILogger logger)
{
    /// <summary>
    /// Converts multiple addresses to geographical coordinates using Mapy.cz API.
    /// </summary>
    /// <param name="apiKey">The API key for authenticating with Mapy.cz API.</param>
    /// <param name="addressesToGeocode">The list of addresses to geocode.</param>
    /// <param name="shouldThrowOnGeocodingFailure">If true, throws an exception when geocoding fails; otherwise, logs a warning and returns null.</param>
    /// <returns>A list of geocoded items, with null entries for addresses that could not be geocoded.</returns>
    public async Task<List<Item?>> AddressToCoords(string apiKey, List<string> addressesToGeocode, bool shouldThrowOnGeocodingFailure)
    {
        List<Item?> result = [];
        HttpClient httpClient = new();
        foreach (var item in addressesToGeocode)
        {
            result.Add(await AddressToCoordsSingle(httpClient, item, apiKey, shouldThrowOnGeocodingFailure));
        }
        return result;
    }

    /// <summary>
    /// Converts a single address to geographical coordinates using Mapy.cz API.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for making API requests.</param>
    /// <param name="address">The address to geocode.</param>
    /// <param name="apiKey">The API key for authenticating with Mapy.cz API.</param>
    /// <param name="shouldThrowOnGeocodingFailure">If true, throws an exception when geocoding fails; otherwise, logs a warning and returns null.</param>
    /// <returns>The geocoded item if successful; otherwise, null.</returns>
    public async Task<Item?> AddressToCoordsSingle(HttpClient httpClient, string address, string apiKey, bool shouldThrowOnGeocodingFailure)
    {
        string geocodeApi = "https://api.mapy.cz/v1/geocode?query={0}&lang=cs&limit=5&type=regional&type=poi&apikey=" + apiKey;
        var jsonString = await httpClient.GetAsync(string.Format(geocodeApi, address));
        var response = System.Text.Json.JsonSerializer.Deserialize<GeocodeResponse>(await jsonString.Content.ReadAsStringAsync());
        if (response == null)
        {
            var message = $"Was returned empty response";
            if (shouldThrowOnGeocodingFailure)
            {
                ThrowEx.Custom(message);
                return null;
            }
            else
            {
                logger.LogWarning("For address {address} was not found any coordinates", address);
                return null;
            }
        }
        if (response.Items.Count == 0)
        {
            logger.LogWarning("For address {address} was not found any coordinates", address);
            if (shouldThrowOnGeocodingFailure)
            {
                ThrowEx.Custom($"For address {address} was not found any coordinates");
            }
        }
        else
        {
            var firstItem = response.Items.First();
            firstItem.Name = address;
            return firstItem;
        }
        return null;
    }
}
