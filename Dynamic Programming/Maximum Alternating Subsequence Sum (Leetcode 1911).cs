using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public long maxAlternatingSum(int[] nums)
        {
            long sumEven = 0, sumOdd = 0;
            for (int i = nums.Length-1; i >=0; i--)
            {
                long tmpEven = Math.Max(sumOdd + nums[i], sumEven);
                long tmpOdd = Math.Max(sumEven - nums[i], sumOdd);
                sumEven = tmpEven;
                sumOdd = tmpOdd;
            }
            return sumEven;
        }
    }
}
