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
            var intCode = GetPuzzleInput(@"J:\My Documents\adventofcode\repos\advcode-master\AdventOfCode\Day_5\Input_5_1.txt");

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
                    i = ProcessJumpIfTrueInstructions(intCode, firstOpcode, i, modeForFirstParameter, modeForSecondParameter);
                }
                else if (firstOpcode == 6)
                {
                    i = ProcessJumpIfFalseInstructions(intCode, firstOpcode, i, modeForFirstParameter, modeForSecondParameter);
                }
                else if (firstOpcode == 7)
                {
                    ProcessLessThanInstructions(intCode, firstOpcode, i, modeForFirstParameter, modeForSecondParameter);
                    i = i + 4;
                }
                else if (firstOpcode == 8)
                {
                    ProcessEqualsInstructions(intCode, firstOpcode, i, modeForFirstParameter, modeForSecondParameter);
                    i = i + 4;
                }
            }
        }

        private static int ProcessJumpIfFalseInstructions(List<string> intCode, int firstOpcode, int i, int modeForFirstParameter, int modeForSecondParameter)
        {
            // Opcode 6 is jump-if-false: if the first parameter is zero, it sets the instruction pointer to the value from the second parameter. Otherwise, it does nothing.
            var firstParam = Int32.Parse(intCode[i + 1]);
            var secondParam = Int32.Parse(intCode[i + 2]);
            var outputPosition = i;

            var firstParameterForCalculation = modeForFirstParameter == 0 ? Int32.Parse(intCode[firstParam]) : firstParam;
            var secondParameterForCalculation = modeForSecondParameter == 0 ? Int32.Parse(intCode[secondParam]) : secondParam;

            if (firstParameterForCalculation == 0)
            {
                return secondParameterForCalculation;
            }
            return i + 3;
        }

        private static int ProcessJumpIfTrueInstructions(List<string> intCode, int opcode, int i, int modeForFirstParameter, int modeForSecondParameter)
        {
            // Opcode 5 is jump-if-true: if the first parameter is non-zero, it sets the instruction pointer to the value from the second parameter. Otherwise, it does nothing.
            var firstParam = Int32.Parse(intCode[i + 1]);
            var secondParam = Int32.Parse(intCode[i + 2]);
            var outputPosition = i;

            var firstParameterForCalculation = modeForFirstParameter == 0 ? Int32.Parse(intCode[firstParam]) : firstParam;
            var secondParameterForCalculation = modeForSecondParameter == 0 ? Int32.Parse(intCode[secondParam]) : secondParam;

            if (firstParameterForCalculation != 0)
            {
                return secondParameterForCalculation;
            }
            return i + 3;
        }

        private static void ProcessLessThanInstructions(List<string> intCode, int opcode, int i, int modeForFirstParameter, int modeForSecondParameter)
        {
            // Opcode 7 is less than: if the first parameter is less than the second parameter, it stores 1 in the position given by the third parameter. Otherwise, it stores 0.
            int firstOpcode = Int32.Parse(opcode.ToString());
            var firstParam = Int32.Parse(intCode[i + 1]);
            var secondParam = Int32.Parse(intCode[i + 2]);
            var outputPosition = Int32.Parse(intCode[i + 3]);

            var firstParameterForCalculation = modeForFirstParameter == 0 ? Int32.Parse(intCode[firstParam]) : firstParam;
            var secondParameterForCalculation = modeForSecondParameter == 0 ? Int32.Parse(intCode[secondParam]) : secondParam;

            if (firstParameterForCalculation < secondParameterForCalculation)
            {
                intCode[outputPosition] = 1.ToString();
            }
            else
            {
                intCode[outputPosition] = 0.ToString();
            }
        }

        private static void ProcessEqualsInstructions(List<string> intCode, int opcode, int i, int modeForFirstParameter, int modeForSecondParameter)
        {
            // Opcode 8 is equals: if the first parameter is equal to the second parameter, it stores 1 in the position given by the third parameter. Otherwise, it stores 0.
            int firstOpcode = Int32.Parse(opcode.ToString());
            var firstParam = Int32.Parse(intCode[i + 1]);
            var secondParam = Int32.Parse(intCode[i + 2]);
            var outputPosition = Int32.Parse(intCode[i + 3]);

            var firstParameterForCalculation = modeForFirstParameter == 0 ? Int32.Parse(intCode[firstParam]) : firstParam;
            var secondParameterForCalculation = modeForSecondParameter == 0 ? Int32.Parse(intCode[secondParam]) : secondParam;

            if (firstParameterForCalculation == secondParameterForCalculation)
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
            var inputFile = File.ReadAllText(path).Split(',');
            //var inputFile = "3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99".Split(',');

            var result = new List<string>(inputFile);


            return result;
        }

    }
}
