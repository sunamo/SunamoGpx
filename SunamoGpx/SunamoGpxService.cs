// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoGpx;

public class SunamoGpxService
{
    public string GenerateGpxFile(string creator, List<Item?> list)
    {
        GpxClass gpx = new()
        {
            Creator = creator
        };

        foreach (var item in list)
        {
            if (item == null)
            {
                continue;
            }

            wptType waypoint = new()
            {
                lat = (decimal)item.Position.lat,
                lon = (decimal)item.Position.lon,
                name = item.Name
            };
            gpx.AddWaypoint(waypoint);
        }

        return gpx.ToXml(GpxVersion.GPX_1_1).Replace("utf-16", "utf-8");
    }
}