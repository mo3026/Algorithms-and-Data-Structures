using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int Jump(int[] nums)
        {
            int[] jump = new int[nums.Length];
            jump[nums.Length - 1] = 1;
            for (int i = jump.Length - 2; i >= 0; i--)
            {
                int min = nums.Length;
                for (int j = nums[i]; j >0; j--)
                {
                    if (i + j< nums.Length && jump[i + j] != 0)
                    {
                        if (min > jump[i + j]) min = jump[i + j];
                    }
                }
                jump[i] = min + 1;
            }
            return jump[0]-1;
        }
    }
}
