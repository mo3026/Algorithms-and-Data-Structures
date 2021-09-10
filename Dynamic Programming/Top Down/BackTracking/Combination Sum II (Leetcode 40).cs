using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static void backtrack(List<IList<int>> list, List<int> tempList, int[] nums, int remain, int start)
        {
            if (remain < 0) return;
            else if (remain == 0) list.Add(tempList.ToList());
            else
            {
                for (int i = start; i < nums.Length; i++)
                {
                    if (i > start && nums[i] == nums[i - 1]) continue;
                    tempList.Add(nums[i]);
                    backtrack(list, tempList, nums, remain - nums[i], i + 1);
                    tempList.RemoveAt(tempList.Count - 1);
                }
            }
        }

        public IList<IList<int>> CombinationSum2(int[] candidates, int target)
        {
            List<IList<int>> list = new List<IList<int>>();
            Array.Sort(candidates);
            backtrack(list, new List<int>(), candidates, target, 0);
            return list;
        }
    }
}
