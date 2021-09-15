using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static string LongestPalindrome(string s)
        {
            string LongestPalindrome = "";
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    string temp = s.Substring(i, j - i + 1);
                    char[] chars = temp.ToCharArray();
                    Array.Reverse(chars);
                    string reverse = new string(chars);
                    if (temp == reverse)
                    {
                        if (temp.Length > LongestPalindrome.Length) LongestPalindrome = temp;
                    }
                }
            }
            return LongestPalindrome;
        }
    }
}
