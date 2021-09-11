using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int NumDecodings(string s)
        {
            if (s.Length == 0 || s[0] == '0')
                return 0;
            int[] ret = new int[s.Length + 1];//To prevent situations similar to 10, 20, you need to apply for an extra space
            ret[0] = 1;
            ret[1] = 1;
            for (int i = 1; i < s.Length; i++)
            {
                int tmp = Convert.ToInt32(s.Substring(i - 1, 2));
                if (s[i] == '0')
                {
                    if (tmp > 26 || tmp == 0)
                        return 0;
                    else
                        ret[i + 1] = ret[i - 1];
                }
                else
                {
                    if (s[i - 1] == '0' || tmp > 26)
                        ret[i + 1] = ret[i];
                    else
                        ret[i + 1] = ret[i] + ret[i - 1];
                }
            }
            return ret[s.Length];
        }
    }
}
