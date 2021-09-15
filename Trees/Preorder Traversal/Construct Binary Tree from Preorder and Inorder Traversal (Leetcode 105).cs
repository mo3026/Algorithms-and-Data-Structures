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

        public static TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (inorder.Length == 0) return null;
            int[] nodesSameAsRoot = preorder.Skip(0).Take(1).Where(x => x == preorder[0]).Select((x, index) => index).ToArray();
            int indexInorder = inorder.ToList().Select((value, index) => new { value, index }).Where((x, index) => x.value == preorder[0]).Select((x) => x.index).ToArray()[nodesSameAsRoot.Length - 1];
            int[] leftInorder = inorder.Skip(0).Take(indexInorder).ToArray();
            int[] rightInorder = inorder.Skip(indexInorder + 1).ToArray();
            int[] leftPreorder = preorder.Skip(1).Take(leftInorder.Length).ToArray();
            int[] rightPreorder = preorder.Skip(1 + leftInorder.Length).ToArray();
            TreeNode left = BuildTree(leftPreorder, leftInorder);
            TreeNode right = BuildTree(rightPreorder, rightInorder);
            TreeNode parent = new TreeNode(preorder[0], left, right);
            return parent;
        }
    }
}
