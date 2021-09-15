using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static bool CheckInclusion(string s1, string s2)
        {
            int left = 0;
            int right = 0;
            int[] required = new int[26];
            foreach (char c in s1)
            {
                required[c - 'a']++;
            }
            int[] count = new int[26];
            while (right < s2.Length)
            {
                count[s2[right] - 'a']++;
                bool state = true;
                for (int i = 0; i < count.Length; i++)
                {
                    if (count[i] != required[i] || count[i] < required[i])
                    {
                        state = false;
                    }
                    if (required[i] < count[i])
                    {
                        count[s2[left] - 'a']--;
                        left++;
                        break;
                    }
                }
                if (state)
                {
                    return true;
                }
                right++;
            }
            return false;
        }
    }
}
