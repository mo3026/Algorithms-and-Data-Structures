using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        static int[,] directions = new int[,] { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

        public static void dfs(char[][] matrix, int x, int y, bool[,] visited)
        {
            int n = matrix.Length, m = matrix[0].Length;
            visited[x, y] = true;
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int row = directions[i, 0] + x;
                int col = directions[i, 1] + y;
                if (row >= 0 && row < n && col >= 0 && col < m && !visited[row, col] && matrix[row][col]=='1')
                    dfs(matrix, row, col, visited);
            }
        }

        public static int NumIslands(char[][] grid)
        {
            int num = 0;
            bool[,] visited = new bool[grid.Length,grid[0].Length];
            for(int i=0;i< grid.Length;i++)
            {
                for(int j=0; j< grid[0].Length;j++)
                {
                    if(grid[i][j]=='1' && !visited[i, j])
                    {
                        num++;
                        dfs(grid, i, j, visited);
                    }
                }
            }
            return num;
        }
    }
}
