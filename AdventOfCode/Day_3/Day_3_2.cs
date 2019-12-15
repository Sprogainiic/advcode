using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Day_3
{
    public class Day_3_2
    {
        public static void GetDistanceToClosestIntersection()
        {
            var inputTextLists = GetPuzzleInput(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_3\Input_2.txt");
            List<string> travelPathA, travelPathB;
            List<int> result = new List<int>();

            Day_3_1.GetTravelPaths(inputTextLists, out travelPathA, out travelPathB);

            var intersectionPoints = travelPathA.Intersect(travelPathB);

            foreach (var intersectionPoint in intersectionPoints)
            {
                var a = travelPathA.FindIndex(x => x == intersectionPoint) + 1;
                var b = travelPathB.FindIndex(x => x == intersectionPoint) + 1;

                result.Add(a + b);

            }

            var finalResult = result.Min();
        }

        public static List<List<string>> GetPuzzleInput(string path)
        {
            List<List<string>> returnList = new List<List<string>>();

            var inputFileString = File.ReadAllText(path);
            //var inputFileString = $"R75,D30,R83,U83,L12,D49,R71,U7,L72{ Environment.NewLine }U62,R66,U55,R34,D71,R55,D58,R83";
            //var inputFileString = $"R8,U5,L5,D3{ Environment.NewLine }U7,R6,D4,L4";
            //var inputFileString = $"R2,D2,L1,D2,L7{ Environment.NewLine }U2,L2,D8,L3,U3";
            //var inputFileString = $"R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51{ Environment.NewLine }U98,R91,D20,R16,D67,R40,U7,R15,U6,R7";


            string[] inputFileArray = inputFileString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            foreach (var inputFile in inputFileArray)
            {
                returnList.Add(inputFile.Split(',').ToList());
            }

            return returnList;
        }
    }
}
