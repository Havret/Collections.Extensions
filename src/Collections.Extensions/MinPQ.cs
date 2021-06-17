using System;
using System.Runtime.CompilerServices;

namespace Havret.Collections.Extensions
{
    public class MinPQ<T> where T : IComparable<T>
    {
        private T[] _pq;
        private int _n;

        /// <param name="capacity">The number of elements that the new queue can initially store.</param>
        public MinPQ(int capacity)
        {
            _pq = new T[capacity + 1];
        }

        public MinPQ() : this(1)
        {
        }

        
        public void Insert(T key)
        {
            // double size of array if necessary
            if (_n == _pq.Length - 1)
            {
                Resize(2 * _pq.Length);
            }

            // add key, and percolate it up to maintain heap invariant
            _pq[++_n] = key;
            Swim(_n);
        }

        public T Min => _pq[1];

        public T DeleteMin()
        {
            T min = _pq[1];
            Exchange(1, _n--);
            _pq[_n + 1] = default;
            Sink(1);

            if (_n > 0 && _n == (_pq.Length - 1) / 4)
            {
                Resize(_pq.Length / 2);
            }

            return min;
        }

        private void Swim(int k)
        {
            while (k > 1 && Greater(GetParent(k), k))
            {
                Exchange(GetParent(k), k);
                k /= 2;
            }
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int GetParent(int k) => k / 2;


        private void Resize(int capacity)
        {
            var temp = new T[capacity];
            for (int i = 0; i <= _n; i++)
            {
                temp[i] = _pq[i];
            }

            _pq = temp;
        }

        private void Sink(int k)
        {
            while (2 * k <= _n)
            {
                int j = 2 * k;
                if (j < _n && Greater(j, j + 1))
                {
                    j++;
                }

                if (!Greater(k, j))
                {
                    break;
                }

                Exchange(k, j);
                k = j;
            }
        }

        private bool Greater(int i, int j) => _pq[i].CompareTo(_pq[j]) > 0;

        private void Exchange(int i, int j) => (_pq[i], _pq[j]) = (_pq[j], _pq[i]);
    }
}