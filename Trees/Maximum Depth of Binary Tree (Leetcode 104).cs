using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
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

        public static int MaxDepth(TreeNode root, int depth)
        {
            if (root == null) return depth;
            depth++;
            int max = Math.Max(MaxDepth(root.left, depth), MaxDepth(root.right, depth));
            return max;
        }

        public int MaxDepth(TreeNode root)
        {
            int max = MaxDepth(root, 0);
            return max;
        }
    }
}
