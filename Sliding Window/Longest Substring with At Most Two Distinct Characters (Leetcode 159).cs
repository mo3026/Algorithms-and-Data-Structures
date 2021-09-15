using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public int lengthOfLongestSubstringTwoDistinct(String s)
        {
            int n = s.Length;
            if (n < 3) return n;
            int left = 0;
            int right = 0;
            Dictionary<char, int> hashmap = new Dictionary<char, int>();
            int max_len = 2;
            while (right < n)
            {
                if (hashmap.Count < 3)
                    hashmap.Add(s[right], right++);
                if (hashmap.Count == 3)
                {
                    int del_idx = hashmap.Values.Select((x, i) => new { index = i, value = x }).OrderBy(item => item.value).First().index;
                    hashmap.Remove(s[del_idx]);
                    left = del_idx + 1;
                }
                max_len = Math.Max(max_len, right - left);
            }
            return max_len;
        }
    }
}
