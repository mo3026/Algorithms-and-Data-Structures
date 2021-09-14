using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static int LongestConsecutive(int[] nums)
        {
            int lc = 0;
            HashSet<int> hs = new HashSet<int>();
            foreach (int num in nums) hs.Add(num);

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                int length = 1;
                if (!hs.Contains(currentNum - 1))
                {
                    while (hs.Contains(currentNum + 1))
                    {
                        currentNum++;
                        length++;
                    }
                }
                if (lc < length) lc = length;
            }

            return lc;
        }
    }
}
