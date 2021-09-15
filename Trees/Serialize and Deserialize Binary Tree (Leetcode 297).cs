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


        public static string Serialize(TreeNode root)
        {
            StringBuilder sb = new StringBuilder();
            return buildString(root, sb).ToString();
        }

        private static StringBuilder buildString(TreeNode root, StringBuilder sb)
        {
            if (root == null)
            {
                return sb.Append("#");
            }

            sb.Append(root.val).Append(",");
            buildString(root.left, sb).Append(",");
            buildString(root.right, sb);
            return sb;
        }


        public static TreeNode Deserialize(String data)
        {
            Queue<string> queue = new Queue<string>(data.Split(','));
            return buildTree(queue);
        }

        private static TreeNode buildTree(Queue<String> queue)
        {
            String head = queue.Dequeue();
            if ("#".Equals(head))
            {
                return null;
            }

            TreeNode root = new TreeNode(int.Parse(head));
            root.left = buildTree(queue);
            root.right = buildTree(queue);
            return root;
        }
    }
}
