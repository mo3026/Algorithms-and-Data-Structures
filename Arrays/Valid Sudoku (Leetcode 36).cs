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
        public static bool IsValidSudoku(char[][] board)
        {
            for (int i = 0; i < 9; i = i + 1)
            {
                HashSet<char> hashset = new HashSet<char>();
                for (int j = 0; j < 9; j = j + 1)
                {
                    if (board[i][j] != '.')
                    {
                        if (!hashset.Add(board[i][j]))
                        {
                            return false;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i = i + 1)
            {
                HashSet<char> hashset = new HashSet<char>();
                for (int j = 0; j < 9; j = j + 1)
                {
                    if (board[j][i] != '.')
                    {
                        if (!hashset.Add(board[j][i]))
                        {
                            return false;
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i = i + 3)
            {
                for (int j = 0; j < 9; j = j + 3)
                {
                    HashSet<char> hashset = new HashSet<char>();
                    for (int k = i; k < i + 3; k++)
                    {
                        for (int l = j; l < j + 3; l++)
                        {
                            if (board[k][l] != '.')
                            {
                                if (!hashset.Add(board[k][l]))
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }
    }
}
