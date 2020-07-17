using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.classes
{//below is a class called feature that holds the type, geoLocation, and Properties from the json
    public class Feature
    {
        public string type { get; set; }
        public GeoLocation geoLocation { get; set; }
        public Properties properties { get; set; }

    }
}
