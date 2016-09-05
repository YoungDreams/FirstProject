using System;

namespace _3_GenericParameterizedType
{
    class TypeWithField<T>
    {
        public static string field;

        public static void PrintField()
        {
            Console.WriteLine(field + ": " + typeof(T).Name);
        }
    }
}