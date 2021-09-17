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

        public int[] TopKFrequent(int[] nums, int k)
        {
            PriorityQueue<List<int>> queue = new PriorityQueue<List<int>>(Comparer<List<int>>.Create((x, y) => Comparer<int>.Default.Compare(x[1], y[1])));
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach (int x in nums)
            {
                if (dic.ContainsKey(x)) dic[x]++;
                else
                {
                    dic.Add(x, 1);
                }
            }
            foreach (var key in dic.Keys)
            {
                queue.push(new List<int> { key, dic[key] });
            }
            List<int> frequent = new List<int>();
            for (int i = 0; i < k; i++)
            {
                frequent.Add(queue.pop()[0]);
            }
            return frequent.ToArray();
        }


        public int[] TopKFrequent2(int[] nums, int k)
        {
            Dictionary<int, int> dic = new Dictionary<int, int>();
            foreach( int x in nums)
            {
                if (dic.ContainsKey(x)) dic[x]++;
                else
                {
                    dic.Add(x, 1);
                }
            }
            return dic.OrderBy(w => -w.Value).Take(k).Select(x=>x.Key).ToArray();
        }
    }
}
