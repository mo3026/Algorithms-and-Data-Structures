using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static void generateSubsets(int[] nums, IList<IList<int>> list, List<int> current, int index)
        {
            list.Add(new List<int>(current));
            for (int i = index; i < nums.Length; i++)
            {
                current.Add(nums[i]);
                generateSubsets(nums, list, current, i + 1);
                current.RemoveAt(current.Count-1);
            }
        }

        public static IList<IList<int>> Subsets(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            generateSubsets(nums, list,new List<int>(), 0);
            return list;
        }
    }
}
