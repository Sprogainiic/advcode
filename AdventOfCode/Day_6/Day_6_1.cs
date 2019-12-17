using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_6
{
    public class Day_6_1
    {
        public static void Ipid()
        {
            //var inputList = GetInputData(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_6\Input_6_1_TEST.txt");
            var inputList = GetInputData(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_6\Input_6_1.txt");

            SortedList<string, int> keyValuePairs = new SortedList<string, int>();
            List<string> innerPlanets = new List<string>();
            List<string> outerPlanets = new List<string>();

            foreach (var item in inputList)
            {
                var planets = item.Split(')');
                innerPlanets.Add(planets[0]);
                outerPlanets.Add(planets[1]);
            }

            var counter = 0;
            var innerPlanetIndex = innerPlanets.FindIndex(e => e == "COM");
            var outerPlanet = outerPlanets[innerPlanetIndex];
            var innerPlanetsIndexes = GetInnerPlanetsIndex(outerPlanet, innerPlanets);

            counter++;
            keyValuePairs.Add(outerPlanet, counter);

            var result = GetCountOfDirectAndIndirectOrbits(keyValuePairs, innerPlanets, outerPlanets,  counter, innerPlanetsIndexes);
        }

        private static int GetCountOfDirectAndIndirectOrbits(SortedList<string, int> keyValuePairs, List<string> innerPlanets, List<string> outerPlanets,  int counter,  List<int> innerPlanetsIndexes)
        {
            counter++;
            foreach (var index in innerPlanetsIndexes)
            {
                var outerPlanet = outerPlanets[index];
                innerPlanetsIndexes = GetInnerPlanetsIndex(outerPlanet, innerPlanets);
                keyValuePairs.Add(outerPlanet, counter);
                if (innerPlanetsIndexes.Count > 0)
                {
                    GetCountOfDirectAndIndirectOrbits(keyValuePairs, innerPlanets, outerPlanets,  counter, innerPlanetsIndexes);
                }
            }
            return keyValuePairs.Values.Sum();
        }

        private static List<int> GetInnerPlanetsIndex(string outerPlanet, List<string> innerPlanets)
        {
            List<int> nextInnerPlanetIndexes = new List<int>();
            nextInnerPlanetIndexes = Enumerable.Range(0, innerPlanets.Count)
                                    .Where(j => innerPlanets[j] == outerPlanet)
                                    .ToList();
            return nextInnerPlanetIndexes;
        }

        public static List<string> GetInputData(string path)
        {
            var inputFile = File.ReadAllLines(path);
            var result = new List<string>(inputFile);

            return result;
        }
    }
}
