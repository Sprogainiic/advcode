using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public static class Day_2_2
    {
        public static List<string> ProcessingAnIntcode(List<string> intCode) //76, 21
        {
            int result;
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

        public static List<string> GetPuzzleInput(string path, int a, int b)
        {
            var inputFile = File.ReadAllText(path).Split(',');
            var result = new List<string>(inputFile);

            result[1] = a.ToString();
            result[2] = b.ToString();

            return result;
        }

        public static List<string> GetPuzzleInput(string path)
        {
            var inputFile = File.ReadAllText(path).Split(',');
            var result = new List<string>(inputFile);

            return result;
        }

        private static List<string> DoCalc()
        {
            var intCode = Day_2_2.GetPuzzleInput(@"J:\My Documents\adventofcode\Input2.txt");
            var result = new List<string>();

            for (int i = 0; i < 99; i++)
            {
                for (int j = 0; j < 99; j++)
                {
                    var orgList = new List<string>(intCode);
                    orgList[1] = i.ToString();
                    orgList[2] = j.ToString();
                    result = Day_2_2.ProcessingAnIntcode(orgList);

                    if (Int32.Parse(result[0]) == 19690720)
                    {
                        return result;
                    }
                }
            }

            return result;

        }
    }
}
