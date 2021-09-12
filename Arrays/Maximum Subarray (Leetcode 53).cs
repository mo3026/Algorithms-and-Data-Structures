using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int MaxSubArray(int[] nums)
        {
            int maxSum = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                int left = i;
                int sum = nums[left];
                if (sum > maxSum) maxSum = sum;
                int right = i + 1;
                while (right < nums.Length)
                {
                    sum += nums[right];
                    if (sum > maxSum) maxSum = sum;
                    right++;
                }
            }
            return maxSum;
        }
    }
}
