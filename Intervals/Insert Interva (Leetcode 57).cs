using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            List<int[]> res = new List<int[]>();
            for (int i=0;i<intervals.GetLength(0);i++)
            {
                if (newInterval[1] < intervals[i][0])
                {
                    res.Add(newInterval);
                    res.AddRange(intervals.Skip(i));
                    return res.ToArray();
                }
                else
                {
                    if (newInterval[0] > intervals[i][1])
                    {
                        res.Add(intervals[i]);
                    }
                    else
                    {
                        newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                        newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);
                    }
                }
            }
            res.Add(newInterval);
            return res.ToArray();
        }
    }
}
