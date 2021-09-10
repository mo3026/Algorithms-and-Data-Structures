using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static void CombinationSum(IList<int> candidates, int target, IList<IList<int>> list, int i, List<int> current)
        {
            if (target == 0)
            {
                list.Add(current);
                return;
            }
            while (i < candidates.Count)
            {
                if (target < candidates[i]) i++;
                else break;
            }
            if (i < candidates.Count)
            {
                CombinationSum(candidates, target, list, i + 1, current.ToList());
                current.Add(candidates[i]);
                //CombinationSum(candidates, target - candidates[i], list, i+1, current.ToList());
                CombinationSum(candidates, target - candidates[i], list, i, current.ToList());
            }
        }

        public static IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> list = new List<IList<int>>();
            List<int> num = candidates.ToList();
            num.Sort();
            num.Reverse();
            int i = 0;
            CombinationSum(num, target, list, i, new List<int>());
            return list.ToList();
        }
    }
}
