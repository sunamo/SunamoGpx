namespace SunamoGpx;
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
public class Item
{
    public string name { get; set; }
    public string label { get; set; }
    public Position position { get; set; }
    public string type { get; set; }
    public string location { get; set; }
    public List<RegionalStructure> regionalStructure { get; set; }
}

public class Position
{
    public double lon { get; set; }
    public double lat { get; set; }

    public override string ToString()
    {
        return lat + " " + lon;
    }
}

public class RegionalStructure
{
    public string name { get; set; }
    public string type { get; set; }
    public string isoCode { get; set; }
}

public class GeocodeResponse
{
    public List<Item> items { get; set; }
    public List<object> locality { get; set; }
}