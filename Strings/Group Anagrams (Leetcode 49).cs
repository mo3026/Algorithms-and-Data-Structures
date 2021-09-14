using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs)
        {
            if (strs == null || strs.Length == 0) return new List<IList<string>>();

            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();
            foreach (string s in strs)
            {
                char[] characters = s.ToCharArray();
                string keyStr = new string(characters.OrderBy(c => c).ToArray());
                if (!map.ContainsKey(keyStr)) map.Add(keyStr, new List<string>());
                map[keyStr].Add(s);
            }

            List<IList<string>> res = map.Select(p => p.Value).ToList();
            return res;
        }
    }
}
