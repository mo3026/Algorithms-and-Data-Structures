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

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode iterateFirst = l1;
            ListNode iterateSecond = l2;
            ListNode result = null;
            ListNode nextNode = null;
            int carry = 0;

            while (iterateFirst != null || iterateSecond != null)
            {
                int digitFirst = iterateFirst != null ? iterateFirst.val : 0;
                int digitSecond = iterateSecond != null ? iterateSecond.val : 0;
                int sum = digitFirst + digitSecond + carry;
                ListNode tempNode = new ListNode(sum % 10);
                carry = sum / 10;
                if (result == null)
                {
                    result = nextNode = tempNode;
                }
                else
                {
                    nextNode.next = tempNode;
                    nextNode = tempNode;
                }
                if (iterateFirst != null)
                {
                    iterateFirst = iterateFirst.next;
                }
                if (iterateSecond != null)
                {
                    iterateSecond = iterateSecond.next;
                }
            }

            if (carry != 0)
            {
                nextNode.next = new ListNode(carry);
            }
            return result;
        }
    }
}
