using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }

        static int dfs(TreeNode root, Dictionary<int, int> sum)
        {
            int subTreeSum = root.val;
            if (root.left != null)
            {
                subTreeSum+=dfs(root.left, sum);
            }
            if (root.right != null)
            {
                subTreeSum+=dfs(root.right, sum);
            }
            if (sum.ContainsKey(subTreeSum))
            {
                sum[subTreeSum]++;
            }
            else
            {
                sum.Add(subTreeSum,1);
            }
            return subTreeSum;
        }

        public static int[] FindFrequentTreeSum(TreeNode root)
        {
            Dictionary<int, int> list = new Dictionary<int, int>();
            dfs(root, list);
            var en = list.Values.Max();
            return list.Where(x => x.Value == en).Select(w => w.Key).ToArray();
        }
    }
}
