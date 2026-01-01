namespace SunamoGpx;

/// <summary>
/// Service for generating GPX files from geocoded locations.
/// </summary>
public class SunamoGpxService
{
    /// <summary>
    /// Generates a GPX file in XML format from a list of location items.
    /// </summary>
    /// <param name="creator">The creator name to be included in the GPX file metadata.</param>
    /// <param name="items">The list of location items to include as waypoints in the GPX file. Null items are skipped.</param>
    /// <returns>A string containing the GPX file content in UTF-8 encoded XML format.</returns>
    public string GenerateGpxFile(string creator, List<Item?> items)
    {
        GpxClass gpx = new()
        {
            Creator = creator
        };

        foreach (var item in items)
        {
            if (item == null)
            {
                continue;
            }

            wptType waypoint = new()
            {
                lat = (decimal)item.Position.Lat,
                lon = (decimal)item.Position.Lon,
                name = item.Name
            };
            gpx.AddWaypoint(waypoint);
        }

        return gpx.ToXml(GpxVersion.GPX_1_1).Replace("utf-16", "utf-8");
    }
}