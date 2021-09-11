using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int UniquePaths(int m, int n)
        {
            int[,] table = new int[m, n];
            for (int i = 0; i < n; i++)
            {
                table[m - 1, i] = 1;
            }
            for (int i = 0; i < m; i++)
            {
                table[i, n - 1] = 1;
            }
            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n - 2; j >= 0; j--)
                {
                    table[i, j] = table[i + 1, j] + table[i, j + 1];
                }
            }
            return table[0, 0];
        }
    }
}
