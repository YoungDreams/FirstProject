using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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


            //1.指定委托类型和方法，C#1
            EventHandler handler;
            handler = new EventHandler(HandleDemoEvent);
            handler(null, EventArgs.Empty);
            
            //2.隐式转换成委托实例,C#2
            handler = HandleDemoEvent;
            handler(null, EventArgs.Empty);

            //3.用一个匿名方法来指定操作
            handler = delegate(object sender, EventArgs e) { Console.WriteLine("Handled anonymously."); };
            handler(null, EventArgs.Empty);

            //4.使用匿名方法的简写形式
            handler = delegate { Console.WriteLine("Handled anonymously again."); };
            handler(null, EventArgs.Empty);

            //5.使用委托逆变性
            MouseEventHandler mouseHandler = HandleDemoEvent;
            mouseHandler(null, new MouseEventArgs(MouseButtons.None, 0,0,0,0));

            //6.Lambda表达式改进匿名方法
            Func<int, int, string> func = (x, y) => (x*y).ToString();
            Console.WriteLine(func(5,20));

            //7.隐式类型和匿名类型
            var jon1 = new {Name = "Jon", Age = 31};
            var tom1 = new {Name = "Tom", Age = 4};
            Console.WriteLine("{0} is {1}, type:{2}", jon1.Name, jon1.Age, jon1.GetType());
            Console.WriteLine("{0} is {1}, type:{2}", tom1.Name, tom1.Age, tom1.GetType());

            int? a = null;
            a = 5;
            if (a!=null)
            {
                int b = a.Value;
                Console.WriteLine(b);
            }
            int z = a ?? 10;
            Console.WriteLine(z.ToString());
            
            Console.ReadKey();
        }

        static void HandleDemoEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Handled by HandleDemoEvent");
        }
    }
    
    

}
