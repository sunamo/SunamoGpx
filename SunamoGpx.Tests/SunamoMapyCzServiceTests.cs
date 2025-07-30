using SunamoTest;

namespace SunamoGpx.Tests;

public class SunamoMapyCzServiceTests
{
    [Fact]
    public async Task AddressToCoordsSingleTest()
    {
        SunamoMapyCzService sunamoMapyCz = new(TestLogger.Instance);

        string key = string.Empty;

        if (key == string.Empty)
        {
            throw new Exception("Key will be loaded securely later");
        }

        //HttpClient httpClient = new();
        //var r = await sunamoMapyCz.AddressToCoordsSingle(httpClient, "Podn�dra�n� 8, Praha", key, true);

        //var position = r.Position.ToString();
    }

}