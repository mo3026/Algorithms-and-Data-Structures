using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static int EraseOverlapIntervals(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            int count = 0;
            int max = int.MinValue;
            intervals = intervals.OrderBy(n => n[1]).ToArray();
            for (int i = 0; i < intervals.GetLength(0); i++)
            {
                if (intervals[i][0] >= max)
                {
                    max = intervals[i][1];
                }
                else
                {
                    count += 1;
                }
            }
            return count;
        }
    }
}
