using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int LengthOfLIS(int[] nums)
        {
            int[] lis = new int[nums.Length];
            for (int i=0;i<nums.Length;i++)
            {
                int j = i;
                int max = 1;
                while (j>=0)
                {
                    if (nums[i] > nums[j])
                    {
                        if( lis[j] + 1>max) max= lis[j] + 1;
                    }
                    j--;
                }
                lis[i] = max;
            }
            return lis.Max();
        }
    }
}
