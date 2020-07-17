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
    {/// <summary>
    /// the below code string sets my JsonData as a global variable
    /// </summary>
        public static Root JsonData { get; set; }
        /// <summary>
        /// the below method calls the GetJson method and contains the logic to access the json in various ways
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        { 
        ///below is the GetJson method call
            GetJson();
            Console.WriteLine("========================");
            ///below is a variable that searches the json for all neighborhoods
            var GetNeighborhoods = from place in JsonData.features
            select place.properties.neighborhood;
            for (int i = 0; i < GetNeighborhoods.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {GetNeighborhoods.ElementAt(i)}");
            }
            Console.WriteLine("1 ========================");
            ///below is a variable that searches the json for all neighborhoods that aren't represented by blank spaces
            var GetNamedNeighborhoods = from aNeighborhood in GetNeighborhoods
                                           where aNeighborhood != ""
                                           select new { aNeighborhood };
            for(int i = 0; i < GetNamedNeighborhoods.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {GetNamedNeighborhoods.ElementAt(i).aNeighborhood}");                
            }
            Console.WriteLine("========================");
            ///below is a variable that searches the json for all neighborhoods that aren't represted by blank spaces with no duplicates
            var GetDistinctNeighborhoods = (from aNeighborhood in GetNamedNeighborhoods
                                            select new { aNeighborhood.aNeighborhood }).Distinct();
            for (int i = 0; i < GetDistinctNeighborhoods.Count(); i++)
            {

                Console.WriteLine($"{i + 1}. {GetDistinctNeighborhoods.ElementAt(i).aNeighborhood}");
            }
            Console.WriteLine("========================");

            ///below is a variable that searches the json for all neighborhoods that aren't represted by blank spaces with no duplicates rendered in one variable, rather than 3 like above
            var ConsolidatedCall = (from place in JsonData.features
                                   where place.properties.neighborhood != ""                                   
                                   select place.properties.neighborhood).Distinct();
            for(int i = 0; i < ConsolidatedCall.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {ConsolidatedCall.ElementAt(i)}");
            }
            Console.WriteLine("========================");
            
            ///below is the call for the ConsolidatedCallMethodCall method
            ConsolidatedCallMethodCall();
        }
        /// <summary>
        /// below is a method thatis is the refactored version of var ConsolidatedCall
        /// </summary>
        public static void ConsolidatedCallMethodCall()
        {
            var ConsolidatedCallMethod = JsonData.features
            .Select(x => new { x.properties.neighborhood })
            .Where(x => x.neighborhood != "")
            .Distinct();

            for (int i = 0; i < ConsolidatedCallMethod.Count(); i++)
            {
                Console.WriteLine($"{i + 1}. {ConsolidatedCallMethod.ElementAt(i).neighborhood}");
            }
            Console.WriteLine("========================");
        }
        /// <summary>
        /// below is a method that gets the json data for neighborhood and renders it to the terminal
        /// </summary>
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
