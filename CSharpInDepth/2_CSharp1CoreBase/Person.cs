using System;

namespace _2_CSharp1CoreBase
{
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