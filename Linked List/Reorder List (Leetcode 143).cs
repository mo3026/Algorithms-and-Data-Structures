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

        public static ListNode ReorderList(ListNode head)
        {
            List<ListNode> list = new List<ListNode>();
            ListNode temp = head;
            while(temp!=null)
            {
                list.Add(temp);
                temp = temp.next;
            }
            int index = list.Count-1;
            temp = head;
            while (index>= list.Count/2)
            {
                ListNode temp2 = temp.next;
                temp.next = list[index];
                index--;
                temp.next.next = temp2;
                temp = temp2;
            }
            if(temp!=null && temp.next!=null) temp.next.next = null;
            return head;
        }
    }
}
