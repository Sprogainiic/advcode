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
        public static void DistanceBetweenMeAndSanta()
        {
            var inputList = GetInputData(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_6\Input_6_2_TEST.txt");
            //var inputList = GetInputData(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_6\Input_6_1.txt");

            SortedList<string, int> keyValuePairs = new SortedList<string, int>();
            List<string> innerPlanets = new List<string>();
            List<string> outerPlanets = new List<string>();

            foreach (var item in inputList)
            {
                var planets = item.Split(')');
                innerPlanets.Add(planets[0]);
                outerPlanets.Add(planets[1]);
            }

            var myOrbitIndex = outerPlanets.FindIndex(e => e == "YOU");
            var myorbit = innerPlanets[myOrbitIndex]; // I'm orbition around myorbit

            var santasOrbitIndex = outerPlanets.FindIndex(e => e == "SAN");
            var santasOrbit = innerPlanets[santasOrbitIndex]; // I'm orbition around myorbit

            var nextOrbitIndex = outerPlanets.FindIndex(e => e == "YOU");
            var nextOrbit = innerPlanets[nextOrbitIndex];


            FindNextOrbits(myorbit, outerPlanets, innerPlanets);

            while (nextOrbit != santasOrbit)
            {
                var temp = nextOrbit;
                nextOrbitIndex = outerPlanets.IndexOf(nextOrbit);
                nextOrbit = innerPlanets[nextOrbitIndex];

                if (innerPlanets.Where(p => p == nextOrbit).ToList().Count() > 1)
                {
                    List<int> nextInnerPlanetIndexes = new List<int>();
                    nextInnerPlanetIndexes = Enumerable.Range(0, innerPlanets.Count)
                                            .Where(j => innerPlanets[j] == nextOrbit)
                                            .ToList();
                    foreach (var item in nextInnerPlanetIndexes)
                    {
                        //nextOrbitIndex = outerPlanets.IndexOf(item);
                        if (temp != outerPlanets[item])
                        {
                            nextOrbit = outerPlanets[item];
                        }
                        if (nextOrbit == santasOrbit)
                        {
                            break;
                        }
                    }
                }
            }







            var counter = 0;
            var outerPlanetIndex = outerPlanets.FindIndex(e => e == "YOU");
            var innerPlanet = innerPlanets[outerPlanetIndex];
            var innerPlanetsIndexes = GetInnerPlanetsIndex(innerPlanet, outerPlanets);

            counter++;
            keyValuePairs.Add(innerPlanet, counter);

            var result = GetCountOfDirectAndIndirectOrbits(keyValuePairs, innerPlanets, outerPlanets, counter, innerPlanetsIndexes);
        }







        private static void FindNextOrbits(string nextOrbit, List<string> outerPlanets, List<string> innerPlanets)
        {
            var currentOrbit = nextOrbit;
            var nextInnerPlanetIndexes = Enumerable.Range(0, innerPlanets.Count)
                        .Where(j => innerPlanets[j] == nextOrbit)
                        .ToList();

            foreach (var index in nextInnerPlanetIndexes)
            {
                if (outerPlanets[index] == "I")
                {
                    break;
                }
                FindNextOrbits(outerPlanets[index], outerPlanets, innerPlanets);
            }
        }









        private static int GetCountOfDirectAndIndirectOrbits(SortedList<string, int> keyValuePairs, List<string> innerPlanets, List<string> outerPlanets, int counter, List<int> innerPlanetsIndexes)
        {
            counter++;
            foreach (var index in innerPlanetsIndexes)
            {
                var outerPlanet = outerPlanets[index];
                innerPlanetsIndexes = GetInnerPlanetsIndex(outerPlanet, innerPlanets);
                keyValuePairs.Add(outerPlanet, counter);
                if (innerPlanetsIndexes.Count > 0)
                {
                    GetCountOfDirectAndIndirectOrbits(keyValuePairs, innerPlanets, outerPlanets, counter, innerPlanetsIndexes);
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
