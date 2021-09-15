using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public class Trie
        {
            public Trie[] children;
            public String word;

            public Trie()
            {
                children = new Trie[26];
            }
        }

        public static int[,] DIRECTIONS = { { -1, 0 }, { 1, 0 }, { 0, -1 }, { 0, 1 } };

        public void buildTrie(Trie root, String word)
        {
            for (int i = 0; i < word.Length; ++i)
            {
                int j = word[i] - 'a';
                if (root.children[j] == null)
                {
                    root.children[j] = new Trie();
                }
                root = root.children[j];
            }

            root.word = word;   // set word
        }

        public void dfs(char[][] board, int i, int j, Trie root, List<String> res)
        {
            if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length)
            {
                return;
            }

            char c = board[i][j];
            if (c == '#' || root.children[c - 'a'] == null)
            {
                return;
            }

            board[i][j] = '#';
            root = root.children[c - 'a'];
            if (root.word != null)
            {
                res.Add(root.word);
                root.word = null;
            }

            for (int d=0;d< DIRECTIONS.GetLength(0); d++)
            {
                dfs(board, i + DIRECTIONS[d,0], j + DIRECTIONS[d,1], root, res);
            }

            board[i][j] = c;    // backtracking
        }

        public List<String> findWords(char[][] board, String[] words)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0
               || words == null || words.Length == 0)
            {
                return new List<string>();
            }

            Trie root = new Trie();
            foreach (String word in words)
            {
                buildTrie(root, word);
            }

            List<String> res = new List<string>();
            for (int i = 0; i < board.Length; ++i)
            {
                for (int j = 0; j < board[0].Length; ++j)
                {
                    dfs(board, i, j, root, res);
                }
            }
            return res;
        }
    }
}
