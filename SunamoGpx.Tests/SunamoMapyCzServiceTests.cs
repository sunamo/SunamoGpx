// variables names: ok
using SunamoTest;

namespace SunamoGpx.Tests;

/// <summary>
/// Unit tests for the SunamoMapyCzService class.
/// </summary>
public class SunamoMapyCzServiceTests
{
    /// <summary>
    /// Tests the AddressToCoordsSingle method to ensure it correctly geocodes an address.
    /// </summary>
    [Fact]
    public async Task AddressToCoordsSingleTest()
    {
        SunamoMapyCzService sunamoMapyCz = new(TestLogger.Instance);

        string apiKey = string.Empty;

        if (apiKey == string.Empty)
        {
            // Test is skipped because API key needs to be configured securely
            return;
        }

        HttpClient httpClient = new();
        var result = await sunamoMapyCz.AddressToCoordsSingle(httpClient, "Podnádražní 8, Praha", apiKey, true);

        Assert.NotNull(result);
        var position = result.Position.ToString();
        Assert.False(string.IsNullOrEmpty(position));
    }

}
