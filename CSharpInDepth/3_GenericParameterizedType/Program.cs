﻿using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3_GenericParameterizedType
{
    class Program
    {
        // C#2:解决C#1的问题

        /*
         * 理解泛型类型和方法
         * 泛型方法的类型推断
         * 类型约束
         * 反射和泛型
         * CLR行为
         * 泛型的限制
         * 与其他语言对比
            */
        static void Main(string[] args)
        {
            string text = @"Do you like green eggs and ham?I do not like them, Sam-I-am.I do not like green eggs and ham.";
            Dictionary<string, int> frequencies = CountWords(text);
            foreach (var entry in frequencies)
            {
                //不用强转，避免装箱拆箱的性能损耗。
                string word = entry.Key;
                int frequency = entry.Value;
                Console.WriteLine("{0}: {1}", word, frequency);      
            }
            Console.WriteLine("xixi");

            List<int> ints = new List<int>();
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);
            ints.Add(4);

            Converter<int, double> converter = TakeSquareRoot;
            List<double> doubles;
            doubles = ints.ConvertAll(converter);
            foreach (var d in doubles)
            {
                Console.WriteLine(d);
            }

            Console.WriteLine("*******");

            List<string> list = MakeList("line1", "line2");
            foreach (var li in list)
            {
                Console.WriteLine(li);
            }
            
            Console.WriteLine("*******");

            RefSample<string> refSample = new RefSample<string>();
            RefSample<string> refSample1 = new RefSample<string>();
            //if (refSample)
            //{
            //    Nullable<int> int1 = 1;
            //}
            Console.WriteLine(refSample.GetType().IsByRef);
            Console.WriteLine();
            
            Console.WriteLine("***Default value for T, could compare any type that implemented IComparable with default value.***");
            Console.WriteLine("***bigger 1, equal 0, less -1***");
            Console.WriteLine(CompareToDefault("x"));
            Console.WriteLine(CompareToDefault(10));
            Console.WriteLine(CompareToDefault(0));
            Console.WriteLine(CompareToDefault(-10));
            Console.WriteLine(CompareToDefault(DateTime.MinValue));

            string name = "Jon";
            string intro1 = "My name is " + name;
            string intro2 = "My name is " + name;
            //使用string重载的==操作符进行比较
            // Determines whether two specified strings have the same value.
            Console.WriteLine(intro1 == intro2);
            Console.WriteLine(AreReferencesEqual(intro1, intro2));                                                                                                                                                                                                                                              

            Pair<int, string> pair1 = new Pair<int, string>(10, "value");
            Pair<int, string> pair2 = Pair<int, string>.Of(10, "value");

            Console.WriteLine("***证明不同的封闭类型具有不同的静态字段***");

            TypeWithField<int>.field = "First";
            TypeWithField<string>.field = "Second";
            TypeWithField<DateTime>.field = "Third";

            TypeWithField<int>.PrintField();
            TypeWithField<string>.PrintField();
            TypeWithField<DateTime>.PrintField();

            Console.WriteLine("***C#1:一个完整的泛型枚举--从0枚举到9***");
            CountingEnumerable counter = new CountingEnumerable();
            foreach (var x in counter)//1.首先调用MoveNext方法。 2.获取Current的值。
            {
                Console.WriteLine(x);
            }

            Console.WriteLine("***对类型参数使用typeof操作符***");
            DemonstrateTypeof<int>();

            Console.WriteLine("***获取泛型和已构造Type对象的各种方式***");
            string listTypeName = "System.Collections.Generic.List`1";
            Type defByName = Type.GetType(listTypeName);

            Type closedByName = Type.GetType(listTypeName + "[System.String]");
            Type closedByMethod = defByName.MakeGenericType(typeof(string));
            Type closedByTypeof = typeof(List<string>);

            Console.WriteLine(closedByMethod == closedByName);
            Console.WriteLine(closedByName == closedByTypeof);

            Type defByTypeof = typeof(List<>);
            Type defByMethod = closedByName.GetGenericTypeDefinition();

            Console.WriteLine(defByMethod == defByName);
            Console.WriteLine(defByName == defByTypeof);

            Console.WriteLine("***通过反射来获取和调用泛型方法***");
            Type type = typeof(Snippet);
            MethodInfo definition = type.GetMethod("PrintTypeParameter");
            MethodInfo constructed = definition.MakeGenericMethod(typeof(string));
            constructed.Invoke(null, null);

            Console.WriteLine("***泛型可变性的缺乏***");
            //Animal[] animals = new Cat[5];//编译通过，但会在运行时出现写入错误
            //animals[0] = new Turtle();//“System.ArrayTypeMismatchException”类型的未经处理的异常在 3_GenericParameterizedType.exe 中发生 
            //List<Animal> animals = new List<Cat>();//编译不通过

            Console.ReadKey();
        }

        private static Dictionary<string, int> CountWords(string text)
        {
            Dictionary<string, int> frequencies = new Dictionary<string, int>();
            string[] words = Regex.Split(text.ToLower(), @"\W+");

            foreach (string word in words)
            {
                if (frequencies.ContainsKey(word))
                {
                    frequencies[word]++;//使计数递增的步骤实际是先对映射的索引器执行一次取值操作，然后增加，再对索引器执行赋值操作。
                }
                else
                {
                    frequencies[word] = 1;
                }
            }
            return frequencies;
        }

        static double TakeSquareRoot(int x)
        {
            return Math.Sqrt(x);
        }

        static List<T> MakeList<T>(T first, T second)
        {
            List<T> list = new List<T>();
            list.Add(first);
            list.Add(second);
            return list;
        }

        struct RefSample<T> where T : class
        {
        }

        public T CreateInstance<T>() where T : new ()
        {
            return new T();
        }

        /// <summary>
        /// 以泛型方式将一个给定的值和默认值进行比较
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        static int CompareToDefault<T>(T value) where T : IComparable<T>
        {
            return value.CompareTo(default(T));
        }

        /// <summary>
        /// 用==和!=进行引用比较
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        static bool AreReferencesEqual<T>(T first, T second) where T : class
        {
            //比较引用
            return first == second;
        }

        static void DemonstrateTypeof<X>()
        {
            //显示方法的类型参数
            Console.WriteLine(typeof(X));
            //显示泛型类型
            Console.WriteLine(typeof(List<>));
            Console.WriteLine(typeof(Dictionary<,>));
            //显示封闭类型，尽管使用了类型参数
            Console.WriteLine(typeof(List<X>));
            Console.WriteLine(typeof(Dictionary<string,X>));
            //显式封闭类型
            Console.WriteLine(typeof(List<long>));
            Console.WriteLine(typeof(Dictionary<long,Guid>));
        }

        
    }

    internal class Snippet
    {
        public static void PrintTypeParameter<T>()
        {
            Console.WriteLine(typeof(T));
        }
    }

    class Animal { }
    class Cat : Animal { }
    class Turtle : Animal { }


    /// <summary>
    /// 使用泛型辅助类解决逆变性缺乏问题
    /// </summary>
    /// <typeparam name="TBase"></typeparam>
    /// <typeparam name="TDerived"></typeparam>
    class ComparisonHelper<TBase, TDerived> : IComparer<TDerived> where TDerived : TBase //恰当地约束类型参数
    {
        //保存原始的比较器
        private readonly IComparer<TBase> comparer;

        public ComparisonHelper(IComparer<TBase> comparer)
        {
            this.comparer = comparer;
        }
        
        /// <summary>
        /// 使用隐式类型转换来调用比较器
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(TDerived x, TDerived y)
        {
            return comparer.Compare(x, y);
        }
    }
}
