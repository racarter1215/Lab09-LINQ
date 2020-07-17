using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            Console.WriteLine("========================");
            var GetNamedNeighborhoods = from aNeighborhood in GetNeighborhoods
                                           where aNeighborhood != ""
                                           select new { aNeighborhood };
            for(int i = 0; i < GetNamedNeighborhoods.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {GetNamedNeighborhoods.ElementAt(i).aNeighborhood}");                
            }
            Console.WriteLine("========================");

            var GetDistinctNeighborhoods = (from aNeighborhood in GetNamedNeighborhoods
                                            select new { aNeighborhood.aNeighborhood }).Distinct();
            for (int i = 0; i < GetDistinctNeighborhoods.Count(); i++)
            {

                Console.WriteLine($"{i + 1}. {GetDistinctNeighborhoods.ElementAt(i).aNeighborhood}");
            }
            Console.WriteLine("========================");
            var ConsolidatedCall = (from place in JsonData.features
                                   where place.properties.neighborhood != ""                                   
                                   select place.properties.neighborhood).Distinct();
            for(int i = 0; i < ConsolidatedCall.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {ConsolidatedCall.ElementAt(i)}");
            }
            Console.WriteLine("========================");
        }
        public void ConsolidatedCall()
        {
            var ConsolidatedCallMethod = JsonData.features
            .Select(x => new { x.properties.neighborhood })
            .Where(x => x.neighborhood != "")
            .Distinct();

            for (int i = 0; i < ConsolidatedCallMethod.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {ConsolidatedCallMethod.ElementAt(i)}");
            }
        }
        public static void GetJson()
        {
            string rawData = File.ReadAllText("../../../assets/data.json");
            JsonData = JsonConvert.DeserializeObject<Root>(rawData);

            foreach (var item in JsonData.features)
            {
                //Console.WriteLine(item.properties.neighborhood);
            }
        }
    }
}
