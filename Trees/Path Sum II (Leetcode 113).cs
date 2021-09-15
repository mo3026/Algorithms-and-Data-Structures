using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
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

        static void dfs(TreeNode root, int targetSum, IList<IList<int>> list, List<int> currentList, int currentSum)
        {
            if (root == null) return;
            currentList.Add(root.val);
            if (currentSum + root.val == targetSum)
            {
                if (root.left == null && root.right == null)
                {
                    list.Add(currentList);
                    return;
                }
            }
            dfs(root.left, targetSum, list, currentList.ToList(), root.val + root.val);
            dfs(root.right, targetSum, list, currentList.ToList(), root.val + root.val);
        }

        public static IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (root == null) return res;
            List<int> currentList = new List<int>() { root.val };
            if (root.val == targetSum)
            {
                if (root.left == null && root.right == null)
                {
                    res.Add(currentList);
                    return res;
                }
            }
            dfs(root.left, targetSum, res, currentList.ToList(), root.val);
            dfs(root.right, targetSum, res, currentList.ToList(), root.val);
            return res;
        }
    }
}
