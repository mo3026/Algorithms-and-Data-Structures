using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int ClimbStairs(int n)
        {
            int[] ways = new int[n+1];
            ways[0] = 1;
            ways[1] = 1;
            for(int i=2;i<=n;i++)
            {
                ways[i] = ways[i - 2] + ways[i - 1];
            }
            return ways[n];
        }
    }
}
