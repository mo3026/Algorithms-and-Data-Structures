using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public static bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            if ((sum & 1) == 1)
            {
                return false;
            }

            int target = sum >> 1;
            bool[] dp = new bool[target + 1];
            dp[0] = true;

            foreach (int num in nums)
            {
                for (int j = target; j >= num; j--)
                {
                    dp[j] = dp[j] || dp[j - num];
                }
            }

            return dp[target];
        }
    }
}
