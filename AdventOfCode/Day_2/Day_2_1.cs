using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day_2_1
    {

        public static List<string> ProcessingAnIntcode()
        {
            int result;
            var intCode = GetPuzzleInput(@"J:\My Documents\adventofcode\Input2.txt");

            for (int i = 0; i < intCode.Count; i += 4)
            {
                var firstOpcode = Int32.Parse(intCode[i]);

                if (firstOpcode == 99)
                {
                    return intCode;
                }

                var inputOne = Int32.Parse(intCode[i + 1]);
                var inputTwo = Int32.Parse(intCode[i + 2]);
                var outputPosition = Int32.Parse(intCode[i + 3]);
                
                if (firstOpcode == 1)
                {
                    result = Int32.Parse(intCode[inputOne]) + Int32.Parse(intCode[inputTwo]);
                }
                else if (firstOpcode == 2)
                {
                    result = Int32.Parse(intCode[inputOne]) * Int32.Parse(intCode[inputTwo]);
                }
                else
                {
                    return intCode;
                }
                intCode[outputPosition] = result.ToString();
            }

            return intCode;
        }

        public static List<string> GetPuzzleInput(string path)
        {
            var inputFile = File.ReadAllText(path).Split(',');
            var result = new List<string>(inputFile);

            result[1] = "12";
            result[2] = "2";

            return result;
        }
    }
}
