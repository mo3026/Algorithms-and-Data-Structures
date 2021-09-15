using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static string ReorganizeString(string s)
        {
            Dictionary<char, int> cgars = s.GroupBy(c => c).ToDictionary(grp => grp.Key, grp => grp.Count());
            String sb = "";
            while (true)
            {
                cgars = (Dictionary<char, int>)cgars.Where(x => x.Value != 0).OrderByDescending(key => key.Value).ToDictionary(x => x.Key, y => y.Value);
                List<char> cs = cgars.Keys.ToList();
                if (cs.Count == 0) break;
                if (cs.Count == 1)
                {
                    if (cgars[cs[0]] > 1) return "";
                    sb += cs[0].ToString();
                    break;
                }
                sb += cs[0].ToString() + cs[1].ToString();
                cgars[cs[0]] -= 1;
                cgars[cs[1]] -= 1;
            }
            return sb;
        }
    }
}
