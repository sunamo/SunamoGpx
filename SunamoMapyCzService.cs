namespace SunamoGpx;
public class SunamoMapyCzService(ILogger logger)
{
    public async Task<List<Item?>> AddressToCoords(string api_key, List<string> addressToGeocode, bool throwExWhenCouldNotBeGeocoded)
    {
        List<Item?> result = new();
        HttpClient httpClient = new();
        foreach (var item in addressToGeocode)
        {
            result.Add(await AddressToCoordsSingle(httpClient, item, api_key, throwExWhenCouldNotBeGeocoded));
        }
        return result;
    }
    public async Task<Item?> AddressToCoordsSingle(HttpClient httpClient, string address, string api_key, bool throwExWhenCouldNotBeGeocoded)
    {
        string geocodeApi = "https://api.mapy.cz/v1/geocode?query={0}&lang=cs&limit=5&type=regional&type=poi&apikey=" + api_key;
        var jsonString = await httpClient.GetAsync(string.Format(geocodeApi, address));
        var resp = System.Text.Json.JsonSerializer.Deserialize<GeocodeResponse>(await jsonString.Content.ReadAsStringAsync());
        if (resp == null)
        {
            var message = $"Was returned empty response";
            if (throwExWhenCouldNotBeGeocoded)
            {
                ThrowEx.Custom(message);
                return null;
            }
            else
            {
                logger.LogWarning(message: $"For address {address} was not found any coordinates");
                return null;
            }
        }
        if (resp.items.Count == 0)
        {
            var message = $"For address {address} was not found any coordinates";
            if (throwExWhenCouldNotBeGeocoded)
            {
                ThrowEx.Custom(message);
            }
            else
            {
                logger.LogWarning(message: message);
            }
        }
        else
        {
            var first = resp.items.First();
            first.name = address;
            return first;
        }
        return null;
    }
}