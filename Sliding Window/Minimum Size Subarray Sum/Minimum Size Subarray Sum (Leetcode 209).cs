using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public int MinSubArrayLen(int target, int[] nums)
        {
            int start = 0;
            int end = 0;
            int sum = 0;
            int min = int.MaxValue;
            while (end < nums.Length)
            {
                while (sum < target)
                {
                    if (end >= nums.Length) return min > nums.Length ? 0 : min;
                    sum += nums[end];
                    end++;
                }
                while (sum >= target)
                {
                    sum -= nums[start];
                    start++;
                }
                if (min > end - start + 1)
                {
                    min = end - start + 1;
                }
            }
            return min > nums.Length ? 0 : min;
        }
    }
}
