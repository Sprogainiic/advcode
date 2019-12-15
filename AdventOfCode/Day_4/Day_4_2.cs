using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day_4
{
    public class Day_4_2
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

        private static bool ContainsAdjacentdigits(int number)
        {
            string stringToCompare = number.ToString();
            bool methodIs = false;

            for (int i = 0; i < stringToCompare.Length; i++)
            {
                int CountOfNums = 0;

                if (i != stringToCompare.Length - 1 && stringToCompare[i] == stringToCompare[i + 1])
                {
                    for (int j = i; j < stringToCompare.Length; j++)
                    {
                        if (stringToCompare[i] == stringToCompare[j])
                        {
                            CountOfNums++;
                        }
                        else
                        {
                            i = j - 1;
                            break;
                        }
                        
                        if (j == stringToCompare.Length - 1)
                        {
                            i = j - 1;
                        }
                    }

                    if (CountOfNums == 2)
                    {
                        return true;
                    }
                    else
                    {
                        methodIs = false;
                        CountOfNums = 0;
                    }
                }
            }
            return methodIs;
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
