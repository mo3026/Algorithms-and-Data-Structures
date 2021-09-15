using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public bool isAnagram(String s, String t)
        {
            if (s.Length != t.Length) return false;
            int[] m = new int[128];
            for (int i = 0; i < s.Length; i++)
            {
                m[s[i]]++;
            }
            for (int i = 0; i < t.Length; i++)
            {
                m[t[i]]--;
                if (m[t[i]] < 0) return false;
            }
            return true;
        }
    }
}
