using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public class WordDictionary
        {
            class TrieNode
            {
                public TrieNode[] children = new TrieNode[26];
                public String val = "";
            }
            
            private TrieNode root;

            /** Initialize your data structure here. */
            public WordDictionary()
            {
                root = new TrieNode();
            }

            public void AddWord(string word)
            {
                TrieNode node = root;
                foreach (char c in word)
                {
                    if (node.children[c - 'a'] == null)
                    {
                        node.children[c - 'a'] = new TrieNode();
                    }
                    node = node.children[c - 'a'];
                }
                node.val = word;
            }

            public bool Search(string word)
            {
                return match(word, 0, root);
            }

            private bool match(String word, int depth, TrieNode node)
            {
                if (depth == word.Length) return !node.val.Equals("");
                if (word[depth] != '.')
                {
                    return (node.children[word[depth] - 'a'] != null && match(word, depth + 1, node.children[word[depth] - 'a']));
                }
                else
                {
                    for (int i = 0; i < node.children.Length; i++)
                    {
                        if (node.children[i] != null && match(word, depth + 1, node.children[i]))
                            return true;
                    }
                }
                return false;
            }
        }
    }
}
