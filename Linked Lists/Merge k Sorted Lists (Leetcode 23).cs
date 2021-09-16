using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {
            var fakehead = new ListNode(-1);
            var start = fakehead;

            var heap = new List<ListNode>();

            foreach (var list in lists)
            {
                if (list != null)
                {
                    heap.Add(list);
                }
            }

            heap = heap.OrderBy(x => x.val).ToList();

            while (heap.Any())
            {
                var top = heap.First();

                start.next = top;
                start = start.next;

                heap.RemoveAt(0);

                if (top.next != null)
                {
                    heap.Add(top.next);
                    heap = heap.OrderBy(x => x.val).ToList();
                }
            }

            return fakehead.next;
        }
    }
}
