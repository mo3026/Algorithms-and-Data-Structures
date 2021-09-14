using System;
using System.Linq;

namespace ConsoleApp1
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

        public static ListNode Partition(ListNode head, int x)
        {
            if (head == null) return null;
            ListNode prec = head;
            ListNode iterator = head.next;
            while (iterator != null)
            {
                if (iterator.val < x)
                {
                    ListNode prec2 = null;
                    ListNode iterator2 = head;
                    while (iterator2 != iterator)
                    {
                        if (iterator2.val >= x)
                        {
                            if (prec2 != null)
                            {
                                prec.next = prec.next.next;
                                prec2.next = iterator;
                                iterator.next = iterator2;
                            }
                            else
                            {
                                prec.next = prec.next.next;
                                iterator.next = iterator2;
                                head = iterator;
                            }
                            break;
                        }
                        prec2 = iterator2;
                        iterator2 = iterator2.next;
                    }
                }
                prec = iterator;
                iterator = iterator.next;
            }
            return head;
        }
    }
}
