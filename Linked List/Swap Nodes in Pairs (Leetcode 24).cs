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

        public static ListNode SwapPairs(ListNode head)
        {
            ListNode ParentHead = null;
            if (head != null && head.next != null)
            {
                ListNode a = head;
                ListNode b = a.next;
                a.next = b.next;
                b.next = a;
                head = b;
                ParentHead = a;
            }
            while (ParentHead != null && ParentHead.next != null && ParentHead.next.next != null)
            {
                ListNode a = ParentHead.next;
                ListNode b = a.next;
                a.next = b.next;
                b.next = a;
                ParentHead.next = b;
                ParentHead = a;
            }
            return head;
        }
    }
}
