using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (k == 0)
            {
                return nums;
            }
            List<int> maximums = new List<int>();
            var linkedList = new LinkedList<int>();
            int l = 0, r = 0;
            for (; r < nums.Length; r++)
            {
                while (linkedList.Count > 0 && nums[linkedList.Last.Value] < nums[r])
                {
                    linkedList.RemoveLast();
                }
                linkedList.AddLast(r);

                if (l > linkedList.First.Value)
                {
                    linkedList.RemoveFirst();
                }

                if (r + 1 >= k)
                {
                    maximums.Add(nums[linkedList.First.Value]);
                    l++;
                }
            }
            return maximums.ToArray();
        }
    }
}
