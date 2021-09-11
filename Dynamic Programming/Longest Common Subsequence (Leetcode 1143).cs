using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int LongestCommonSubsequence(string text1, string text2)
        {
            int[,] table = new int[(text1.Length + 1), (text2.Length + 1)];

            for (int i = 1; i <= text1.Length; ++i)
            {
                for (int j = 1; j <= text2.Length; ++j)
                {
                    if (text1[i - 1] == text2[j - 1])
                        table[i, j] = table[i - 1, j - 1] + 1;
                    else
                        table[i, j] = Math.Max(table[i - 1, j], table[i, j - 1]);
                }
            }

            char[] outputSB = new char[table[text1.Length, text2.Length]];
            for (int i = text1.Length, j = text2.Length, k = table[text1.Length, text2.Length] - 1; k >= 0;)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    outputSB[k] = text1[i - 1];
                    --i;
                    --j;
                    --k;
                }
                else if (table[i, j - 1] > table[i - 1, j])
                    --j;
                else
                    --i;
            }

            string output = new string(outputSB);
            return table[text1.Length, text2.Length];
        }
    }
}
