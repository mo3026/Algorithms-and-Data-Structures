using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public static int NumDistinct(string s, string t)
        {
            int[][] cache = new int[t.Length + 1][];
            for (int i = 0; i <= t.Length; i++)
            {
                cache[i] = new int[s.Length+1];
            }
            cache[0] = cache[0].Select(x => 1).ToArray();
            for (int i = 0; i < t.Length; i++)
            {
                for (int j = 0; j < s.Length; j++)
                {
                    if (t[i] == s[j])
                    {
                        cache[i + 1][j + 1] = cache[i][j] + cache[i + 1][j];
                    }
                    else
                    {
                        cache[i + 1][j + 1] = cache[i + 1][j];
                    }
                }
            }
            return cache[t.Length][s.Length];
        }
    }
}
