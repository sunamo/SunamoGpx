namespace SunamoGpx.Tests;

/// <summary>
/// Unit tests for the SunamoGpxService class.
/// </summary>
public class SunamoGpxServiceTests
{
    /// <summary>
    /// Tests the GenerateGpxFile method to ensure it correctly generates a GPX file.
    /// </summary>
    [Fact]
    public async Task GenerateGpxFileTest()
    {
        List<Item?> items = new();
        //N, E
        items.Add(new Item("Byt", new Position { Lat = double.Parse("50.1115364"), Lon = double.Parse("14.4965639") }));
        items.Add(new Item("Leica", new Position { Lat = double.Parse("50.0793428"), Lon = double.Parse("14.4242769") }));

        SunamoGpxService sunamoGpxService = new();
        var gpxContent = sunamoGpxService.GenerateGpxFile("Create with love", items);

        await File.WriteAllTextAsync(@"D:\t.gpx", gpxContent);
    }
}
