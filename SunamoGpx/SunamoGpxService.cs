namespace SunamoGpx;

public class SunamoGpxService
{
    public string GenerateGpxFile(string creator, List<Item?> items)
    {
        GpxClass gpx = new()
        {
            Creator = creator
        };

        foreach (var locationItem in items)
        {
            if (locationItem == null)
            {
                continue;
            }

            wptType waypoint = new()
            {
                lat = (decimal)locationItem.Position.Lat,
                lon = (decimal)locationItem.Position.Lon,
                name = locationItem.Name
            };
            gpx.AddWaypoint(waypoint);
        }

        return gpx.ToXml(GpxVersion.GPX_1_1).Replace("utf-16", "utf-8");
    }
}
