using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public static ListNode DetectCycle(ListNode head)
        {
            if (head == null || head.next == null) return null;
            ListNode slow = head;
            ListNode fast = head.next;
            while (fast != slow)
            {
                if (fast == null) return null;
                if (fast.next == null) return null;
                slow = slow.next;
                fast = fast.next.next;
            }
            HashSet<ListNode> set = new HashSet<ListNode>();
            while (set.Add(slow))
            {
                slow = slow.next;
            }
            ListNode iterator = head;
            while (!set.Contains(iterator))
            {
                iterator = iterator.next;
            }
            return iterator;
        }
    }
}
