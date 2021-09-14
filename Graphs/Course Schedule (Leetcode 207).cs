using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            if (numCourses <= 0 || prerequisites == null) return false;
            if (prerequisites.Length == 0) return true;

            List<List<int>> graph =new List<List<int>>();
            for (int i = 0; i < numCourses; i++) graph.Add(new List<int>());
            for (int i = 0; i < prerequisites.Length; i++) graph[prerequisites[i][0]].Add(prerequisites[i][1]);

            int[] visited = new int[numCourses];
            for (int i = 0; i < numCourses; i++)
            {
                if (visited[i]==0)
                {
                    if (isCyclic(graph, visited, i)) return false;
                }
            }
            return true;
        }

        private bool isCyclic(List<List<int>> graph, int[] visited, int cur)
        {
            if (visited[cur]==2) return true;
            visited[cur] = 2;
            for (int i=0;i< graph[cur].Count;i++)
            {
                if (visited[graph[cur][i]] != 1)
                {
                    if (isCyclic(graph, visited, graph[cur][i])) return true;
                }
            }
            visited[cur] = 1;
            return false;
        }
    }
}
