namespace SunamoGpx;
using Microsoft.Extensions.Logging;
using SunamoGpx._sunamo;

public class SunamoMapyCzService(ILogger logger)
{
    public async Task<List<Item>> AddressToCoords(string api_key, List<string> addressToGeocode, string fileToSave, string[] alreadyExisting, bool throwExWhenCouldNotBeGeocoded)
    {
        List<Item> result = new List<Item>();
        HttpClient httpClient = new HttpClient();

        foreach (var item in addressToGeocode)
        {
            var geocodeResult = await AddressToCoordsSingle(httpClient, item, api_key, throwExWhenCouldNotBeGeocoded);
            if (geocodeResult != null)
            {
                result.Add(geocodeResult);
            }
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
            }
            else
            {
                logger.LogWarning($"For address {address} was not found any coordinates");
            }
        }

        if (!resp.items.Any())
        {
            var message = $"For address {address} was not found any coordinates";
            if (throwExWhenCouldNotBeGeocoded)
            {
                ThrowEx.Custom(message);
            }
            else
            {
                logger.LogWarning(message);
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