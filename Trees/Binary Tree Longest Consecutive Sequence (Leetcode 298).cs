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

        public static void dfs(TreeNode root, int valueParent, int length, ref int max)
        {
            if (root == null) return;
            if (root.val == valueParent + 1)
            {
                length++;
                if (length > max) max = length;
            }
            else length = 0;
            dfs(root.left, root.val, length, ref max);
            dfs(root.right, root.val, length, ref max);
        }

        public static int LongestConsecutive(TreeNode root)
        {
            if (root == null) return 0;
            int max = 0;
            dfs(root.left, root.val, 0, ref max);
            dfs(root.right, root.val, 0, ref max);
            return max;
        }
    }
}
