using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        public static int ShortestSubarray(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return -1;
            var length = nums.Length;
            var prefix = new int[length + 1];
            prefix[0] = 0;
            for (int i = 0; i < length; i++)
            {
                prefix[i + 1] = prefix[i] + nums[i];
            }
            var shortest = length + 1;
            var deque = new LinkedList<int>();
            for (int i = 0; i < prefix.Length; i++)
            {
                var current = prefix[i];
                while (deque.Count > 1 && prefix[deque.Last.Value] >= current)
                {
                    deque.RemoveLast();
                }               
                deque.AddLast(i);
                while (deque.Count > 1 && (current - prefix[deque.First.Next.Value] >= k))
                {
                    deque.RemoveFirst();
                }
                if (i > 0 && (current - prefix[deque.First.Value] >= k))
                {
                    shortest = Math.Min(shortest, i - deque.First.Value);
                }
            }
            return shortest == length + 1 ? -1 : shortest;
        }
    }
}
