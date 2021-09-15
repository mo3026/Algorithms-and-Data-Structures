using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static List<int> FindAnagrams(String s, String p)
        {
            List<int> res = new List<int>();
            if (s.Length < p.Length) return res;
            int[] map = new int[128];
            foreach (char c in p)
            {
                map[c]++;
            }
            // two pointers to track the window
            int left = 0, right = 0;
            int m = s.Length, n = p.Length, count = n;
            while (right < m)
            {
                if (map[s[right++]]-- > 0) count--;
                if (count == 0) res.Add(left);
                if (right - left == n && map[s[left++]]++ >= 0) count++;
            }
            return res;
        }
    }
}
