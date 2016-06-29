using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSDN_UsingDelegates
{
    public class MethodClass
    {
        public void Method1(string message) {
            Console.WriteLine("Inside MethodClass.Method1");
            Console.WriteLine(message);
        }
        public void Method2(string message) {
            Console.WriteLine("Inside MethodClass.Method2");
            Console.WriteLine(message);
        }

    }
    class Program
    {
        public delegate void Del(string message);

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void MethodWithCallback(int par1, int par2, Del callback)
        {
            callback("The number is: " + (par1 + par2).ToString());
        }

        static void Main(string[] args)
        {
            Del handler = DelegateMethod;
            handler("Hello World");

            Del handler2 = new Del(DelegateMethod);
            handler2("I'm a machine designer");

            MethodWithCallback(1, 2, handler);

            MethodClass obj = new MethodClass();
            Del d1 = obj.Method1;
            Del d2 = obj.Method2;
            Del d3 = DelegateMethod;

            Del allMethodsDelegate = d1 + d2;
            allMethodsDelegate += d3;

            d1(allMethodsDelegate.GetInvocationList().GetLength(0).ToString());

            allMethodsDelegate("Hello again");

            // remove Method1
            allMethodsDelegate -= d1;

            //Copy allMethodDelegate while removing d2
            Del oneMethodDelegate = allMethodsDelegate - d2;
            oneMethodDelegate("Copy allMethodDelegate while removing d2");

            // Instantiate Del by using an anonymous method.
            Del del4 = delegate (string name)
            { Console.WriteLine("Notification received for: {0}", name); };
            del4("Anonymous method");

            // Inistantiate Del by using a lambda expression.
            Del del5 = name => { Console.WriteLine("notification received for: {0}", name); };
            del5("Lambda expression");
            Console.Read();
        }
    }
}
