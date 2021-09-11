using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static void Permute(IList<IList<int>> list, List<int> current, List<int> nums, int index)
        {
            if (nums.Count == 0)
            {
                list.Add(current.ToList());
                return;
            }
            for (int i = 0; i < nums.Count; i++)
            {
                current.Add(nums[i]);
                nums.RemoveAt(i);
                Permute(list, current, nums);
                nums.Insert(i, current.Last());
                current.RemoveAt(current.Count - 1);
            }
        }

        public static IList<IList<int>> Permute(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            List<int> current = new List<int>();
            Permute(list, current, nums.ToList());
            return list;
        }
    }
}
