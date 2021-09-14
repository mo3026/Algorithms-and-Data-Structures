using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static IList<int> SpiralOrder(int[][] matrix)
        {
            int[,] edge = new int[matrix.Length, matrix[0].Length];
            int direc = 0;
            int i = 0, j = 0;
            List<int> result = new List<int>();
            while (true)
            {
                if (edge[i, j] == 1)
                {
                    break;
                }
                result.Add(matrix[i][j]);
                edge[i, j] = 1;
                if (direc == 0)
                {
                    if (j < matrix[i].Length - 1)
                    {
                        if (edge[i, j + 1] == 1)
                        {
                            direc = 1;
                            i++;
                            continue;
                        }
                    }
                    else
                    {
                        direc = 1;
                        i++;
                        if (i == matrix.Length)
                        {
                            break;
                        }
                        continue;
                    }
                    j++;
                }
                if (direc == 1)
                {
                    if (i < matrix.Length - 1)
                    {
                        if (edge[i + 1, j] == 1)
                        {
                            direc = 2;
                            j--;
                            continue;
                        }
                    }
                    else
                    {
                        direc = 2;
                        j--;
                        if (j < 0)
                        {
                            break;
                        }
                        continue;
                    }
                    i++;
                }
                if (direc == 2)
                {
                    if (j > 0)
                    {
                        if (edge[i, j - 1] == 1)
                        {
                            direc = 3;
                            i--;
                            continue;
                        }
                    }
                    else
                    {
                        direc = 3;
                        i--;
                        continue;
                    }
                    j--;
                }
                if (direc == 3)
                {
                    if (i > 0)
                    {
                        if (edge[i - 1, j] == 1)
                        {
                            direc = 0;
                            j++;
                            continue;
                        }
                    }
                    else
                    {
                        direc = 0;
                        j++;
                        continue;
                    }
                    i--;
                }
            }
            return result;
        }
    }
}
