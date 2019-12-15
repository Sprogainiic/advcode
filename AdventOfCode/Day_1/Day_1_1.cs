using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day_1_1
    {
        

        /// <summary>
        /// Fuel required to launch a given module is based on its mass.
        /// Specifically, to find the fuel required for a module, take
        /// its mass, divide by three, round down, and subtract 2.
        /// -------------------------------------------------------------
        /// - For a mass of 12, divide by 3 and round down to get 4, then
        ///   subtract 2 to get 2.
        /// - For a mass of 14, dividing by 3 and rounding down still
        ///   yields 4, so the fuel required is also 2.
        /// - For a mass of 1969, the fuel required is 654.
        /// - For a mass of 100756, the fuel required is 33583.
        /// </summary>
        public static int CalculateFuelRequirements()
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
            var result = Math.Floor((decimal)moduleMass / 3) - 2;
            return (int)result;
        }
    }
}
