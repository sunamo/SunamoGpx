namespace SunamoGpx;
using SharpGPX;
using SharpGPX.GPX1_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class SunamoGpxService
{
    public string GenerateGpxFile(string creator, List<Item?> list)
    {
        GpxClass gpx = new GpxClass();
        gpx.Creator = creator;

        foreach (var item in list)
        {
            wptType waypoint = new wptType()
            {
                lat = (decimal)item.position.lat,
                lon = (decimal)item.position.lon,
                name = item.name
            };
            gpx.AddWaypoint(waypoint);
        }

        return gpx.ToXml(GpxVersion.GPX_1_1).Replace("utf-16", "utf-8");
    }
}