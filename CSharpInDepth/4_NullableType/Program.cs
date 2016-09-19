using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_NullableType
{
    class Program
    {
        static void Main(string[] args)
        {
            BoxingAndUnboxingForNullableGeneric();

            Console.ReadKey();
        }

        /// <summary>
        /// 4-2 可空类型的装箱和拆箱行为
        /// </summary>
        static void BoxingAndUnboxingForNullableGeneric()
        {
            Nullable<int> nullable = 5;

            //装箱成"有值的可空类型的实例"
            object boxed = nullable;
            Console.WriteLine(boxed.GetType());

            //拆箱成非可空变量
            int normal = (int) boxed;
            Console.WriteLine(normal);

            //拆箱成可空变量
            nullable = (Nullable<int>) boxed;
            Console.WriteLine(nullable);

            //装箱成"没有值的可空类型的实例"
            nullable = new Nullable<int>();
            boxed = nullable;

            Console.WriteLine(boxed == null);

            //拆箱成可空变量
            nullable = (Nullable<int>) boxed;
            Console.WriteLine(nullable.HasValue);

        }
    }
}
