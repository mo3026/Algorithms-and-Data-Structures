using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static int[][] Merge(int[][] intervals)
        {
            intervals = intervals.OrderBy(n => n[0]).ThenBy(n => n[1]).ToArray();
            List<int[]> output = new List<int[]>() { intervals[0] };
            for(int i=0; i<intervals.GetLength(0);i++)
            {
                int lastend = output.Last()[1];
                if(intervals[i][0]<= lastend)
                {
                    output.Last()[1] = Math.Max(lastend, intervals[i][1]);
                }
                else
                {
                    output.Add(new int[] { intervals[i][0], intervals[i][1]});
                }
            }
            return output.ToArray();
        }
    }
}
