using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public int[][] KClosest(int[][] points, int k)
        {
            return points.Select(x => new { dis = x[0] * x[0] + x[1] * x[1], point = x }).OrderBy(x => x.dis).Select(x => x.point).Take(k).ToArray();
        }
    }
}
