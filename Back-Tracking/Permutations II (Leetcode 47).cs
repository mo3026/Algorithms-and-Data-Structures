using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Collections;


namespace ConsoleApp2
{
    public class Program
    {
        public static void dfs(IList<IList<int>> list, List<int> current, Dictionary<int, int> count)
        {
            if (0 == count.Sum(x => x.Value))
            {
                list.Add(current.ToList());
                return;
            }
            foreach (int n in count.Keys.ToList())
            {
                if (count[n] > 0)
                {
                    current.Add(n);
                    count[n]--;
                    dfs(list, current, count);
                    count[n]++;
                    current.RemoveAt(current.Count - 1);
                }
            }
        }

        public static IList<IList<int>> PermuteUnique(int[] nums)
        {
            List<IList<int>> list = new List<IList<int>>();
            List<int> current = new List<int>();
            Dictionary<int, int> count = new Dictionary<int, int>();
            foreach (int n in nums)
            {
                if (count.ContainsKey(n))
                {
                    count[n]++;
                }
                else
                {
                    count.Add(n, 1);
                }
            }
            dfs(list, current, count);
            return list;
        }
    }
}
