using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_1_2
    {

        public static int CalculateFullFuelRequirements()
        {
            int totalRequireedFuel = 0;
            var moduleMasses = GetInputData(@"J:\My Documents\adventofcode\Input1.txt");

            foreach (var moduleMass in moduleMasses)
            {
                var result = DoCalculation(Int32.Parse(moduleMass));
                totalRequireedFuel = totalRequireedFuel + result;
            }

            return totalRequireedFuel;
        }

        public static List<string> GetInputData(string path)
        {
            var inputFile = File.ReadAllLines(path);
            var result = new List<string>(inputFile);
            return result;
        }

        public static int DoCalculation(int moduleMass)
        {
            decimal result = 0;
            List<int> results = new List<int>();
            var moduleMassResult = (decimal)moduleMass;

            while ((Math.Floor(moduleMassResult / 3) - 2) > 0)
            {
                moduleMassResult = (Math.Floor(moduleMassResult / 3) - 2);
                result = result + moduleMassResult;
            }

            return (int)result;
        }
    }
}
