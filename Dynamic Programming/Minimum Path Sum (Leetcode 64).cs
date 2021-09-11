using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int MinPathSum(int[][] grid)
        {
            int[,] dp = new int[grid.Length, grid[0].Length];

            for (int j = grid.Length - 1; j >= 0; j--)
            {
                for (int i = grid[0].Length - 1; i >= 0; i--)
                {
                    dp[j, i] = grid[j][i];
                    if (j < grid.Length - 1 && i < grid[0].Length - 1)
                    {
                        dp[j, i] += Math.Min(dp[j, i + 1], dp[j + 1, i]);
                    }
                    else
                    {
                        if (j < grid.Length - 1)
                        {
                            dp[j, i] += dp[j + 1, i];
                        }
                        else
                        {
                            if (i < grid[0].Length - 1) dp[j, i] += dp[j, i + 1];
                        }
                    }
                }
            }
            return dp[0, 0];
        }
    }
}
