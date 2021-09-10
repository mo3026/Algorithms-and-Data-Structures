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
                    // follow-up: Each number in candidates may only be used once in the combination + there are duplicates.
                    if (i > start && nums[i] == nums[i - 1]) continue; // previous DFS has expanded later value!
                    tempList.Add(nums[i]);
                    backtrack(list, tempList, nums, remain - nums[i], i + 1); // i + 1 HERE! because we CANNOT reuse same elements
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
