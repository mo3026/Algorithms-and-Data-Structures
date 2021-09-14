using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        private static int FindRoot(List<int> parent, int n)
        {
            int res = n;
            while (parent[res] != res)
            {
                parent[res] = parent[parent[res]];
                res = parent[res];
            }
            return res;
        }

        public static int union(List<int> parent, List<int> rank, int n1, int n2)
        {
            int root1 = FindRoot(parent, n1);
            int root2 = FindRoot(parent, n2);
            if (root1 == root2) return 0;
            if (rank[root2] > rank[root1])
            {
                parent[root1] = root2;
                rank[root2] += rank[root1];
            }
            else
            {
                parent[root2] = root1;
                rank[root1] += rank[root2];
            }

            return 1;
        }

        public static int CountComponents(int n, int[][] edges)
        {
            List<int> parent = Enumerable.Range(0, n).ToList();
            List<int> rank = Enumerable.Repeat(1, n).ToList();
            int res = n;
            for (int i = 0; i < edges.GetLength(0); i++)
            {
                var from = edges[i][0];
                var to = edges[i][1];
                res -= union(parent, rank, edges[i][0], edges[i][1]);
            }
            return res;
        }
    }
}
