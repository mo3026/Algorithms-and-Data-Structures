using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public String encode(List<String> strs)
        {
            string result="";
            foreach (String str in strs)
            {
                int len = str.Length;
                result += len + "#" + str;
            }
            return result;
        }

        public List<String> decode(String s)
        {
            List<string> result=new List<string>();
            int i = 0;
            while (s.Length > i)
            {
                int j = s.IndexOf('#');
                int length = int.Parse(s.Substring(i, j-i));
                result.Add(s.Substring(j+1,length));
            }
            return result;
        }
    }
}
