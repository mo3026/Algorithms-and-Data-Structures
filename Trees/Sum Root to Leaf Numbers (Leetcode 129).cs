using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        static void dfs(TreeNode root, ref int sum, string num)
        {
            if(root.left == null && root.right == null)
            {
                sum += int.Parse(num);
                return;
            }
            if (root.left != null)
            {
                dfs(root.left, ref sum, num + root.left.val);
            }
            if (root.right != null)
            {
                dfs(root.right, ref sum, num + root.right.val);
            }
        }

        public static int SumNumbers(TreeNode root)
        {
            int sum = 0;
            if (root != null)
            {
                string num = "";
                num += root.val;
                dfs(root, ref sum, num);
            }
            return sum;
        }
    }
}
