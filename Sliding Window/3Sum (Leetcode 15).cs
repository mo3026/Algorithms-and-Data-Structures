using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            nums = nums.OrderBy(x => x).ToArray();
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int threeSum = nums[i] + nums[left] + nums[right];
                    if (threeSum > 0) right--;
                    else
                    {
                        if (threeSum < 0) left++;
                        else
                        {
                            list.Add(new List<int> { nums[i], nums[left], nums[right] });
                            left++;
                            while (nums[left] == nums[left - 1] && left < right) left++;
                        }
                    }
                }
            }
            return list;
        }
    }
}
