using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        public enum HeapType
        {
            Minheap,
            Maxheap
        }

        class PriorityQueue<T>
        {
            IComparer<T> comparer;
            T[] heap;
            public int Count { get; private set; }
            public PriorityQueue() : this(null) { }
            public PriorityQueue(HeapType heapType) : this(16, heapType) { }
            public PriorityQueue(int capacity) : this(capacity, null) { }
            public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }
            public PriorityQueue(int capacity, IComparer<T> comparer)
            {
                this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
                this.heap = new T[capacity];
            }
            public PriorityQueue(int capacity, HeapType heapType)
            {
                if (heapType == HeapType.Maxheap) comparer = Comparer<T>.Default;
                else comparer = Comparer<T>.Create((x, y) => Comparer<T>.Default.Compare(y, x));
                this.heap = new T[capacity];
            }
            public void push(T v)
            {
                if (Count >= heap.Length) Array.Resize(ref heap, Count * 2);
                heap[Count] = v;
                SiftUp(Count++);
            }
            public T pop()
            {
                var v = top();
                heap[0] = heap[--Count];
                if (Count > 0) SiftDown(0);
                return v;
            }
            public T top()
            {
                if (Count > 0) return heap[0];
                throw new InvalidOperationException("Priority queue is empty.");
            }
            void SiftUp(int n)
            {
                var v = heap[n];
                for (var n2 = n / 2; n > 0 && comparer.Compare(v, heap[n2]) > 0; n = n2, n2 /= 2) heap[n] = heap[n2];
                heap[n] = v;
            }
            void SiftDown(int n)
            {
                var v = heap[n];
                for (var n2 = n * 2; n2 < Count; n = n2, n2 *= 2)
                {
                    if (n2 + 1 < Count && comparer.Compare(heap[n2 + 1], heap[n2]) > 0) n2++;
                    if (comparer.Compare(v, heap[n2]) >= 0) break;
                    heap[n] = heap[n2];
                }
                heap[n] = v;
            }
        }

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
            var heap = new PriorityQueue<ListNode>(Comparer<ListNode>.Create((x, y) => Comparer<int>.Default.Compare(y.val, x.val)));
            foreach (var list in lists)
            {
                if (list != null)
                {
                    heap.push(list);
                }
            }
            while (heap.Count > 0)
            {
                var top = heap.pop();

                start.next = top;
                start = start.next;

                if (top.next != null)
                {
                    heap.push(top.next);
                }
            }
            return fakehead.next;
        }
    }
}
