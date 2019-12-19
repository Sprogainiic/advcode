using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_6
{
    public class Day_6_2
    {
        /// <summary>
        /// This was har, solved thanks to hint from https://github.com/tstavropoulos/AdventOfCode2019/tree/master/Day06
        /// </summary>
        public static void DistanceBetweenMeAndSanta()
        {
            var inputList = GetInputData(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_6\Input_6_2.txt");
            SortedList<string, string> keyValuePairs = new SortedList<string, string>();
            List<string> checkedPlanets = new List<string>();

            // KEY = planets[1] (----- CHILDREN -----) | VALUE = planets[0] (----- PARENT -----)
            foreach (var item in inputList)
            {
                var planets = item.Split(')');
                keyValuePairs.Add(planets[1], planets[0]);
            }

            List<KeyValuePair<string, string>> pathFromMe = new List<KeyValuePair<string, string>>();
            List<KeyValuePair<string, string>> pathFromSanta = new List<KeyValuePair<string, string>>();

            var santasPlantet = keyValuePairs.Where(x => x.Key == "SAN").FirstOrDefault();
            var parentPlanet = keyValuePairs.Where(x => x.Key == "YOU").FirstOrDefault();

            while (parentPlanet.Value != "COM" )
            {
                parentPlanet = keyValuePairs.Where(x => x.Key == parentPlanet.Value).FirstOrDefault();
                pathFromMe.Add(parentPlanet);
            }

            parentPlanet = keyValuePairs.Where(x => x.Key == "SAN").FirstOrDefault();
            while (parentPlanet.Value != "COM")
            {
                parentPlanet = keyValuePairs.Where(x => x.Key == parentPlanet.Value).FirstOrDefault();
                pathFromSanta.Add(parentPlanet);
            }

            var samePlanetInLists = pathFromSanta.FindAll(x => pathFromMe.Contains(x)).FirstOrDefault();

            var myDistance = pathFromMe.IndexOf(samePlanetInLists);
            var santasDistance = pathFromSanta.IndexOf(samePlanetInLists);

            var t = myDistance + santasDistance;
        }


        public static List<string> GetInputData(string path)
        {
            var inputFile = File.ReadAllLines(path);
            var result = new List<string>(inputFile);

            return result;
        }
    }
}
