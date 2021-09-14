using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public int countComponents(int n, int[][] edges)
        {
            List<List<Integer>> graph = new ArrayList<List<Integer>>();
            for (int i = 0; i < n; i++)
            {
                graph.add(new ArrayList<Integer>());
            }

            for (int[] edge : edges)
            {
                graph.get(edge[0]).add(edge[1]);
                graph.get(edge[1]).add(edge[0]);
            }

            HashSet<Integer> visited = new HashSet<Integer>();
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (!visited.contains(i))
                {
                    // bfs(graph, i, visited);
                    dfs(graph, i, visited);
                    count++;
                }
            }
            return count;
        }

        public void bfs(List<List<Integer>> graph, int i, HashSet<Integer> visited)
        {
            LinkedList<Integer> que = new LinkedList<Integer>();
            visited.add(i);
            que.add(i);
            while (!que.isEmpty())
            {
                int cur = que.poll();
                List<Integer> neighbours = graph.get(cur);
                for (int neighbour : neighbours)
                {
                    if (!visited.contains(neighbour))
                    {
                        que.add(neighbour);
                        visited.add(neighbour);
                    }
                }
            }
        }

        public void dfs(List<List<Integer>> graph, int i, HashSet<Integer> visited)
        {
            visited.add(i);
            for (int neighbour : graph.get(i))
            {
                if (!visited.contains(neighbour))
                {
                    dfs(graph, neighbour, visited);
                }
            }
        }
    }
}
