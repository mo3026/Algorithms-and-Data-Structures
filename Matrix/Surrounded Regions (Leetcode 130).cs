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
        public static void dfs(ref int[][] grid, int i, int j, char[][] board)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length)
            {
                return;
            }
            if (grid[i][j] == 1 || board[i][j] == 'X') return;
            grid[i][j] = 1;
            dfs(ref grid, i - 1, j, board);
            dfs(ref grid, i + 1, j, board);
            dfs(ref grid, i, j - 1, board);
            dfs(ref grid, i, j + 1, board);
        }

        public static void Solve(char[][] board)
        {
            int[][] grid = (int[][])board.Select(a => new int[a.Length]).ToArray();
            int m = board.Length;
            int n = board[0].Length;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || i == m - 1 || j == 0 || j == n - 1)
                    {
                        dfs(ref grid, i, j, board);
                    }
                }
            }
            for (int i = 1; i < board.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < board[0].Length - 1; j++)
                {
                    if (board[i][j] == 'O' && grid[i][j]!=1)
                    {
                        board[i][j] = 'X';
                    }
                }
            }
        }
    }
}
