using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Collections;


namespace ConsoleApp2
{
    public class Program
    {
        public static void dfs(ref int[][] grid, int i, int j)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length)
            {
                return;
            }
            if (grid[i][j] == 0) return;
            grid[i][j] = 0;
            dfs(ref grid, i - 1, j);
            dfs(ref grid, i + 1, j);
            dfs(ref grid, i, j - 1);
            dfs(ref grid, i, j + 1);
        }

        public static int NumEnclaves(int[][] grid)
        {
            int m = grid.Length;
            int n = grid[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        dfs(ref grid, i, j);
                    }
                }
            }
            int num = 0;
            for (int i = 1; i < grid.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < grid[0].Length - 1; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        num++;
                    }
                }
            }
            return num;
        }
    }
}
