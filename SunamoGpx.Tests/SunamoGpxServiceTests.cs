namespace SunamoGpx.Tests;
public class SunamoGpxServiceTests
{
    [Fact]
    public async Task GenerateGpxFileTest()
    {
        List<Item> list = new();
        //N, E
        list.Add(new Item("Byt", new Position { lat = double.Parse("50.1115364"), lon = double.Parse("14.4965639") }));
        list.Add(new Item("Leica", new Position { lat = double.Parse("50.0793428"), lon = double.Parse("14.4242769") }));

        SunamoGpxService sunamoGpxService = new();
        var c = sunamoGpxService.GenerateGpxFile("Create with love", list);

        await File.WriteAllTextAsync(@"D:\t.gpx", c);
    }
}
