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

        public static List<TreeNode> LowestCommonAncestor(TreeNode root, TreeNode p, List<TreeNode> q)
        {
            if (p == null) return null;
            q.Add(root);
            if (root == p)
            {
                return q;
            }
            else
            {
                List<TreeNode> l = null, r = null;
                if (root.left != null) l = LowestCommonAncestor(root.left, p, q.ToList());
                if (root.right != null) r = LowestCommonAncestor(root.right, p, q.ToList());
                if (l != null && r == null) return l;
                if (l == null && r != null) return r;
                return null;
            }
        }

        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            TreeNode res=null;
            List<TreeNode> resFirst = LowestCommonAncestor(root, p, new List<TreeNode>());
            List<TreeNode> resSecond = LowestCommonAncestor(root, q, new List<TreeNode>());
            int i=0;
            while(i< resFirst.Count && i< resSecond.Count)
            {
                if (resFirst[i] == resSecond[i]) res= resFirst[i];
                i++;
            }
            return res;
        }
    }
}
