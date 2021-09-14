using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static bool validTree(int n, int[][] edges)
        {
            List<HashSet<int>> adjList = new List<HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                adjList.Add(new HashSet<int>());
            }
            foreach (int[] edge in edges)
            {
                adjList[edge[0]].Add(edge[1]);
                adjList[edge[1]].Add(edge[0]);
            }
            bool[] visited = new bool[n];
            return dfs(0, visited, adjList, -1) && visited.All(x => x);
        }

        public static bool dfs(int node, bool[] visited, List<HashSet<int>> adjList, int parent)
        {
            if (visited[node]) return false;
            visited[node] = true;
            foreach (int nextNode in adjList[node])
            {
                if (nextNode == parent) continue;
                else
                {
                    if (!dfs(nextNode, visited, adjList, node)) return false;
                }
            }
            return true;
        }
    }
}
