using System;
using System.Linq;

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

        public static int[] dfs(TreeNode root)
        {
            if (root == null) return new int[2];
            int[] bestLeft = dfs(root.left);
            int[] bestRight = dfs(root.right);
            int withRoot = root.val + bestLeft[1] + bestRight[1];
            int withoutRoot = Math.Max(bestLeft[0], bestLeft[1]) + Math.Max(bestRight[0], bestRight[1]);
            return new int[] { withRoot, withoutRoot };
        }

        public static int Rob(TreeNode root)
        {
            return dfs(root).Max();
        }
    }
}
