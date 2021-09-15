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

        public static IList<IList<int>> LevelOrder(TreeNode root)
        {
            List<IList<int>> result = new List<IList<int>>();
            if (root == null)
            {
                return result;
            }
            Queue<TreeNode> stack = new Queue<TreeNode>();
            stack.Enqueue(root);
            while (stack.Count > 0)
            {
                int levelSize = stack.Count();
                List<int> level = new List<int>();
                Queue<TreeNode> stack2 = new Queue<TreeNode>();
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = stack.Dequeue();
                    level.Add(node.val);
                    if (node.left != null)
                    {
                        stack2.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        stack2.Enqueue(node.right);
                    }

                }
                stack = stack2;
                result.Add(level);
            }
            return result;
        }
    }
}
