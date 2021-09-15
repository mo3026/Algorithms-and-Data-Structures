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

        public static bool IsValidBST(TreeNode rootNode, long min, long max)
        {
            if (rootNode == null)
            {
                return true;
            }

            if (rootNode.val <= min || rootNode.val >= max)
            {
                return false;
            }

            return IsValidBST(rootNode.left, min, rootNode.val)
                   && IsValidBST(rootNode.right, rootNode.val, max);
        }

        public static bool IsValidBST(TreeNode root)
        {
            return IsValidBST(root, long.MinValue, long.MaxValue);
        }
    }
}
