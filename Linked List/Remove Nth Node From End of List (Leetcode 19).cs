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

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int i = 1;
            ListNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
                i++;
            }
            temp = head;
            ListNode behind = null;
            int j = 1;
            while (j != i - n + 1 && temp.next != null)
            {
                behind = temp;
                temp = temp.next;
                j++;
            }
            if (behind != null) behind.next = temp.next;
            else
            {
                if (head.next == null) return null;
                else return head.next;
            }
            return head;
        }
    }
}
