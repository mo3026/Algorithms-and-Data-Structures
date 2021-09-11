using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public static int longestPalindromeSubseq(String s)
        {
            if (s.Length < 2) return s.Length;
            int n = s.Length;
            int[,] dp = new int[n,n];
            for (int i = 0; i<n; i++)
            {
                dp[i, i] = 1;
            }

            for (int start=1; start < n; start++)
            {
                int right = start;
                for (int left = 0; left < n-start; left++)
                {
                    if (s[left] == s[right])
                    {
                        dp[left, right] = dp[left + 1, right - 1] + 2;
                    }
                    else
                    {
                        dp[left, right] = Math.Max(dp[left, right - 1], dp[left+1, right]);
                    }
                    right++;
                }
            }
            return dp[0, n - 1];
        }
    }
}
