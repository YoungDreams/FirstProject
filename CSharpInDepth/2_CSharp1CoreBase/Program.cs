using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_CSharp1CoreBase
{

    /*
     让委托做某事，必须满足4个条件:
     1.声明 委托类型;
     2.必须有 一个方法 包含了 要执行的代码;
     3.必须创建一个 委托实例
     4.必须调用(invoke) 委托实例
         */
    class Program
    {
        static void Main(string[] args)
        {
            Person jon = new Person("Jon");
            Person tom = new Person("Tom");
            StringProcessor jonsVoice, tomsVoice, background;
            //3.创建3个委托实例
            jonsVoice = new StringProcessor(jon.Say);
            tomsVoice = new StringProcessor(tom.Say);
            background = new StringProcessor(Background.Note);
            //4.调用委托实例
            jonsVoice("Hello, son.");
            tomsVoice("Hello, Daddy!");
            background("An airplane flies past.");

            Console.ReadKey();
        }
    }

    //1.声明委托类型
    delegate void StringProcessor(string input);

    class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        //2.声明兼容的实例方法
        public void Say(string words)
        {
            Console.WriteLine("{0} says: {1}", this.name, words);
        }
    }

    class Background
    {
        //2.声明兼容的静态方法
        public static void Note(string note)
        {
            Console.WriteLine("({0})", note);
        }
    }

}
