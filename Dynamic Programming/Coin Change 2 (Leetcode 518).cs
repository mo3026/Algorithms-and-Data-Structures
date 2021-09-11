using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public static int Change(int amount, int[] coins)
        {
            int[] dp = new int[amount + 1];
            dp[0] = 1;

            for (int i = coins.Length - 1; i >= 0; i--)
            {
                int[] nextDP = new int[amount + 1];
                nextDP[0] = 1;

                for (int a = 1; a < amount + 1; a++)
                {
                    nextDP[a] = dp[a];
                    if (a - coins[i] >= 0) nextDP[a] += nextDP[a - coins[i]];
                }
                dp = nextDP;
            }
            return dp[amount];
        }
    }
}
