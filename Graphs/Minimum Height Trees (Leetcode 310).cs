using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Collections;


namespace ConsoleApp2
{
    public class Program
    {
        public IList<int> FindMinHeightTrees(int n, int[][] edges)
        {
            List<int> leaves = new List<int>();
            if (n == 1)
            {
                leaves.Add(0);
                return leaves;
            }
            Dictionary<int, HashSet<int>> graph = new Dictionary<int, HashSet<int>>();     // list of edges to  Ajacency Lists

            for (int i = 0; i < n; i++)
            {
                graph.Add(i, new HashSet<int>());
            }
            for(int i=0;i< edges.GetLength(0);i++)
            {
                graph[edges[i][0]].Add(edges[i][1]);
                graph[edges[i][1]].Add(edges[i][0]);
            }

            for (int i = 0; i < n; i++)
            {
                if (graph[i].Count == 1)
                {
                    leaves.Add(i);
                }
            }

            while (n > 2)
            {
                n -= leaves.Count;
                List<int> newLeaves = new List<int>();
                foreach (int leaf in leaves)
                {
                    foreach (int newLeaf in graph[leaf].ToList())
                    {
                        graph[leaf].Remove(newLeaf);
                        graph[newLeaf].Remove(leaf);
                        if (graph[newLeaf].Count == 1)
                        {
                            newLeaves.Add(newLeaf);
                        }
                    }
                }
                leaves = newLeaves;
            }

            return leaves;
        }
    }
}
