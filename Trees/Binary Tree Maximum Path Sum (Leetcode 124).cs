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

        private static long MaxPathSumHelper(TreeNode root, ref long res)
        {
            if (root == null) return 0;

            var pathThroughleft = MaxPathSumHelper(root.left,ref res);
            var pathThroughright = MaxPathSumHelper(root.right,ref res);

            var pathThroughRoot = Math.Max(Math.Max(pathThroughleft, pathThroughright) + root.val, root.val);
            res = Math.Max(res, Math.Max(pathThroughRoot, pathThroughleft + pathThroughright + root.val));
            return pathThroughRoot;
        }

        public static int MaxPathSum(TreeNode root)
        {
            long res = int.MinValue;
            MaxPathSumHelper(root, ref res);
            return (int)res;
        }
    }
}
