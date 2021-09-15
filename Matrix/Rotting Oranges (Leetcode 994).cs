using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        struct point
        {
            public int x;
            public int y;
        }

        static void rotten(int[][] grid , List<point> oranges, ref int count)
        {
            count++;
            List<point> neworotenranges = new List<point>();
            foreach (point dim in oranges)
            {
                int[,] direc= { { -1, 0 },{ 1, 0 },{ 0, -1 },{ 0, 1 } };
                for (int i = 0; i < direc.GetLength(0); i++)
                {
                    int x= dim.x + direc[i, 0];
                    int y = dim.y + direc[i, 1];
                    if (x > -1 && x < grid.Length && y > -1 && y < grid[0].Length)
                    {
                        if (grid[x][y] == 1)
                        {
                            grid[x][y] = 2;
                            neworotenranges.Add(new point() { x = x, y = y });
                        }
                    }
                }
            }
            if(neworotenranges.Count>0) rotten(grid, neworotenranges, ref count);
        }

        public static int OrangesRotting(int[][] grid)
        {
            int count= -1;
            List<point> neworotenranges = new List<point>();
            for (int i= 0;i<grid.Length;i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 2) neworotenranges.Add(new point() { x = i, y = j });
                }
            }
            rotten(grid, neworotenranges, ref count);
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1) return -1;
                }
            }
            return count;
        }
    }
}
