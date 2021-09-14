using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        //https://www.youtube.com/watch?v=6kTZYvNNyps
        public static bool dfs(char c, Dictionary<char,bool> visited, Dictionary<char, HashSet<char>> adj, List<char> order)
        {
            if (visited.ContainsKey(c)) return visited[c];

            visited[c] = true;

            if (adj.ContainsKey(c))
            {
                foreach (char c2 in adj[c])
                {
                    if (dfs(c2, visited, adj, order)) return true;
                }
            }

            visited[c] = false;
            order.Add(c);
            return false;
        }

        public static String alienOrder(String[] words)
        {
            if (words == null || words.Length == 0) return "";

            Dictionary<char, HashSet<char>> adj = new Dictionary<char, HashSet<char>>();

            for (int i=0;i<words.Length-1;i++)
            {
                string word1 = words[i];
                string word2 = words[i + 1];
                int minLength = Math.Min(word1.Length, word2.Length);
                if (word1.Length > word2.Length && word1.Substring(0, minLength) == word2.Substring(0, minLength)) return "";
                for(int j=0;j<minLength;j++)
                {
                    if(word1[j]!=word2[j])
                    {
                        if (!adj.ContainsKey(word1[j])) adj[word1[j]] = new HashSet<char>();
                        adj[word1[j]].Add(word2[j]);
                        break;
                    }
                }
            }
            Dictionary<char, bool> visited = new Dictionary<char, bool>();
            List<char> order = new List<char>();
            foreach (char c in adj.Keys)
            {
                if (dfs(c, visited, adj, order)) return "";
            }
            order.Reverse();
            return new string(order.ToArray());
        }
    }
}
