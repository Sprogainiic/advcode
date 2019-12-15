using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_4
{
    public class Day_4_1
    {
        public static void GetPossiblePasswordCount()
        {
            List<int> results = new List<int>();
            for (int number = 134792; number < 675810; number++)
            {
                if (IsLessThenNext(number) && ContainsAdjacentdigits(number))
                {
                    results.Add(number);
                }
            }
        }

        /// <summary>
        /// Check if two adjacent digits are the same (like 22 in 122345).
        /// </summary>
        private static bool ContainsAdjacentdigits(int number)
        {
            string stringToCompare = number.ToString();
            for (int i = 0; i < stringToCompare.Length; i++)
            {
                if (i == stringToCompare.Length - 1)
                {
                    return false;
                }
                if (stringToCompare[i] == stringToCompare[i + 1])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool IsLessThenNext(int number)
        {
            string stringToCompare = number.ToString();
            for (int i = 0; i < stringToCompare.Length; i++)
            {
                if (i == stringToCompare.Length - 1)
                {
                    return true;
                }
                if (Int32.Parse(stringToCompare[i].ToString()) > Int32.Parse(stringToCompare[i + 1].ToString()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
