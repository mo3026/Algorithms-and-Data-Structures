using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Collections;


namespace ConsoleApp2
{
    public class Program
    {
        public bool IsMatch(string s, string p)
        {
            return IsMatch(s, p, 0, 0);
        }

        private bool IsMatch(string s, string p, int i, int j)
        {
            if (p.Length == j)
                return s.Length == i;

            if (j + 1 < p.Length && p[j + 1] == '*')
            {
                char c = p[j];
                while (i < s.Length && (c == s[i] || c == '.'))
                {
                    if (isMatch(s, p, i, j + 2))
                        return true;

                    i++;
                }
                return isMatch(s, p, i, j + 2);
            }
            else if (i < s.Length && (s[i] == p[j] || p[j] == '.'))
            {
                return isMatch(s, p, i + 1, j + 1);
            }

            return false;
        }
    }
}
