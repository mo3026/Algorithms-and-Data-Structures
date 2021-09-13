using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public static int[] CountBits(int n)
        {
            List<int> list = new List<int>();
            list.Add(0);
            for (int i = 1;i<= n;i++)
            {
                list.Add(list[i / 2] + i % 2);
            }
            return list.ToArray();
        }
    }
}
