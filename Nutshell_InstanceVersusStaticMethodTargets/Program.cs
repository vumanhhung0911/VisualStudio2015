using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutshell_InstanceVersusStaticMethodTargets
{
    public delegate void ProgressReporter(int percentComplete);
    public delegate void DelPrint(string str);
    class X
    {
        public void InstanceProgress(int percentComplete)
        {
            Console.WriteLine(percentComplete);
        }
    }
    class Program
    {
        static void PrintSomething(string str)
        {
            Console.WriteLine(str);
        }
        static void Main(string[] args)
        {
            X x = new X();
            ProgressReporter p = x.InstanceProgress;
            p(99);
            Console.WriteLine(p.Target == x);
            Console.WriteLine(p.Method);

            DelPrint print = PrintSomething;
            print("Static Print Method");
            Console.WriteLine(print.Target == null);
            Console.WriteLine(print.Method);
            Console.ReadLine();
        }
        /*
            Khi một "phương thức thực thể" được gán cho một đối tượng delegate,
            cái sau cùng phải duy trì không chỉ phương thức, mà còn thực thể chứa phương thức.
            (Tức là delegate có property Target để tham chiếu thực thể mà được gán cho nó,
             còn property Method thì tham chiếu đến phương thức)
        */
    }
}
