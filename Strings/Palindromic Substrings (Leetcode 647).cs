using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        int countSubstrings(string s)
        {
            int ans = 0;
            for (int i = 0; i < s.Length; ++i)
            {
                ans += count(s, i, i); // odd length
                ans += count(s, i, i + 1); // even length
            }
            return ans;
        }

        static int count(string s, int l, int r)
        {
            int ans = 0;
            while (l >= 0 & r < s.Length && s[l--] == s[r++])
                ++ans;
            return ans;
        }
    }
}
