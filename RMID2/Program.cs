using System;
using System.Collections.Generic;

namespace RMID2
{
    class PriorityQueue<T>
    {
        IComparer<T> comparer;
        T[] heap;
        public int Count { get; private set; }

        public PriorityQueue() : this(null)
        {
        }

        public PriorityQueue(int capacity) : this(capacity, null)
        {
        }

        public PriorityQueue(IComparer<T> comparer) : this(16, comparer)
        {
        }

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

        public T last()
        {
            return heap[--Count];
        }

        public void delLast(T n)
        {
            heap[Count] = n;
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
        public static void Main()
        {
            int n, temp;
            int numberOfTests = Int32.Parse(Console.ReadLine() ?? throw new Exception());
            for (int z = 0; z < numberOfTests; z++)
            {
                var minHeap = new PriorityQueue<int>();
                var maxHeap = new PriorityQueue<int>();
                while (true)
                {
                    n = Int32.Parse(Console.ReadLine() ?? throw new Exception());

                    if (n == 0)
                        break;
                    if (n == -1)
                    {
                        Console.WriteLine(minHeap.top());
                        minHeap.pop();
                        if (minHeap.Count < maxHeap.Count)
                        {
                            temp = maxHeap.last();
                            maxHeap.delLast(0);
                            minHeap.push(temp);
                        }
                    }
                    else
                    {
                        if (minHeap.Count == 0 && maxHeap.Count == 0)
                            minHeap.push(n);
                        else
                        {
                            if (n >= minHeap.top())
                                maxHeap.push(n);
                            else
                                minHeap.push(n);

                            if (minHeap.Count < maxHeap.Count)
                            {
                                temp = maxHeap.last();
                                maxHeap.delLast(0);
                                minHeap.push(temp);
                            }
                            else if (minHeap.Count > maxHeap.Count + 1)
                            {
                                temp = minHeap.top();
                                minHeap.pop();
                                maxHeap.push(temp);
                            }
                        }
                    }
                }
            }
        }
    }
}