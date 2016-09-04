﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _3_GenericParameterizedType
{
    class Program
    {
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
    }
}
