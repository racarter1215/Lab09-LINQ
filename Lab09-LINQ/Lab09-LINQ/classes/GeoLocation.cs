using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.classes
{/// <summary>
/// below is a class that holds the type and coordinates for each json entry
/// </summary>
    public class GeoLocation
    {
        public string Type { get; set; }
        public List<double> Coordinates { get; set; }
    }
}
