using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int MissingNumber(int[] nums)
        {
            int sum = nums.Sum();
            int count = nums.Length + 1;
            return count * (count - 1) / 2 - sum;
        }
    }
}
