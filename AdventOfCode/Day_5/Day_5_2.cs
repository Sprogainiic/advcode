using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_5
{
    public class Day_5_2
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
                else if (firstOpcode == 5)
                {

                }
                else if (firstOpcode == 6)
                {

                }
                else if (firstOpcode == 7)
                {

                }
                else if (firstOpcode == 8)
                {
                    ProcessEqualsInstructions(intCode, firstOpcode, i, modeForFirstParameter, modeForSecondParameter);
                    i = i + 4;
                }
            }
            Console.ReadLine();
        }

        private static void ProcessEqualsInstructions(List<string> intCode, int opcode, int i, int modeForFirstParameter, int modeForSecondParameter)
        {
            //if the first parameter is equal to the second parameter, it stores 1 in the position given by the third parameter.Otherwise, it stores 0.
            int firstOpcode = Int32.Parse(opcode.ToString());
            var firstParam = Int32.Parse(intCode[i + 1]);
            var secondParam = Int32.Parse(intCode[i + 2]);
            var outputPosition = Int32.Parse(intCode[i + 3]);

            if (firstParam == secondParam)
            {
                intCode[outputPosition] = 1.ToString();
            }
            else
            {
                intCode[outputPosition] = 0.ToString();
            }
        }

        private static void ProcessSimple(List<string> intCode, int opcode, int i, int modeForFirstParameter, int modeForSecondParameter)
        {
            int result;
            int firstOpcode = Int32.Parse(opcode.ToString());

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
            //var inputFile = File.ReadAllText(path).Split(',');
            var inputFile = "3,9,8,9,10,9,4,9,99,-1,8".Split(',');

            var result = new List<string>(inputFile);


            return result;
        }

    }
}
