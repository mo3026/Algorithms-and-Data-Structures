using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
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

        public bool isSame(TreeNode root, TreeNode subRoot)
        {
            if(root==null || subRoot==null)
            {
                return root == null && subRoot == null;
            }
            else
            {
                if (root.val == subRoot.val)
                {
                    return isSame(root.left, subRoot.left) && isSame(root.right, subRoot.right);
                }
                else return false;
            }
        }

        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            if (root == null)
            {
                return false;
            }
            else
            {
                if (isSame(root, subRoot))
                {
                    return true;
                }
                else
                {
                    return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
                }
            }
        }
    }
}
