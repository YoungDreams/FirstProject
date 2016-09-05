using System.Collections;
using System.Collections.Generic;

namespace _3_GenericParameterizedType
{
    class CountingEnumerable : IEnumerable<int>
    {
        /// <summary>
        /// 隐式实现IEnumerable<T>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            return new CountingEnumerator();
        }

        /// <summary>
        /// 显式实现IEnumerable<T>
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class CountingEnumerator : IEnumerator<int>
    {
        int current = -1;

        public bool MoveNext()
        {
            current++;
            return current < 21;
        }

        /// <summary>
        /// 隐式实现IEnumerator<T>.Current
        /// </summary>
        public int Current
        {
            get { return current; }
        }

        /// <summary>
        /// 显式实现IEnumerator.Current
        /// </summary>
        object IEnumerator.Current
        {
            get { return current; }
        }

        public void Reset()
        {
            current = -1;
        }

        public void Dispose()
        {
        }
    }
}