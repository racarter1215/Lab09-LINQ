using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab09_LINQ.classes;
using Newtonsoft.Json;


namespace Lab09_LINQ
{
    class Program
    {
        public static Root JsonData { get; set; }
        static void Main(string[] args)
        {
            GetJson();
        }

        public static void GetJson()
        {
            string rawData = File.ReadAllText("../../../assets/data.json");
            JsonData = JsonConvert.DeserializeObject<Root>(rawData);

            foreach (var item in JsonData.features)
            {
                Console.WriteLine(item.properties.neighborhood);
            }
        }
    }
}
