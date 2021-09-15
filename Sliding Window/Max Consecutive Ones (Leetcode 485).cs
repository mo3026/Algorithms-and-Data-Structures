using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            int maxOnes = 0;
            int count = 0;
            for(int i=0;i<nums.Length;i++)
            {
                if(nums[i]==1)
                {
                    count++;
                    if (maxOnes > count) maxOnes = count;
                }
                else
                {
                    count = 0;
                }
            }
            return maxOnes;
        }
    }
}
