using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static bool IsValid(string s)
        {
            Stack<Char> stack = new Stack<Char>();
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
                if (s.Length == 0) return false;
                if (s[i] == '(')
                {
                    stack.Push(')');
                }
                else if (s[i] == '{')
                {
                    stack.Push('}');
                }
                else if (s[i] == '[')
                {
                    stack.Push(']');
                }
                else if (stack.Count == 0)
                    return false;
                else if (s[i] == stack.Peek())
                {
                    stack.Pop(); Console.WriteLine("pop");
                }
                else
                    return false;
            }
            if (stack.Count == 0)
                return true;
            return false;
        }
    }
}
