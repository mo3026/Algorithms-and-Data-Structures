using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int MaxProduct(int[] nums)
        {
            int result = nums.Max();
            int max = 1;
            int min = 1;
            foreach (int num in nums)
            {
                if (num == 0)
                {
                    max = 1;
                    min = 1;
                    continue;
                }
                int temp = max * num;
                max = new List<int> { num * max, num * min, num }.Max();
                min = new List<int> { temp, num * min, num }.Min();
                result = Math.Max(result, max);
            }
            return result;
        }
    }
}
