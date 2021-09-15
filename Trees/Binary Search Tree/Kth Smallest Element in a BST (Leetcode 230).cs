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

        public static void KthSmallest(TreeNode root, List<int> list)
        {
            if (root.left != null) KthSmallest(root.left, list);
            list.Add(root.val);
            if (root.right != null) KthSmallest(root.right, list);
        }

        public static int KthSmallest(TreeNode root, int k)
        {
            List<int> list = new List<int>();
            KthSmallest(root, list);
            return list[k-1];
        }
    }
}
