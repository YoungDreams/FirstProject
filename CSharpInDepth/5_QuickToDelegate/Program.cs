using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_QuickToDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamFactory factory = GenerateSampleData; // 3.利用协变性来转换方法组

            using (Stream stream = factory()) // 4.调用委托以获得Stream
            {
                int data;
                while ((data = stream.ReadByte()) != -1)
                {
                    Console.WriteLine(data);
                }
            }

            Derived x = new Derived();
            SampleDelegate factory1 = new SampleDelegate(x.CandidateAction);
            factory1("test");
            Console.ReadKey();
        }

        delegate Stream StreamFactory(); // 1.声明返回Stream的委托类型

        static MemoryStream GenerateSampleData() // 2.声明返回MemoryStream的方法
        {
            byte[] buffer = new byte[16];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (byte) i;
            }
            return new MemoryStream(buffer);
        }

        delegate void SampleDelegate(string x);

        public void CandidateAction(string x)
        {
            Console.WriteLine("Snippet.CandidateAction");
        }

        public class Derived : Snippet
        {
            public void CandidateAction(object o)
            {
                Console.WriteLine("Derived.CandidateAction");
            }
        }
    }

    internal class Snippet
    {
    }
}
