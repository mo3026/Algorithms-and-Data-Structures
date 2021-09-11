using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public int minDistance(String word1, String word2)
        {
            int m = word1.Length, n = word2.Length; int insert = 0, del = 0, rep = 0;
            int[,] Edit = new int[m + 1, n + 1];

            for (int j = 0; j < n + 1; j++)
                Edit[0, j] = j;
            for (int i = 1; i < m + 1; i++)
            {
                Edit[i, 0] = i;
                for (int j = 1; j < n + 1; j++)
                {
                    insert = Edit[i - 1, j] + 1;
                    del = Edit[i, j - 1] + 1;
                    rep = Edit[i - 1, j - 1];
                    if (word1[i - 1] == word2[j - 1])
                        Edit[i, j] = rep;
                    else
                        Edit[i, j] = Math.Min(Math.Min(insert, del), rep + 1);
                }
            }
            return Edit[m, n];
        }
    }
}
