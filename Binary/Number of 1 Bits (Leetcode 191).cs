using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int HammingWeight(uint n)
        {
            int res = 0;
            while (n > 0)
            {
                int remn = (int)n & 1;
                n >>= 1;
                if (remn == 1) res += 1;
            }
            return res;
        }
    }
}
