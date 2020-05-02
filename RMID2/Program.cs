using System;
using System.Collections.Generic;

namespace RMID2
{
    class PriorityQueue<T>
    {
        IComparer<T> comparer;
        T[] heap;
        public int Count { get; private set; }
        public PriorityQueue() : this(null) { }
        public PriorityQueue(int capacity) : this(capacity, null) { }
        public PriorityQueue(IComparer<T> comparer) : this(16, comparer) { }
        public PriorityQueue(int capacity, IComparer<T> comparer)
        {
            this.comparer = (comparer == null) ? Comparer<T>.Default : comparer;
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
            throw new InvalidOperationException("top exception");
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
    internal class Program
    {
        public void Main()
        {
            int t = 0; // Nb of test cases;
            int n = 0, temp = 0;
            int nb1, nb2;
            inp(t);
            for (int z = 0; z < t; z++) {
                var maxHeap = new PriorityQueue<int>();
                var minHeap = new PriorityQueue<int>();
                while (true) {
                    inp (n);

                    if (n == 0)
                        break;
                    else if (n == -1) {
                        Console.WriteLine("\n", maxHeap.top ());
                        maxHeap.pop ();
                        if (maxHeap.Count < minHeap.Count) {
                            temp = minHeap.top ();
                            minHeap.pop ();
                            maxHeap.push (temp);
                        }
                    }
                    else {
                        if (maxHeap.Count== 0 && minHeap.Count == 0)
                            maxHeap.push (n);
                        else {
                            nb1 = maxHeap.top ();
                            if (n >= nb1)
                                minHeap.push (n);
                            else
                                maxHeap.push (n);

                            if (maxHeap.Count < minHeap.Count) {
                                temp = minHeap.top ();
                                minHeap.pop ();
                                maxHeap.push (temp);
                            }
                            else if (maxHeap.Count > minHeap.Count + 1) {
                                temp = maxHeap.top();
                                maxHeap.pop ();
                                minHeap.push (temp);
                            }
                        }
                    }
                }
            }
        }
        void inp( int n )
        {
            n=0;
            int ch=Console.Read();int sign=1;
            while(ch < '0' || ch > '9' ){if(ch=='-')sign=-1; ch=Console.Read();}

            while (ch >= '0' && ch <= '9')
                n = (n << 3) + (n << 1) + ch - '0'; ch=Console.Read();
            n=n*sign;
        }
    }
}