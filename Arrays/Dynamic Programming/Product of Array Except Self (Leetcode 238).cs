using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int[] ProductExceptSelf(int[] nums)
        {
            int[] result = new int[nums.Length];
            int[] dpBack = new int[nums.Length];
            int[] dpForward = new int[nums.Length];

            dpBack[0] = 1;
            dpBack[1] = nums[0];
            for (int i = 2; i < nums.Length; i++)
            {
                dpBack[i] = nums[i - 1] * dpBack[i - 1];
            }
            dpForward[nums.Length - 1] = 1;
            dpForward[nums.Length - 2] = nums[nums.Length - 1];
            for (int i = nums.Length - 3; i >= 0; i--)
            {
                dpForward[i] = nums[i + 1] * dpForward[i + 1];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = dpBack[i] * dpForward[i];
            }
            return result;
        }
    }
}
