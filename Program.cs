using System;
using System.Collections.Generic;
using System.Linq;

namespace CitySearch {
    class Program {
        static void Main(string[] args) {
            List<string> cities = new List<string>();
            cities = GetCities();
            cities.Sort((s1, s2) => s1.Length.CompareTo(s2.Length));
            Trie t = new Trie();
            t.CreateRoot();
            foreach(string city in cities) {
                t.Insert((city.ToLower()).ToCharArray());
            }
            CityResult r = new CityResult();
            r = t.Search("san");
            foreach (string i in r.NextCities) {
                try {
                    Console.WriteLine($"\"{i}\"");
                }
                catch {
                    Console.WriteLine("Error finding cities");
                }
            }
            Console.WriteLine("\n-----\n");
            foreach (string i in r.NextLetters) {
                try {
                    Console.WriteLine($"\"{i}\"");
                }
                catch {
                    Console.WriteLine("Error finding letters");
                }
            }
        }
        static public List<string> GetCities() {
            List<string> cityList1 = new List<string> {"New York", "Los Angeles", "Chicago", "San", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose", "Detroit", "Jacksonville", "Indianapolis", "San Francisco", "Columbus", "Austin", "Memphis", "Fort Worth", "Baltimore", "Charlotte", "El Paso", "Boston", "Seattle", "Washington", "Milwaukee", "Denver", "Louisville/Jefferson County", "Las Vegas", "Nashville-Davidson", "Oklahoma City", "Portland", "Tucson", "Albuquerque", "Atlanta", "Long Beach", "Fresno", "Sacramento", "Mesa", "Kansas City", "Cleveland", "Virginia Beach", "Omaha", "Miami", "Oakland", "Tulsa", "Honolulu", "Minneapolis", "Colorado Springs", "Arlington", "Wichita", "Raleigh", "St. Louis", "Santa Ana", "Anaheim", "Tampa", "Cincinnati", "Pittsburgh", "Bakersfield", "Aurora", "Toledo", "Riverside", "Stockton", "Corpus Christi", "Newark", "Anchorage", "Buffalo", "St. Paul", "Lexington-Fayette", "Plano", "Fort Wayne", "St. Petersburg", "Glendale", "Jersey City", "Lincoln", "Henderson", "Chandler", "Greensboro", "Scottsdale", "Baton Rouge", "Birmingham", "Norfolk", "Madison", "New Orleans", "Chesapeake", "Orlando", "Garland", "Hialeah", "Laredo", "Chula Vista", "Lubbock", "Reno", "Akron", "Durham", "Rochester", "Modesto", "Montgomery", "Fremont", "Shreveport", "Arlington", "Glendale"};
            return cityList1;
        }
    }
}
