using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static IList<string> GenerateParenthesis(int n)
        {
            List<string> list = new List<string>();
            backTrack(list, "", 0, 0, n);
            return list;
        }

        public static void backTrack(List<string> list, string current, int open, int close, int max)
        {
            if (open == max && close == max)
            {
                list.Add(current);
            }

            if (open < max)
            {
                backTrack(list, current + "(", open + 1, close, max);
            }
            if (close < max && open> close)
            {
                backTrack(list, current + ")", open, close + 1, max);
            }
        }
    }
}
