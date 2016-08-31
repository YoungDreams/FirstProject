using System;
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
    }
}
