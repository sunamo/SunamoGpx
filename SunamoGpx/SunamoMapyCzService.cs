namespace SunamoGpx;

public class SunamoMapyCzService(ILogger logger)
{
    public async Task<List<Item?>> AddressToCoords(string apiKey, List<string> addressesToGeocode, bool shouldThrowOnGeocodingFailure)
    {
        List<Item?> result = [];
        HttpClient httpClient = new();
        foreach (var address in addressesToGeocode)
        {
            result.Add(await AddressToCoordsSingle(httpClient, address, apiKey, shouldThrowOnGeocodingFailure));
        }
        return result;
    }

    public async Task<Item?> AddressToCoordsSingle(HttpClient httpClient, string address, string apiKey, bool shouldThrowOnGeocodingFailure)
    {
        string geocodeApi = "https://api.mapy.cz/v1/geocode?query={0}&lang=cs&limit=5&type=regional&type=poi&apikey=" + apiKey;
        var httpResponse = await httpClient.GetAsync(string.Format(geocodeApi, address));
        var response = System.Text.Json.JsonSerializer.Deserialize<GeocodeResponse>(await httpResponse.Content.ReadAsStringAsync());
        if (response == null)
        {
            var message = "Was returned empty response";
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
