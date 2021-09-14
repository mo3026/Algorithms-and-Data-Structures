using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static void Rotate(int[][] matrix)
        {
            int left = 0, right = matrix.GetLength(0) - 1;

            while (left < right)
            {
                for (int i = 0; i < right - left; i++)
                {
                    int top = left, bottom = right;

                    var topLeft = matrix[top][left + i];

                    //Move bottom left into top left
                    matrix[top][left + i] = matrix[bottom - i][left];

                    //Move bottom right into bottom left
                    matrix[bottom - i][left] = matrix[bottom][right - i];

                    //Move top right into bottom right
                    matrix[bottom][right - i] = matrix[top + i][right];

                    //Move top left into top right
                    matrix[top + i][right] = topLeft;
                }
                right--;
                left++;
            }
        }
    }
}
