using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public class Interval
        {
            public int start;
            public int end;
            Interval() { start = 0; end = 0; }
            Interval(int s, int e) { start = s; end = e; }
        }

        public static int minMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;
            int maxRooms = 0;
            intervals = intervals.OrderBy(n => n[0]).ThenBy(n => n[1]).ToArray();
            var descendingComparer = Comparer<int>.Create((x, y) => y.CompareTo(x));
            SortedSet<int> descSortedList = new SortedSet<int>(descendingComparer) { intervals[0][1] };
            for (int i = 1; i < intervals.GetLength(0); i++)
            {
                if (intervals[i][0] >= descSortedList.Last())
                {
                    while(descSortedList.Count>0? intervals[i][0] >= descSortedList.Last():false)
                    {
                        descSortedList.Remove(descSortedList.Last());
                    }
                    descSortedList.Add( intervals[i][1]);

                }
                else
                {
                    descSortedList.Add(intervals[i][1]);
                    if (descSortedList.Count > maxRooms) maxRooms = descSortedList.Count;
                }
            }
            return maxRooms;
        }
    }
}
