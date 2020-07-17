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
            var GetNeighborhoods = from place in JsonData.features
            select place.properties.neighborhood;
            for (int i = 0; i < GetNeighborhoods.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {GetNeighborhoods.ElementAt(i)}");
            }

            var GetNamedNeighborhoods = from place in JsonData.features
                                        where place.properties.neighborhood != ""
                                        select place.properties.neighborhood;
            for(int i = 0; i < GetNamedNeighborhoods.Count(); i++)
            {
                //Console.WriteLine($"{i + 1}. {GetNamedNeighborhoods}");
                Console.WriteLine($"{i + 1}. {GetNamedNeighborhoods.ElementAt(i)}");
                //Console.WriteLine($"{i + 1}. {GetNamedNeighborhoods.Distinct()}");
            }

            var GetDistinctNeighborhoods = from place in JsonData.features
                                        where place.properties.neighborhood != ""
                                        select place.properties.neighborhood;
            for (int i = 0; i < GetDistinctNeighborhoods.Count(); i++)
            {

                Console.WriteLine($"{i + 1}. {GetDistinctNeighborhoods.Distinct().ElementAt(i)}");
            }
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
