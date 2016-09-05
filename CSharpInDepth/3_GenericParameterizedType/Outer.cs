using System;

namespace _3_GenericParameterizedType
{
    class Outer<T>
    {
        public class Inner<U, V>
        {
            static Inner()
            {
                Console.WriteLine("Outer<{0}>.Inner<{1},{2}>", typeof(T), typeof(U), typeof(V));
            }

            public static void DummyMethod()
            {
            }
        }
    }
}