using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int[] SearchRange(int[] nums, int target)
        {
            int posleft = -1;
            int left = 0;
            int right = nums.Length - 1;
            while (left <= right)
            {
                int midpoint = left + (right - left) / 2;
                if (nums[midpoint] >= target)
                {
                    right = midpoint - 1;
                }
                else
                {
                    left = midpoint + 1;
                }
                if (nums[midpoint] == target)
                {
                    posleft = midpoint;
                }
            }

            int posright = -1;
            left = 0;
            right = nums.Length - 1;
            while (left <= right)
            {
                int midpoint = left + (right - left) / 2;
                if (nums[midpoint] <= target)
                {
                    left = midpoint + 1;
                }
                else
                {
                    right = midpoint - 1;
                }
                if (nums[midpoint] == target)
                {
                    posright = midpoint;
                }
            }
            return new int[] { posleft, posright };
        }
    }
}
