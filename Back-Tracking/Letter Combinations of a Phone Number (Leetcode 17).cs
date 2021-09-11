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
        public static IList<string> LetterCombinations(string digits, List<string> list, int pos, string temp, string[] map)
        {
            if (pos >= digits.Length)
            {
                list.Add(temp);
                return list;
            }
            int num = int.Parse(digits[pos].ToString());
            foreach (char c in map[num - 2])
            {
                LetterCombinations(digits, list, pos + 1, temp + c, map);
            }
            return list;
        }

        public static IList<string> LetterCombinations(string digits)
        {
            List<string> list = new List<string>();
            if (digits.Length == 0) return list;
            string[] map = new string[] { "abc", "def", "ghi", "jkl", "mno", "pqrs", "tuv", "wxyz" };
            LetterCombinations(digits, list, 0, "", map);
            return list;
        }
    }
}
