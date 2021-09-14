using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public class Node
        {
            public int val;
            public IList<Node> neighbors;

            public Node()
            {
                val = 0;
                neighbors = new List<Node>();
            }

            public Node(int _val)
            {
                val = _val;
                neighbors = new List<Node>();
            }

            public Node(int _val, List<Node> _neighbors)
            {
                val = _val;
                neighbors = _neighbors;
            }
        }

        public static Node CloneGraph(Node node, Dictionary<int, Node> hash)
        {
            if (hash.ContainsKey(node.val)) return hash[node.val];
            Node nodeCopy = new Node(node.val);
            hash.Add(nodeCopy.val,nodeCopy);
            foreach (Node neighbor in node.neighbors)
            {
                nodeCopy.neighbors.Add(CloneGraph(neighbor, hash));
            }
            return nodeCopy;
        }

        public static Node CloneGraph(Node node)
        {
            if (node == null) return null;
            Dictionary<int, Node> hash = new Dictionary<int, Node>();
            return CloneGraph(node, hash);
        }
    }
}
