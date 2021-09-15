using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int ThreeSumClosest(int[] nums, int target)
        {
            List<int> list = new List<int>();
            nums = nums.OrderBy(x => x).ToArray();
            int closestSum = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int left = i + 1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int threeSum = nums[i] + nums[left] + nums[right];
                    if (Math.Abs(target - threeSum) < closestSum)
                    {
                        closestSum = Math.Abs(target - threeSum);
                        list = new List<int> { nums[i], nums[left], nums[right] };
                    }
                    if (threeSum > target) right--;
                    else
                    {
                        if (threeSum <= target) left++;
                        else
                        {
                            list = new List<int> { nums[i], nums[left], nums[right] };
                            return list.Sum(x => x);
                        }
                    }
                }
            }
            return list.Sum(x => x);
        }
    }
}
