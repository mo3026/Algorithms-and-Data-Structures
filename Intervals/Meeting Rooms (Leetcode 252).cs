using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public static bool canAttendMeetings(int[][] intervals)
        {
            if (intervals==null) return false;
            if (intervals.Length == 0) return true;
            intervals = intervals.OrderBy(n => n[1]).ToArray();
            for (int i = 1; i < intervals.GetLength(0); i++)
            {
                if (intervals[i][0] < intervals[i - 1][1]) return false;
            }
            return true;
        }
    }
}
