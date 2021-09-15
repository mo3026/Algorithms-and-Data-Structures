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

        public static void dfs(int[][] matrix, int x, int y, bool[,] visited)
        {
            int n = matrix.Length, m = matrix[0].Length;
            visited[x,y] = true;
            for (int i = 0; i < directions.GetLength(0); i++)
            {
                int row = directions[i,0] + x;
                int col = directions[i,1] + y;
                if (row >= 0 && row < n && col >= 0 && col < m && !visited[row,col] && matrix[i][j] <= matrix[row][col])
                    dfs(matrix, row, col, visited);
            }
        }

        public static IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (heights == null || heights.Length == 0 || heights[0].Length == 0) return res;
            int n = heights.Length, m = heights[0].Length;
            bool[,] pVisited = new bool[n,m];
            bool[,] aVisited = new bool[n,m];
            for (int i = 0; i < n; i++)
            {
                //Pacific
                dfs(heights, i, 0, pVisited);
                //Atlantic
                dfs(heights, i, m - 1, aVisited);
            }

            for (int j = 0; j < m; j++)
            {
                //Pacific
                dfs(heights, 0, j, pVisited);
                //Atlantic
                dfs(heights, n - 1, j, aVisited);
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (pVisited[i,j] && aVisited[i,j])
                        res.Add(new int[] { i, j });
                }
            }
            return res;
        }
    }
}
