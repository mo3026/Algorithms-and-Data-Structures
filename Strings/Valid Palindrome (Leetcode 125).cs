using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static bool IsPalindrome(string s)
        {
            if (String.IsNullOrEmpty(s)) return true;
            var sChars = s.ToCharArray();
            var head = 0;
            var tail = s.Length - 1;
            while (head < tail)
            {
                var headChar = sChars[head];
                var tailChar = sChars[tail];
                if (!Char.IsLetterOrDigit(headChar))
                {
                    head++;
                    continue;
                }
                if (!Char.IsLetterOrDigit(headChar))
                {
                    head++;
                    continue;
                }
                if (!Char.IsLetterOrDigit(tailChar))
                {
                    tail--;
                    continue;
                }
                if (Char.ToLower(headChar) != Char.ToLower(tailChar))
                {
                    return false;
                }
                head++;
                tail--;
            }
            return true;
        }
    }
}
