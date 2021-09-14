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
        public bool PossibleBipartition(int n, int[][] dislikes)
        {
            List<List<int>> graph = new List<List<int>>();
            for (int i = 0; i < n; i++)
            {
                graph.Add(new List<int>());
            }

            for (int i = 0; i < dislikes.GetLength(0); i++)
            {
                graph[dislikes[i][0] - 1].Add(dislikes[i][1] - 1);
                graph[dislikes[i][1] - 1].Add(dislikes[i][0] - 1);
            }

            int[] visited = new int[n];
            for (int i = 0; i < n; i++)
            {
                if (visited[i]==0)
                {
                    if(!dfs(graph, visited, i, 1))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool dfs(List<List<int>> graph, int[] visited, int person, int group)
        {
            visited[person] = group;
            foreach (int hater in graph[person])
            {
                if (visited[hater] == group)
                {
                    return false;
                }
                if (visited[hater] == 0 && !dfs(graph, visited, hater, -group))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
