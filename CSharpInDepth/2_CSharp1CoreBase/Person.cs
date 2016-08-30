using System;

namespace _2_CSharp1CoreBase
{
    //1.����ί������
    delegate void StringProcessor(string input);

    class Person
    {
        private string name;

        public Person(string name)
        {
            this.name = name;
        }

        //2.�������ݵ�ʵ������
        public void Say(string words)
        {
            Console.WriteLine("{0} says: {1}", this.name, words);
        }
    }

    class Background
    {
        //2.�������ݵľ�̬����
        public static void Note(string note)
        {
            Console.WriteLine("({0})", note);
        }
    }
}