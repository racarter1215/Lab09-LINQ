using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.classes
{/// <summary>
/// below is a class that holds the name of the array that all json is in and the first keyword within it
/// </summary>
    class Root
    {
        public string type { get; set; }
        public IEnumerable<Feature> features { get; set; }
    }
}
