using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static void SetZeroes(int[][] matrix)
        {
            int[][] result = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = (int[])matrix[i].Clone();
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        for (int x = 0; x < matrix[i].Length; x++)
                        {
                            result[i][x] = 0;
                        }
                        for (int y = 0; y < matrix.Length; y++)
                        {
                            result[y][j] = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = (int[])result[i].Clone();
            }
        }
    }
}
