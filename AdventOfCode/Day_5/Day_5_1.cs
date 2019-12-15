using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_5
{
    public class Day_5_1
    {
        public static void ProcessingAnIntcode_5_1()
        {
            var intCode = GetPuzzleInput(@"C:\Users\mblin\source\repos\AdventOfCode\AdventOfCode\Day_5\Input_5_1.txt");

            for (int i = 0; i < intCode.Count;)
            {
                var firstOpcode = Int32.Parse(intCode[i]);
                int modeForFirstParameter = 0;
                int modeForSecondParameter = 0;

                if (firstOpcode.ToString().Length > 1)
                {
                    if (firstOpcode == 99)
                    {
                        return;
                    }
                    var numCharArray = firstOpcode.ToString().ToCharArray();
                    firstOpcode = Int32.Parse(numCharArray[numCharArray.Length - 1].ToString());
                    modeForFirstParameter = Int32.Parse(numCharArray[numCharArray.Length - 3].ToString());

                    if (numCharArray.Length > 3)
                    {
                        modeForSecondParameter = Int32.Parse(numCharArray[numCharArray.Length - 4].ToString());
                    }
                }

                if (firstOpcode == 1 || firstOpcode == 2)
                {
                    ProcessSimple(intCode, firstOpcode, i, modeForFirstParameter, modeForSecondParameter);
                    i = i + 4;
                }
                else if (firstOpcode == 3)
                {
                    ProcessInputInstructions(intCode, i, modeForFirstParameter);
                    i = i + 2;
                }
                else if (firstOpcode == 4)
                {
                    ProcessOutputInstructions(intCode, i, modeForFirstParameter);
                    i = i + 2;
                }
            }
        }
        private static void ProcessSimple(List<string> intCode, int opcode, int i, int modeForFirstParameter, int modeForSecondParameter)
        {
            int result;
            int firstOpcode = Int32.Parse(opcode.ToString());

            if (firstOpcode == 99)
            {
                return;
            }

            var inputOne = Int32.Parse(intCode[i + 1]);
            var inputTwo = Int32.Parse(intCode[i + 2]);
            var outputPosition = Int32.Parse(intCode[i + 3]);

            var firstParameterForCalculation = modeForFirstParameter == 0 ? Int32.Parse(intCode[inputOne]) : inputOne;
            var secondParameterForCalculation = modeForSecondParameter == 0 ? Int32.Parse(intCode[inputTwo]) : inputTwo;

            if (firstOpcode == 1)
            {
                result = firstParameterForCalculation + secondParameterForCalculation;
            }
            else if (firstOpcode == 2)
            {
                result = firstParameterForCalculation * secondParameterForCalculation;
            }
            else
            {
                return;
            }

            intCode[outputPosition] = result.ToString();
        }

        private static void ProcessOutputInstructions(List<string> intCode, int i, int modeForSecondParameter = 0)
        {
            int outputPosition = Int32.Parse(intCode[i + 1]);
            var outputValue = modeForSecondParameter == 0 ? Int32.Parse(intCode[outputPosition]) : outputPosition;
            Console.WriteLine(outputValue);
        }

        private static void ProcessInputInstructions(List<string> intCode, int i, int modeForSecondParameter = 0)
        {
            Console.WriteLine("Please input instrucion:");
            var instruction = Console.ReadLine();
            int outputPosition = Int32.Parse(intCode[i + 1]);

            intCode[outputPosition] = instruction;
        }

        public static List<string> GetPuzzleInput(string path)
        {
            var inputFile = File.ReadAllText(path).Split(',');
            var result = new List<string>(inputFile);

            return result;
        }


        private static void ProcessSimple(List<string> intCode, int i)
        {
            int result;
            var firstOpcode = Int32.Parse(intCode[i]);

            if (firstOpcode == 99)
            {
                return;
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
                return;
            }

            intCode[outputPosition] = result.ToString();
        }
    }
}
