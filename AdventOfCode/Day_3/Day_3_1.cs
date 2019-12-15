using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode

{
    public class Day_3_1
    {
        public static int GetDistanceToClosestIntersection()
        {
            List<string> travelPathA, travelPathB;
            var inputs = Day_3.Day_3_2.GetPuzzleInput(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_3\Input_1.txt");

            GetTravelPaths(inputs, out travelPathA, out travelPathB);

            return GetShortestDistanceToIntersection(travelPathA, travelPathB);
        }

        public static void GetTravelPaths(List<List<string>> inputs, out List<string> travelPathA, out List<string> travelPathB)
        {
            travelPathA = new List<string>();
            travelPathB = new List<string>();
            int counter = 0;

            foreach (var input in inputs)
            {
                counter++;
                int xPos = 0;
                int yPos = 0;

                foreach (var item in input)
                {
                    var stepsToTake = Int32.Parse(Regex.Replace(item, @"[A-Za-z]+", ""));

                    if (item.StartsWith("R"))
                    {
                        xPos = MoveRihgt(travelPathA, travelPathB, counter, xPos, yPos, stepsToTake);
                    }
                    else if (item.StartsWith("L"))
                    {
                        xPos = MoveLeft(travelPathA, travelPathB, counter, xPos, yPos, stepsToTake);
                    }
                    else if (item.StartsWith("U"))
                    {
                        yPos = MoveUp(travelPathA, travelPathB, counter, xPos, yPos, stepsToTake);
                    }
                    else if (item.StartsWith("D"))
                    {
                        yPos = MoveDown(travelPathA, travelPathB, counter, xPos, yPos, stepsToTake);
                    }
                }
            }
        }

        private static int GetShortestDistanceToIntersection(List<string> travelPathA, List<string> travelPathB)
        {
            List<int> resultList = new List<int>();
            var result = travelPathA.Intersect(travelPathB);
            bool hasElement = result.Any();
            if (hasElement)
            {
                foreach (var elemet in result)
                {
                    var foo = elemet.Replace(" ", "").Replace("-", "").Split(',');
                    int a = Int32.Parse(foo[0].ToString());
                    int b = Int32.Parse(foo[1].ToString());
                    resultList.Add(a + b);
                }
            }

            return resultList.Min();
        }

        private static int MoveDown(List<string> travelPathA, List<string> travelPathB, int counter, int xPos, int yPos, int stepsToTake)
        {
            for (int i = yPos - 1; i > yPos - stepsToTake - 1; i--)
            {
                if (counter == 1)
                {
                    travelPathA.Add($"{xPos}, {i}");
                }
                else
                {
                    travelPathB.Add($"{xPos}, {i}");
                }
            }

            yPos -= stepsToTake;
            return yPos;
        }

        private static int MoveUp(List<string> travelPathA, List<string> travelPathB, int counter, int xPos, int yPos, int stepsToTake)
        {
            for (int i = yPos + 1; i < yPos + stepsToTake + 1; i++)
            {
                if (counter == 1)
                {
                    travelPathA.Add($"{xPos}, {i}");
                }
                else
                {
                    travelPathB.Add($"{xPos}, {i}");
                }
            }

            yPos += stepsToTake;
            return yPos;
        }

        private static int MoveLeft(List<string> travelPathA, List<string> travelPathB, int counter, int xPos, int yPos, int stepsToTake)
        {
            for (int i = xPos - 1; i > xPos - stepsToTake - 1; i--)
            {
                if (counter == 1)
                {
                    travelPathA.Add($"{i}, {yPos}");
                }
                else
                {
                    travelPathB.Add($"{i}, {yPos}");
                }
            }
            xPos = xPos - stepsToTake;
            return xPos;
        }

        private static int MoveRihgt(List<string> travelPathA, List<string> travelPathB, int counter, int xPos, int yPos, int stepsToTake)
        {
            for (int i = xPos + 1; i < xPos + stepsToTake + 1; i++)
            {
                if (counter == 1)
                {
                    travelPathA.Add($"{i}, {yPos}");
                }
                else
                {
                    travelPathB.Add($"{i}, {yPos}");
                }
            }
            xPos += stepsToTake;
            return xPos;
        }

        public static List<List<string>> GetPuzzleInput(string path)
        {
            var inputFileArray = File.ReadAllText(path).Split(':');
            //var inputFileArray = "R75,D30,R83,U83,L12,D49,R71,U7,L72:U62,R66,U55,R34,D71,R55,D58,R83".Split(':');

            List<List<string>> returnList = new List<List<string>>();

            foreach (var inputFile in inputFileArray)
            {
                returnList.Add(inputFile.Split(',').ToList());
            }

            return returnList;
        }

    }

}