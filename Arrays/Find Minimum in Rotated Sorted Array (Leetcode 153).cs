using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int FindMin(int[] nums)
        {
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0];
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int midpoint = left + (right - left) / 2;
                if (midpoint > 0 && nums[midpoint] < nums[midpoint - 1])
                {
                    return nums[midpoint];
                }
                else
                {
                    if (nums[left] <= nums[midpoint] && nums[midpoint] > nums[right])
                    {
                        left = midpoint + 1;
                    }
                    else
                    {
                        right = midpoint - 1;
                    }
                }
            }
            return nums[left];
        }
    }
}
