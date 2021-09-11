using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int Rob(int[] nums)
        {
            int rob1=0, rob2=0;
            for (int i = 0; i < nums.Length; i++)
            {
                int newRob = Math.Max(rob1 + nums[i], rob2);
                rob1 = rob2;
                rob2 = newRob;
            }
            return rob2;
        }
    }
}
