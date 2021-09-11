using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public static int MincostTickets(int[] days, int[] costs)
        {
            int max = days.Last();
            HashSet<int> S = new HashSet<int>();
            foreach (int d in days) S.Add(d);
            int[] dp = new int[max + 1];
            for (int i = 1; i < dp.Length; i++)
            {
                if (S.Contains(i))
                {
                    dp[i] = new int[] { costs[0] + dp[i - 1], costs[1] + dp[Math.Max(0, i - 7)], costs[2] + dp[Math.Max(0, i - 30)] }.Min();
                }
                else
                {
                    dp[i] = dp[i - 1];
                }
            }
            return dp.Last();
        }
    }
}
