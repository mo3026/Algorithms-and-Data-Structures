using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public class Node
        {
            public int val;
            public Node left;
            public Node right;
            public Node next;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, Node _left, Node _right, Node _next)
            {
                val = _val;
                left = _left;
                right = _right;
                next = _next;
            }
        }

        public static void dfs(Node root, ref Node leaf, int length, ref int lenMax)
        {
            if (root == null)
            {
                return;
            }
            length++;
            if (root.left == null && root.right == null)
            {
                if (length > lenMax)
                {
                    lenMax = length;
                    leaf = root;
                }
                else
                {
                    if (length == lenMax)
                    {
                        Console.WriteLine(root.val);
                        leaf.next = root;
                        leaf = root;
                    }
                }
            }
            dfs(root.left, ref leaf, length, ref lenMax);
            dfs(root.right, ref leaf, length, ref lenMax);
        }

        public static Node Connect(Node root)
        {
            if (root == null) return null;
            List<Node> bfs = new List<Node>() { root };
            while(bfs.Count>0)
            {
                List<Node> bfsTemp = new List<Node>();
                for (int i=0;i<bfs.Count-1;i++)
                {
                    if(bfs.Count>i+1)
                    {
                        bfs[i].next = bfs[i + 1];
                    }
                }
                for (int i = 0; i < bfs.Count; i++)
                {
                    if (bfs[i].left != null)
                    {
                        bfsTemp.Add(bfs[i].left);
                    }
                    else break;
                    if (bfs[i].right != null)
                    {
                        bfsTemp.Add(bfs[i].right);
                    }
                    else break;
                }
                bfs = bfsTemp;
            }
            return root;
        }
    }
}
