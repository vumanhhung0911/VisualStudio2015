using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    class Book
    {
        string Title;
        public Book(string title)
        {
            Title = title;
        }
        public override string ToString()
        {
            return Title;
        }

    }
    class Example02
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }

        static void Main(string[] args)
        {
            int a, b;
            char c, d;
            Book e, f;

            a = 10;
            b = 20;
            c = 'I';
            d = 'V';
            e = new Book("tutorialspoint");
            f = new Book("C# 5.0 Nutshell");
            // hiển thị các giá trị before swap:
            Console.WriteLine("Int values before swapping:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values before swapping:");
            Console.WriteLine("c = {0}, d = {1}", c, d);
            Console.WriteLine("Book values before swapping:");
            Console.WriteLine("e = {0}, f = {1}", e, f);
            Console.WriteLine();
            Console.WriteLine();

            //Call Swap
            Swap<int>(ref a, ref b);
            Swap<char>(ref c, ref d);
            Swap<Book>(ref e, ref f);

            // hiển thị các giá trị sau khi swap:
            Console.WriteLine("Int values after swapping:");
            Console.WriteLine("a = {0}, b = {1}", a, b);
            Console.WriteLine("Char values after swapping:");
            Console.WriteLine("c = {0}, d = {1}", c, d);
            Console.WriteLine("Book values after swapping:");
            Console.WriteLine("e = {0}, f = {1}", e, f);

            Console.Read();
        }
    }
}
