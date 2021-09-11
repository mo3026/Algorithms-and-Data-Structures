using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        public long ways(Dictionary<String, long> mem,int[] nums, int n, int sum, int S, int pos)
        {
            if (n == pos)
                return sum == S ? 1 : 0;
            String key = pos.ToString() + "*" + sum.ToString();
            if (mem.ContainsKey(key))
                return mem[key];

            long val = ways(mem, nums, n, sum + nums[pos], S, pos + 1) + ways(mem, nums, n, sum - nums[pos], S, pos + 1);
            mem.Add(key, val);
            return val;
        }

        public int findTargetSumWays(int[] nums, int target)
        {
            Dictionary<String, long> mem = new Dictionary<string, long>();
            int n = nums.Length;
            if (n == 0)
                return 0;

            return (int)(ways(mem, nums, n, nums[0], target, 1) + ways(mem, nums, n, -nums[0], target, 1));
        }
    }
}
