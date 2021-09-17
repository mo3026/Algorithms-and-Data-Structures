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
        public static void dfs(ref List<IList<string>> list, char[][] board, List<int> cols, List<int> posDiag, List<int> negDiag, int row, int num)
        {
            if (row == num)
            {
                list.Add(board.Select(x=>new string(x)).ToList());
                return;
            }
            for(int col=0; col < num; col++)
            {
                if(cols.Contains(col) || posDiag.Contains(row + col) || negDiag.Contains(row - col))
                {
                    continue;
                }

                cols.Add(col);
                posDiag.Add(row + col);
                negDiag.Add(row - col);
                board[row][col] = 'Q';

                dfs(ref list, board, cols, posDiag, negDiag, row + 1, num);

                cols.Remove(col);
                posDiag.Remove(row + col);
                negDiag.Remove(row - col);
                board[row][col] = '.';
            }
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            List<IList<string>> list = new List<IList<string>>();
            List<int> cols = new List<int>();
            List<int> posDiag = new List<int>();
            List<int> negDiag = new List<int>();
            char[] row = Enumerable.Repeat('.', n).ToArray();
            char[][] board = (char[][])Enumerable.Range(0, n).Select(x=> row.ToArray()).ToArray();
            dfs(ref list, board, cols, posDiag, negDiag, 0, n);
            return list;
        }
    }
}
