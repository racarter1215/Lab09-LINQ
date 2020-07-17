using System;
using System.Collections.Generic;
using System.Text;

namespace Lab09_LINQ.classes
{
    class Root
    {
        public string type { get; set; }
        public IEnumerable<Feature> features { get; set; }
    }
}
