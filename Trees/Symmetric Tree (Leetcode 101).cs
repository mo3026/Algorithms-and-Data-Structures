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

        public static bool IsSymmetric(TreeNode root)
        {
            if (root == null)
            {
                return true;
            }
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int levelSize = queue.Count();
                List<TreeNode> level = new List<TreeNode>();
                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node != null)
                    {
                        queue.Enqueue(node.left);
                        level.Add(node.left);
                        queue.Enqueue(node.right);
                        level.Add(node.right);
                    }
                }
                for (int i = 0; i < level.Count / 2; i++)
                {
                    if (level[i] != null && level[level.Count - 1 - i] != null)
                    {
                        if (level[i].val != level[level.Count - 1 - i].val) return false;
                    }
                    if (level[i] == null && level[level.Count - 1 - i] == null)
                    {
                        continue;
                    }
                    if (level[i] == null || level[level.Count - 1 - i] == null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
