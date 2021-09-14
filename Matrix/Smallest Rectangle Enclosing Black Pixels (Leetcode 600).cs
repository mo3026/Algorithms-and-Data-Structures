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
        public static void dfs(ref char[][] grid, int i, int j, ref int minx, ref int miny, ref int maxx, ref int maxy)
        {
            if (i < 0 || i >= grid.Length || j < 0 || j >= grid[0].Length)
            {
                return;
            }
            if (grid[i][j] == '0') return;
            if (j < minx) minx = j;
            if (j > maxx) maxx = j;
            if (i < miny) miny = j;
            if (i > maxy) maxy = j;
            grid[i][j] = '0';
            dfs(ref grid, i - 1, j, ref minx, ref miny, ref maxx, ref maxy);
            dfs(ref grid, i + 1, j, ref minx, ref miny, ref maxx, ref maxy);
            dfs(ref grid, i, j - 1, ref minx, ref miny, ref maxx, ref maxy);
            dfs(ref grid, i, j + 1, ref minx, ref miny, ref maxx, ref maxy);
        }

        public int minArea(char[][] image, int x, int y)
        {
            int m = image.Length;
            int n = image[0].Length;
            int minx = int.MaxValue, miny = int.MaxValue;
            int maxx = int.MinValue, maxy = int.MinValue;
            dfs(ref image, x, y, ref minx, ref miny, ref maxx, ref maxy);
            return (maxx - minx) * (maxy - miny);
        }
    }
}
